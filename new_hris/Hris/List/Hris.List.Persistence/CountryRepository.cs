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
    public class CountryRepository: ICountryRepository
    {
        private readonly HrisContext _dbContext;
        private readonly IMapper _mapper;

        public CountryRepository(HrisContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int?> Save(Country country)
        {
            if (country == null) return null;

            var countryDb = await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == country.Id);

            if (countryDb == null)
            {
                countryDb = _mapper.Map<MDCountry>(country);
                await _dbContext.Countries.AddAsync(countryDb);
            }
            else
            {
                countryDb.Name = country.Name;
                countryDb.NameEn = country.NameEn;
                countryDb.Status = _mapper.Map<MDStatus>(country.Status);
                countryDb.UpdatedBy = country.UpdatedBy;
                countryDb.UpdatedAt = DateTime.UtcNow;
            }
            await _dbContext.SaveChangesAsync();

            return countryDb.Id;
        }

        public async Task<IEnumerable<Country>> Select()
        {
            var countries = _dbContext.Countries
                .Where(x => !x.DeletedAt.HasValue).Select(x => _mapper.Map<Country>(x));

            return await countries.ToListAsync();
        }

        public async Task<IEnumerable<Country>> Select(Status status)
        {
            var countries = _dbContext.Countries
                .Where(x => x.Status == _mapper.Map<MDStatus>(status) && !x.DeletedAt.HasValue)
                .Select(x => _mapper.Map<Country>(x));

            return await countries.ToListAsync();
        }

        public async Task<int?> ToggleStatus(Country country)
        {
            var coutryDb = await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == country.Id);
            if (coutryDb == null) return 0;

            coutryDb.Status = coutryDb.Status == MDStatus.Active ? MDStatus.Inactive : MDStatus.Active;
            coutryDb.UpdatedAt = DateTime.UtcNow;
            coutryDb.UpdatedBy = country.UpdatedBy;

            await _dbContext.SaveChangesAsync();

            return coutryDb.Id;
        }

        public async Task<int?> Delete(Country country)
        {
            var countryDb = await _dbContext.Countries.FirstOrDefaultAsync(x => x.Id == country.Id);
            if (countryDb == null) return 0;

            countryDb.DeletedAt = DateTime.UtcNow;
            countryDb.DeletedBy = country.DeletedBy;

            await _dbContext.SaveChangesAsync();

            return countryDb.Id;
        }
    }
}