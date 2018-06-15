using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Services.Interfaces;
using Hris.Shared.Enum;
using Hris.Shared.District;
using Microsoft.Extensions.DependencyInjection;

namespace Hris.List.Api
{
    public partial class ListApi
    {
        public async Task<int?> SaveDistrict(DistrictModel district)
        {
            var districtService = _serviceProvider.GetService<IDistrictService>();

            return await districtService.Save(_mapper.Map<District>(district));
        }

        public async Task<IEnumerable<DistrictModel>> SelectDistrict()
        {
            var districtService = _serviceProvider.GetService<IDistrictService>();

            var districts = await districtService.Select();

            return _mapper.Map<IEnumerable<DistrictModel>>(districts);
        }

        public async Task<IEnumerable<DistrictModel>> SelectDistrict(Status status)
        {
            var districtService = _serviceProvider.GetService<IDistrictService>();

            var districts = await districtService.Select(_mapper.Map<Business.Enums.Status>(status));

            return _mapper.Map<IEnumerable<DistrictModel>>(districts);
        }

        public async Task<int?> ToggleDistrictStatus(DistrictModel district)
        {
            var districtService = _serviceProvider.GetService<IDistrictService>();

            return await districtService.ToggleStatus(_mapper.Map<District>(district));
        }

        public async Task<int?> DeleteDistrict(DistrictModel district)
        {
            var districtService = _serviceProvider.GetService<IDistrictService>();

            return await districtService.Delete(_mapper.Map<District>(district));
        }
    }
}
