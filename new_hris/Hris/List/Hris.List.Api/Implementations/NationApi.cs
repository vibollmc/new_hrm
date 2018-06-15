using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Services.Interfaces;
using Hris.Shared.Enum;
using Hris.Shared.Nation;
using Microsoft.Extensions.DependencyInjection;

namespace Hris.List.Api
{
    public partial class ListApi
    {
        public async Task<int?> SaveNation(NationModel nation)
        {
            var nationService = _serviceProvider.GetService<INationService>();

            return await nationService.Save(_mapper.Map<Nation>(nation));
        }

        public async Task<IEnumerable<NationModel>> SelectNation()
        {
            var nationService = _serviceProvider.GetService<INationService>();

            var nations = await nationService.Select();

            return _mapper.Map<IEnumerable<NationModel>>(nations);
        }

        public async Task<IEnumerable<NationModel>> SelectNation(Status status)
        {
            var nationService = _serviceProvider.GetService<INationService>();

            var nations = await nationService.Select(_mapper.Map<Business.Enums.Status>(status));

            return _mapper.Map<IEnumerable<NationModel>>(nations);
        }

        public async Task<int?> ToggleNationStatus(NationModel nation)
        {
            var nationService = _serviceProvider.GetService<INationService>();

            return await nationService.ToggleStatus(_mapper.Map<Nation>(nation));
        }

        public async Task<int?> DeleteNation(NationModel nation)
        {
            var nationService = _serviceProvider.GetService<INationService>();

            return await nationService.Delete(_mapper.Map<Nation>(nation));
        }
    }
}
