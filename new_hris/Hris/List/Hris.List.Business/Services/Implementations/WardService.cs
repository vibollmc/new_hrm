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
    public class WardService : IWardService
    {
        private readonly IWardRepository _wardRepository;

        public WardService(IWardRepository wardRepository)
        {
            _wardRepository = wardRepository;
        }

        public async Task<int?> Save(Ward ward)
        {
            return await _wardRepository.Save(ward);
        }

        public async Task<IEnumerable<Ward>> Select()
        {
            return await _wardRepository.Select();
        }

        public async Task<IEnumerable<Ward>> Select(Status status)
        {
            return await _wardRepository.Select(status);
        }

        public async Task<int?> ToggleStatus(Ward ward)
        {
            return await _wardRepository.ToggleStatus(ward);
        }

        public async Task<int?> Delete(Ward ward)
        {
            return await _wardRepository.Delete(ward);
        }
    }
}
