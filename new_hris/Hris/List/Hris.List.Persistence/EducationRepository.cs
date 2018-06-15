using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hris.Database;
using Hris.Database.Entities.List;
using Hris.Database.Enums;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;
using Hris.List.Business.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hris.List.Persistence
{
    public class EducationRepository : IEducationRepository
    {
        private readonly HrisContext _dbContext;
        private readonly IMapper _mapper;

        public EducationRepository(HrisContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int?> Save(Education education)
        {
            if (education == null) return null;

            var educationDb = await _dbContext.Educations.FirstOrDefaultAsync(x => x.Id == education.Id);

            if (educationDb == null)
            {
                educationDb = _mapper.Map<MDEducation>(education);
                await _dbContext.Educations.AddAsync(educationDb);
            }
            else
            {
                educationDb.Name = education.Name;
                educationDb.NameEn = education.NameEn;
                educationDb.Status = _mapper.Map<MDStatus>(education.Status);
                educationDb.UpdatedBy = education.UpdatedBy;
                educationDb.UpdatedAt = DateTime.UtcNow;
            }
            await _dbContext.SaveChangesAsync();

            return educationDb.Id;
        }

        public async Task<IEnumerable<Education>> Select()
        {
            var educations = _dbContext.Educations
                .Where(x => !x.DeletedAt.HasValue).Select(x => _mapper.Map<Education>(x));

            return await educations.ToListAsync();
        }

        public async Task<IEnumerable<Education>> Select(Status status)
        {
            var educations = _dbContext.Educations
                .Where(x => x.Status == _mapper.Map<MDStatus>(status) && !x.DeletedAt.HasValue)
                .Select(x => _mapper.Map<Education>(x));

            return await educations.ToListAsync();
        }

        public async Task<int?> ToggleStatus(Education education)
        {
            var educationdb = await _dbContext.Educations.FirstOrDefaultAsync(x => x.Id == education.Id);
            if (educationdb == null) return 0;

            educationdb.Status = educationdb.Status == MDStatus.Active ? MDStatus.Inactive : MDStatus.Active;
            educationdb.UpdatedAt = DateTime.UtcNow;
            educationdb.UpdatedBy = education.UpdatedBy;

            await _dbContext.SaveChangesAsync();

            return educationdb.Id;
        }

        public async Task<int?> Delete(Education education)
        {
            var educationDb = await _dbContext.Educations.FirstOrDefaultAsync(x => x.Id == education.Id);
            if (educationDb == null) return 0;

            educationDb.DeletedAt = DateTime.UtcNow;
            educationDb.DeletedBy = education.DeletedBy;

            await _dbContext.SaveChangesAsync();

            return educationDb.Id;
        }
    }
}
