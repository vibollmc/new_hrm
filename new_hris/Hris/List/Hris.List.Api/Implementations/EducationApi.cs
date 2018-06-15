using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Services.Interfaces;
using Hris.Shared.Enum;
using Hris.Shared.Education;
using Microsoft.Extensions.DependencyInjection;

namespace Hris.List.Api
{
    public partial class ListApi
    {
        public async Task<int?> SaveEducation(EducationModel education)
        {
            var educationService = _serviceProvider.GetService<IEducationService>();

            return await educationService.Save(_mapper.Map<Education>(education));
        }

        public async Task<IEnumerable<EducationModel>> SelectEducation()
        {
            var educationService = _serviceProvider.GetService<IEducationService>();

            var educations = await educationService.Select();

            return _mapper.Map<IEnumerable<EducationModel>>(educations);
        }

        public async Task<IEnumerable<EducationModel>> SelectEducation(Status status)
        {
            var educationService = _serviceProvider.GetService<IEducationService>();

            var educations = await educationService.Select(_mapper.Map<Business.Enums.Status>(status));

            return _mapper.Map<IEnumerable<EducationModel>>(educations);
        }

        public async Task<int?> ToggleEducationStatus(EducationModel education)
        {
            var educationService = _serviceProvider.GetService<IEducationService>();

            return await educationService.ToggleStatus(_mapper.Map<Education>(education));
        }

        public async Task<int?> DeleteEducation(EducationModel education)
        {
            var educationService = _serviceProvider.GetService<IEducationService>();

            return await educationService.Delete(_mapper.Map<Education>(education));
        }
    }
}
