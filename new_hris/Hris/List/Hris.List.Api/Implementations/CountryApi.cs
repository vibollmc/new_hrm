using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Services.Interfaces;
using Hris.Shared.Enum;
using Hris.Shared.Country;
using Microsoft.Extensions.DependencyInjection;

namespace Hris.List.Api
{
    public partial class ListApi
    {
        public async Task<int?> SaveCountry(CountryModel country)
        {
            var countryService = _serviceProvider.GetService<ICountryService>();

            return await countryService.Save(_mapper.Map<Country>(country));
        }

        public async Task<IEnumerable<CountryModel>> SelectCountry()
        {
            var countryService = _serviceProvider.GetService<ICountryService>();

            var countrys = await countryService.Select();

            return _mapper.Map<IEnumerable<CountryModel>>(countrys);
        }

        public async Task<IEnumerable<CountryModel>> SelectCountry(Status status)
        {
            var countryService = _serviceProvider.GetService<ICountryService>();

            var countrys = await countryService.Select(_mapper.Map<Business.Enums.Status>(status));

            return _mapper.Map<IEnumerable<CountryModel>>(countrys);
        }

        public async Task<int?> ToggleCountryStatus(CountryModel country)
        {
            var countryService = _serviceProvider.GetService<ICountryService>();

            return await countryService.ToggleStatus(_mapper.Map<Country>(country));
        }

        public async Task<int?> DeleteCountry(CountryModel country)
        {
            var countryService = _serviceProvider.GetService<ICountryService>();

            return await countryService.Delete(_mapper.Map<Country>(country));
        }
    }
}
