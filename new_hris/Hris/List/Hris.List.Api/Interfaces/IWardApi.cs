using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.Ward;

namespace Hris.List.Api
{
    public partial interface IListApi
    {

        /// <summary>
        /// Save Ward
        /// </summary>
        /// <param name="ward"></param>
        /// <returns></returns>
        Task<int?> SaveWard(WardModel ward);

        /// <summary>
        /// Select Ward
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<WardModel>> SelectWard();

        /// <summary>
        /// Select Ward
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<WardModel>> SelectWard(Status status);

        /// <summary>
        /// Toggle Ward status
        /// </summary>
        /// <param name="ward"></param>
        /// <returns></returns>
        Task<int?> ToggleWardStatus(WardModel ward);

        /// <summary>
        /// Delete Ward
        /// </summary>
        /// <param name="ward"></param>
        /// <returns></returns>
        Task<int?> DeleteWard(WardModel ward);

    }
}
