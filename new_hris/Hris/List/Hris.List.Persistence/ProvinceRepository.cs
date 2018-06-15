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
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly HrisContext _dbContext;
        private readonly IMapper _mapper;

        public ProvinceRepository(HrisContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int?> Save(Province province)
        {
            if (province == null) return null;

            var provinceDb = await _dbContext.Provinces.FirstOrDefaultAsync(x => x.Id == province.Id);

            if (provinceDb == null)
            {
                provinceDb = _mapper.Map<MDProvince>(province);
                await _dbContext.Provinces.AddAsync(provinceDb);
            }
            else
            {
                provinceDb.Name = province.Name;
                provinceDb.NameEn = province.NameEn;
                provinceDb.Status = _mapper.Map<MDStatus>(province.Status);
                provinceDb.UpdatedBy = province.UpdatedBy;
                provinceDb.UpdatedAt = DateTime.UtcNow;
            }
            await _dbContext.SaveChangesAsync();

            return provinceDb.Id;
        }

        public async Task<IEnumerable<Province>> Select()
        {
            var provinces = _dbContext.Provinces
                .Where(x => !x.DeletedAt.HasValue).Select(x => _mapper.Map<Province>(x));

            return await provinces.ToListAsync();
        }

        public async Task<IEnumerable<Province>> Select(Status status)
        {
            var provinces = _dbContext.Provinces
                .Where(x => x.Status == _mapper.Map<MDStatus>(status) && !x.DeletedAt.HasValue)
                .Select(x => _mapper.Map<Province>(x));

            return await provinces.ToListAsync();
        }

        public async Task<int?> ToggleStatus(Province province)
        {
            var provincedb = await _dbContext.Provinces.FirstOrDefaultAsync(x => x.Id == province.Id);
            if (provincedb == null) return 0;

            provincedb.Status = provincedb.Status == MDStatus.Active ? MDStatus.Inactive : MDStatus.Active;
            provincedb.UpdatedAt = DateTime.UtcNow;
            provincedb.UpdatedBy = province.UpdatedBy;

            await _dbContext.SaveChangesAsync();

            return provincedb.Id;
        }

        public async Task<int?> Delete(Province province)
        {
            var provinceDb = await _dbContext.Provinces.FirstOrDefaultAsync(x => x.Id == province.Id);
            if (provinceDb == null) return 0;

            provinceDb.DeletedAt = DateTime.UtcNow;
            provinceDb.DeletedBy = province.DeletedBy;

            await _dbContext.SaveChangesAsync();

            return provinceDb.Id;
        }
    }
}
