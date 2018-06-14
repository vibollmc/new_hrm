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
    public class DistrictRepository : IDistrictRepository
    {
        private readonly HrisContext _dbContext;
        private readonly IMapper _mapper;

        public DistrictRepository(HrisContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int?> Save(District district)
        {
            if (district == null) return null;

            var districtDb = await _dbContext.Districts.FirstOrDefaultAsync(x => x.Id == district.Id);

            if (districtDb == null)
            {
                districtDb = _mapper.Map<MDDistrict>(district);
                await _dbContext.Districts.AddAsync(districtDb);
            }
            else
            {
                districtDb.Name = district.Name;
                districtDb.NameEn = district.NameEn;
                districtDb.Status = _mapper.Map<MDStatus>(district.Status);
                districtDb.UpdatedBy = district.UpdatedBy;
                districtDb.UpdatedAt = DateTime.UtcNow;
            }
            await _dbContext.SaveChangesAsync();

            return districtDb.Id;
        }

        public async Task<IEnumerable<District>> Select()
        {
            var nations = _dbContext.Districts
                .Where(x => !x.DeletedAt.HasValue).Select(x => _mapper.Map<District>(x));

            return await nations.ToListAsync();
        }

        public async Task<IEnumerable<District>> Select(Status status)
        {
            var nations = _dbContext.Districts
                .Where(x => x.Status == _mapper.Map<MDStatus>(status) && !x.DeletedAt.HasValue)
                .Select(x => _mapper.Map<District>(x));

            return await nations.ToListAsync();
        }

        public async Task<int?> ToggleStatus(District district)
        {
            var nationdb = await _dbContext.Districts.FirstOrDefaultAsync(x => x.Id == district.Id);
            if (nationdb == null) return 0;

            nationdb.Status = nationdb.Status == MDStatus.Active ? MDStatus.Inactive : MDStatus.Active;
            nationdb.UpdatedAt = DateTime.UtcNow;
            nationdb.UpdatedBy = district.UpdatedBy;

            await _dbContext.SaveChangesAsync();

            return nationdb.Id;
        }

        public async Task<int?> Delete(District district)
        {
            var districtDb = await _dbContext.Districts.FirstOrDefaultAsync(x => x.Id == district.Id);
            if (districtDb == null) return 0;

            districtDb.DeletedAt = DateTime.UtcNow;
            districtDb.DeletedBy = district.DeletedBy;

            await _dbContext.SaveChangesAsync();

            return districtDb.Id;
        }
    }
}