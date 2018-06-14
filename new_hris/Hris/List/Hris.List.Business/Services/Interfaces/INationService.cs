using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Services.Interfaces
{
    public interface INationService
    {
        Task<int?> Save(Nation nation);

        Task<IEnumerable<Nation>> Select();

        Task<IEnumerable<Nation>> Select(Status status);

        Task<int?> ToggleStatus(Nation nation);

        Task<int?> Delete(Nation nation);
    }
}
