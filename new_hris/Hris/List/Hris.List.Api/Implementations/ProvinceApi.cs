using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Services.Interfaces;
using Hris.Shared.Enum;
using Hris.Shared.Province;
using Microsoft.Extensions.DependencyInjection;

namespace Hris.List.Api
{
    public partial class ListApi
    {
        public async Task<int?> SaveProvince(ProvinceModel province)
        {
            var provinceService = _serviceProvider.GetService<IProvinceService>();

            return await provinceService.Save(_mapper.Map<Province>(province));
        }

        public async Task<IEnumerable<ProvinceModel>> SelectProvince()
        {
            var provinceService = _serviceProvider.GetService<IProvinceService>();

            var provinces = await provinceService.Select();

            return _mapper.Map<IEnumerable<ProvinceModel>>(provinces);
        }

        public async Task<IEnumerable<ProvinceModel>> SelectProvince(Status status)
        {
            var provinceService = _serviceProvider.GetService<IProvinceService>();

            var provinces = await provinceService.Select(_mapper.Map<Business.Enums.Status>(status));

            return _mapper.Map<IEnumerable<ProvinceModel>>(provinces);
        }

        public async Task<int?> ToggleProvinceStatus(ProvinceModel province)
        {
            var provinceService = _serviceProvider.GetService<IProvinceService>();

            return await provinceService.ToggleStatus(_mapper.Map<Province>(province));
        }

        public async Task<int?> DeleteProvince(ProvinceModel province)
        {
            var provinceService = _serviceProvider.GetService<IProvinceService>();

            return await provinceService.Delete(_mapper.Map<Province>(province));
        }
    }
}
