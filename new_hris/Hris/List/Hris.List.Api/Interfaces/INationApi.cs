using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.Nation;

namespace Hris.List.Api
{
    public partial interface IListApi
    {

        /// <summary>
        /// Save Nation
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        Task<int?> SaveNation(NationModel nation);

        /// <summary>
        /// Select Nation
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<NationModel>> SelectNation();

        /// <summary>
        /// Select Nation
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<NationModel>> SelectNation(Status status);

        /// <summary>
        /// Toggle Nation status
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        Task<int?> ToggleNationStatus(NationModel nation);

        /// <summary>
        /// Delete Nation
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        Task<int?> DeleteNation(NationModel nation);

    }
}
