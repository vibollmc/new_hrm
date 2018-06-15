using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;
using Hris.List.Business.Repositories;
using Hris.List.Business.Services.Interfaces;

namespace Hris.List.Business.Services.Implementations
{
    public class ProvinceService : IProvinceService
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceService(IProvinceRepository provinceRepository)
        {
            _provinceRepository = provinceRepository;
        }

        public async Task<int?> Save(Province province)
        {
            return await _provinceRepository.Save(province);
        }

        public async Task<IEnumerable<Province>> Select()
        {
            return await _provinceRepository.Select();
        }

        public async Task<IEnumerable<Province>> Select(Status status)
        {
            return await _provinceRepository.Select(status);
        }

        public async Task<int?> ToggleStatus(Province province)
        {
            return await _provinceRepository.ToggleStatus(province);
        }

        public async Task<int?> Delete(Province province)
        {
            return await _provinceRepository.Delete(province);
        }
    }
}
