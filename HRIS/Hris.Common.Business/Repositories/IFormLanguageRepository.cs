using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;

namespace Hris.Common.Business.Repositories
{
    public interface IFormLanguageRepository
    {
        /// <summary>
        /// Save form language
        /// </summary>
        /// <param name="formLanguage"></param>
        /// <returns></returns>
        Task<int?> Save(FormLanguage formLanguage);

        /// <summary>
        /// Select form language
        /// </summary>
        /// <param name="functionId"></param>
        /// <param name="functionKey"></param>
        /// <param name="languageId"></param>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        Task<IEnumerable<FormLanguage>> Select(int? functionId, string functionKey, int? languageId);
    }
}
