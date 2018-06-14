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
    public class GenderRepository: IGenderRepository
    {
        private readonly HrisContext _dbContext;
        private readonly IMapper _mapper;

        public GenderRepository(HrisContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int?> Save(Gender gender)
        {
            if (gender == null) return null;

            var genderDb = await _dbContext.Genders.FirstOrDefaultAsync(x => x.Id == gender.Id);

            if (genderDb == null)
            {
                genderDb = _mapper.Map<MDGender>(gender);
                await _dbContext.Genders.AddAsync(genderDb);
            }
            else
            {
                genderDb.Name = gender.Name;
                genderDb.NameEn = gender.NameEn;
                genderDb.Status = _mapper.Map<MDStatus>(gender.Status);
                genderDb.UpdatedBy = gender.UpdatedBy;
                genderDb.UpdatedAt = DateTime.UtcNow;
            }
            await _dbContext.SaveChangesAsync();

            return genderDb.Id;
        }

        public async Task<IEnumerable<Gender>> Select()
        {

            var genders = _dbContext.Genders
                .Where(x => !x.DeletedAt.HasValue).Select(x => _mapper.Map<Gender>(x));

            return await genders.ToListAsync();
        }

        public async Task<IEnumerable<Gender>> Select(Status status)
        {

            var genders = _dbContext.Genders
                .Where(x => x.Status == _mapper.Map<Status, MDStatus>(status) && !x.DeletedAt.HasValue)
                .Select(x => _mapper.Map<Gender>(x));

            return await genders.ToListAsync();
        }

        public async Task<int?> ToggleStatus(Gender gender)
        {
            var genderdb = await _dbContext.Genders.FirstOrDefaultAsync(x=> x.Id == gender.Id);
            if (genderdb == null) return 0;

            genderdb.Status = genderdb.Status == MDStatus.Active ? MDStatus.Inactive : MDStatus.Active;
            genderdb.UpdatedAt = DateTime.UtcNow;
            genderdb.UpdatedBy = gender.UpdatedBy;

            await _dbContext.SaveChangesAsync();

            return genderdb.Id;
        }

        public async Task<int?> Delete(Gender gender)
        {
            var genderdb = await _dbContext.Genders.FirstOrDefaultAsync(x => x.Id == gender.Id);
            if (genderdb == null) return 0;

            genderdb.DeletedAt = DateTime.UtcNow;
            genderdb.DeletedBy = gender.DeletedBy;

            await _dbContext.SaveChangesAsync();

            return genderdb.Id;
        }
    }
}
