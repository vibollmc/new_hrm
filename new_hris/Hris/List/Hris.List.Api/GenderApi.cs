using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.Shared.Enum;
using Hris.Shared.Gender;

namespace Hris.List.Api
{
    public partial class ListApi
    {
        public async Task<int?> SaveGender(GenderModel gender)
        {
            return await _genderService.Save(_mapper.Map<Gender>(gender));
        }

        public async Task<IEnumerable<GenderModel>> SelectGender()
        {
            var genders = await _genderService.Select();

            return _mapper.Map<IEnumerable<GenderModel>>(genders);
        }

        public async Task<IEnumerable<GenderModel>> SelectGender(Status status)
        {
            var genders = await _genderService.Select(_mapper.Map<Business.Enums.Status>(status));

            return _mapper.Map<IEnumerable<GenderModel>>(genders);
        }

        public async Task<int?> ToggleGenderStatus(GenderModel gender)
        {
            return await _genderService.ToggleStatus(_mapper.Map<Gender>(gender));
        }

        public async Task<int?> DeleteGender(GenderModel gender)
        {
            return await _genderService.Delete(_mapper.Map<Gender>(gender));
        }
    }
}
