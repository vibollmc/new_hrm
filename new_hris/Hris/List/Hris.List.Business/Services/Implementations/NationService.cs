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
    public class NationService : INationService
    {
        private readonly INationRepository _nationRepository;

        public NationService(INationRepository nationRepository)
        {
            _nationRepository = nationRepository;
        }

        public async Task<int?> Save(Nation nation)
        {
            return await _nationRepository.Save(nation);
        }

        public async Task<IEnumerable<Nation>> Select()
        {
            return await _nationRepository.Select();
        }

        public async Task<IEnumerable<Nation>> Select(Status status)
        {
            return await _nationRepository.Select(status);
        }

        public async Task<int?> ToggleStatus(Nation nation)
        {
            return await _nationRepository.ToggleStatus(nation);
        }

        public async Task<int?> Delete(Nation nation)
        {
            return await _nationRepository.Delete(nation);
        }
    }
}
