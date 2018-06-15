using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Repositories
{
    public interface IEducationRepository
    {
        Task<int?> Save(Education education);

        Task<IEnumerable<Education>> Select();

        Task<IEnumerable<Education>> Select(Status status);

        Task<int?> ToggleStatus(Education education);

        Task<int?> Delete(Education education);
    }
}