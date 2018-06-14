using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Repositories
{
    public interface IDistrictRepository
    {
        Task<int?> Save(District district);

        Task<IEnumerable<District>> Select();

        Task<IEnumerable<District>> Select(Status status);

        Task<int?> ToggleStatus(District district);

        Task<int?> Delete(District district);
    }
}