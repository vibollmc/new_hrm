using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Repositories
{
    public interface INationRepository
    {
        /// <summary>
        /// Save Nation
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        Task<int?> Save(Nation nation);

        /// <summary>
        /// Select Nation
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Nation>> Select();

        /// <summary>
        /// Select Nation
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<Nation>> Select(Status status);

        /// <summary>
        /// Toggle Nation status
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        Task<int?> ToggleStatus(Nation nation);

        /// <summary>
        /// Delete Nation
        /// </summary>
        /// <param name="nation"></param>
        /// <returns></returns>
        Task<int?> Delete(Nation nation);
    }
}
