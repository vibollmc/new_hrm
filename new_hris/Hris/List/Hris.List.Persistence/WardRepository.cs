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
    public class WardRepository : IWardRepository
    {
        private readonly HrisContext _dbContext;
        private readonly IMapper _mapper;

        public WardRepository(HrisContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int?> Save(Ward ward)
        {
            if (ward == null) return null;

            var wardDb = await _dbContext.Wards.FirstOrDefaultAsync(x => x.Id == ward.Id);

            if (wardDb == null)
            {
                wardDb = _mapper.Map<MDWard>(ward);
                await _dbContext.Wards.AddAsync(wardDb);
            }
            else
            {
                wardDb.Name = ward.Name;
                wardDb.NameEn = ward.NameEn;
                wardDb.Status = _mapper.Map<MDStatus>(ward.Status);
                wardDb.UpdatedBy = ward.UpdatedBy;
                wardDb.UpdatedAt = DateTime.UtcNow;
            }
            await _dbContext.SaveChangesAsync();

            return wardDb.Id;
        }

        public async Task<IEnumerable<Ward>> Select()
        {
            var wards = _dbContext.Wards
                .Where(x => !x.DeletedAt.HasValue).Select(x => _mapper.Map<Ward>(x));

            return await wards.ToListAsync();
        }

        public async Task<IEnumerable<Ward>> Select(Status status)
        {
            var wards = _dbContext.Wards
                .Where(x => x.Status == _mapper.Map<MDStatus>(status) && !x.DeletedAt.HasValue)
                .Select(x => _mapper.Map<Ward>(x));

            return await wards.ToListAsync();
        }

        public async Task<int?> ToggleStatus(Ward ward)
        {
            var warddb = await _dbContext.Wards.FirstOrDefaultAsync(x => x.Id == ward.Id);
            if (warddb == null) return 0;

            warddb.Status = warddb.Status == MDStatus.Active ? MDStatus.Inactive : MDStatus.Active;
            warddb.UpdatedAt = DateTime.UtcNow;
            warddb.UpdatedBy = ward.UpdatedBy;

            await _dbContext.SaveChangesAsync();

            return warddb.Id;
        }

        public async Task<int?> Delete(Ward ward)
        {
            var wardDb = await _dbContext.Wards.FirstOrDefaultAsync(x => x.Id == ward.Id);
            if (wardDb == null) return 0;

            wardDb.DeletedAt = DateTime.UtcNow;
            wardDb.DeletedBy = ward.DeletedBy;

            await _dbContext.SaveChangesAsync();

            return wardDb.Id;
        }
    }
}
