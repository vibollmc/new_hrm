using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Services.Interfaces
{
    public interface ICountryService
    {
        Task<int?> Save(Country country);

        Task<IEnumerable<Country>> Select();

        Task<IEnumerable<Country>> Select(Status status);

        Task<int?> ToggleStatus(Country country);

        Task<int?> Delete(Country country);
    }
}