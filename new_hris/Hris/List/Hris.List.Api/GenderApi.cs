using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.List.Api.Transformations;
using Hris.Shared.Enum;
using Hris.Shared.Gender;

namespace Hris.List.Api
{
    public partial class ListApi
    {
        public async Task<int?> SaveGender(GenderModel gender)
        {
            return await _genderService.Save(gender.Transform());
        }

        public async Task<IEnumerable<GenderModel>> SelectGender(Status? status)
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
    }
}
