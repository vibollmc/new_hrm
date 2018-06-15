using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Services.Interfaces;
using Hris.Shared.Enum;
using Hris.Shared.Ward;
using Microsoft.Extensions.DependencyInjection;

namespace Hris.List.Api
{
    public partial class ListApi
    {
        public async Task<int?> SaveWard(WardModel ward)
        {
            var wardService = _serviceProvider.GetService<IWardService>();

            return await wardService.Save(_mapper.Map<Ward>(ward));
        }

        public async Task<IEnumerable<WardModel>> SelectWard()
        {
            var wardService = _serviceProvider.GetService<IWardService>();

            var wards = await wardService.Select();

            return _mapper.Map<IEnumerable<WardModel>>(wards);
        }

        public async Task<IEnumerable<WardModel>> SelectWard(Status status)
        {
            var wardService = _serviceProvider.GetService<IWardService>();

            var wards = await wardService.Select(_mapper.Map<Business.Enums.Status>(status));

            return _mapper.Map<IEnumerable<WardModel>>(wards);
        }

        public async Task<int?> ToggleWardStatus(WardModel ward)
        {
            var wardService = _serviceProvider.GetService<IWardService>();

            return await wardService.ToggleStatus(_mapper.Map<Ward>(ward));
        }

        public async Task<int?> DeleteWard(WardModel ward)
        {
            var wardService = _serviceProvider.GetService<IWardService>();

            return await wardService.Delete(_mapper.Map<Ward>(ward));
        }
    }
}
