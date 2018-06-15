using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Services.Interfaces;
using Hris.Shared.Enum;
using Hris.Shared.Gender;
using Microsoft.Extensions.DependencyInjection;

namespace Hris.List.Api
{
    public partial class ListApi
    {
        public async Task<int?> SaveGender(GenderModel gender)
        {
            var genderService = _serviceProvider.GetService<IGenderService>();

            return await genderService.Save(_mapper.Map<Gender>(gender));
        }

        public async Task<IEnumerable<GenderModel>> SelectGender()
        {
            var genderService = _serviceProvider.GetService<IGenderService>();

            var genders = await genderService.Select();

            return _mapper.Map<IEnumerable<GenderModel>>(genders);
        }

        public async Task<IEnumerable<GenderModel>> SelectGender(Status status)
        {
            var genderService = _serviceProvider.GetService<IGenderService>();

            var genders = await genderService.Select(_mapper.Map<Business.Enums.Status>(status));

            return _mapper.Map<IEnumerable<GenderModel>>(genders);
        }

        public async Task<int?> ToggleGenderStatus(GenderModel gender)
        {
            var genderService = _serviceProvider.GetService<IGenderService>();

            return await genderService.ToggleStatus(_mapper.Map<Gender>(gender));
        }

        public async Task<int?> DeleteGender(GenderModel gender)
        {
            var genderService = _serviceProvider.GetService<IGenderService>();

            return await genderService.Delete(_mapper.Map<Gender>(gender));
        }
    }
}
