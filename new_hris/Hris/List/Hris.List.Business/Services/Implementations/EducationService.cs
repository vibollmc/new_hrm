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
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepository;

        public EducationService(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public async Task<int?> Save(Education education)
        {
            return await _educationRepository.Save(education);
        }

        public async Task<IEnumerable<Education>> Select()
        {
            return await _educationRepository.Select();
        }

        public async Task<IEnumerable<Education>> Select(Status status)
        {
            return await _educationRepository.Select(status);
        }

        public async Task<int?> ToggleStatus(Education education)
        {
            return await _educationRepository.ToggleStatus(education);
        }

        public async Task<int?> Delete(Education education)
        {
            return await _educationRepository.Delete(education);
        }
    }
}
