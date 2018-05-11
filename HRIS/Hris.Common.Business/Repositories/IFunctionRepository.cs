using System.Threading.Tasks;
using Hris.Common.Business.Domains;

namespace Hris.Common.Business.Repositories
{
    public interface IFunctionRepository
    {
        Task<int?> Save(Function function);
        Task<int?> SaveAction(Action action);
    }
}
