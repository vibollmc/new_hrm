using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.List.Api.Transformations;
using Hris.List.Business.Services.Interfaces;
using Hris.Shared.Enum;
using Hris.Shared.Gender;

namespace Hris.List.Api
{
    public class HrisListApi : IHrisListApi
    {
        private readonly IGenderService _genderService;

        public HrisListApi(IGenderService genderService)
        {
            _genderService = genderService;
        }

        #region gender
        public async Task<int?> SaveGender(GenderViewModel gender)
        {
            return await _genderService.Save(gender.Transform());
        }

        public async Task<IEnumerable<GenderViewModel>> SelectGender(Status? status)
        {
            var genders = await _genderService.Select(status?.Transform());

            return genders.Select(x => x.Transform());
        }

        public async Task<int?> ToggleGenderStatus(int? genderId)
        {
            return await _genderService.ToggleStatus(genderId);
        }

        public async Task<int?> DeleteGender(int? genderId)
        {
            return await _genderService.Delete(genderId);
        }
        #endregion gender
    }
}
