using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Services.Interfaces
{
    public interface IWardService
    {
        Task<int?> Save(Ward ward);

        Task<IEnumerable<Ward>> Select();

        Task<IEnumerable<Ward>> Select(Status status);

        Task<int?> ToggleStatus(Ward ward);

        Task<int?> Delete(Ward ward);
    }
}
