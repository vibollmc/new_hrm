using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;

namespace Hris.Common.Business.Repositories
{
    public interface ILanguageRepository
    {
        /// <summary>
        /// Get available languagues
        /// </summary>
        /// <param name="status">language status. status = null to get all status</param>
        /// <returns>Available languagues</returns>
        Task<IEnumerable<Language>> Get(Status? status);

        /// <summary>
        /// Save language
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        Task<int?> Save(Language language);

        /// <summary>
        /// Delete language
        /// </summary>
        /// <param name="id">Language Id</param>
        /// <returns></returns>
        Task Delete(int? id);

        /// <summary>
        /// Toggle language status
        /// </summary>
        /// <param name="id">Language Id</param>
        /// <returns></returns>
        Task ChangeStatus(int? id);
    }
}
