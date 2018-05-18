using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;

namespace Hris.List.Business.Repositories
{
    public interface IGenderRepository
    {
        /// <summary>
        /// Save Gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        Task<int?> Save(Gender gender);

        /// <summary>
        /// Select Gender
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<Gender>> Select(Status? status);
    }
}
