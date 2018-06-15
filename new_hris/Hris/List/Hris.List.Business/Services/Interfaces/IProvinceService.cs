using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Services.Interfaces
{
    public interface IProvinceService
    {
        Task<int?> Save(Province province);

        Task<IEnumerable<Province>> Select();

        Task<IEnumerable<Province>> Select(Status status);

        Task<int?> ToggleStatus(Province province);

        Task<int?> Delete(Province province);
    }
}
