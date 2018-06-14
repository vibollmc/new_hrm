using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;
using Hris.List.Business.Repositories;
using Hris.List.Business.Services.Interfaces;

namespace Hris.List.Business.Services.Implementations
{
    public class CountryService:ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<int?> Save(Country country)
        {
            return await _countryRepository.Save(country);
        }

        public async Task<IEnumerable<Country>> Select()
        {
            return await _countryRepository.Select();
        }

        public async Task<IEnumerable<Country>> Select(Status status)
        {
            return await _countryRepository.Select(status);
        }

        public async Task<int?> ToggleStatus(Country country)
        {
            return await _countryRepository.ToggleStatus(country);
        }

        public async Task<int?> Delete(Country country)
        {
            return await _countryRepository.Delete(country);
        }
    }
}