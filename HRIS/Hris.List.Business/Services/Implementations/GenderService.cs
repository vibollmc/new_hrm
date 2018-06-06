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
    public class GenderService : IGenderService
    {
        private readonly IGenderRepository _genderRepository;

        public GenderService(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<int?> Save(Gender gender)
        {
            return await _genderRepository.Save(gender);
        }

        public async Task<IEnumerable<Gender>> Select(Status? status)
        {
            return await _genderRepository.Select(status);
        }

        public async Task<int?> ToggleStatus(int? genderId)
        {
            return await _genderRepository.ToggleStatus(genderId);
        }

        public async Task<int?> Delete(int? genderId)
        {
            return await _genderRepository.Delete(genderId);
        }
    }
}
