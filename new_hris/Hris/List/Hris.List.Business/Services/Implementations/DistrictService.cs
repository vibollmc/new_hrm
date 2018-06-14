using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;
using Hris.List.Business.Repositories;
using Hris.List.Business.Services.Interfaces;

namespace Hris.List.Business.Services.Implementations
{
    public class DistrictService : IDistrictService
    {
        private readonly IDistrictRepository _districtRepository;

        public DistrictService(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }

        public async Task<int?> Save(District district)
        {
            return await _districtRepository.Save(district);
        }

        public async Task<IEnumerable<District>> Select()
        {
            return await _districtRepository.Select();
        }

        public async Task<IEnumerable<District>> Select(Status status)
        {
            return await _districtRepository.Select(status);
        }

        public async Task<int?> ToggleStatus(District district)
        {
            return await _districtRepository.ToggleStatus(district);
        }

        public async Task<int?> Delete(District district)
        {
            return await _districtRepository.Delete(district);
        }
    }
}