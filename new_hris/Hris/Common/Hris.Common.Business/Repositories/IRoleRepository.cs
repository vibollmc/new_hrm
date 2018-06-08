using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;

namespace Hris.Common.Business.Repositories
{
    public interface IRoleRepository
    {
        /// <summary>
        /// Get role by Id
        /// </summary>
        /// <param name="id">role Id</param>
        /// <returns>role</returns>
        Task<Role> Get(int? id);

        /// <summary>
        /// Get roles by status, status = null to return all available roles
        /// </summary>
        /// <param name="status">role status, status = null to return all available roles</param>
        /// <returns>available roles</returns>
        Task<IEnumerable<Role>> Get(Status? status);

        /// <summary>
        /// Save role, Id != 0 to update
        /// </summary>
        /// <param name="role">role</param>
        /// <returns></returns>
        Task<int?> Save(Role role);

        /// <summary>
        /// Delete role by Id
        /// </summary>
        /// <param name="id">Role Id</param>
        /// <returns></returns>
        Task Delete(int? id);

        /// <summary>
        /// Toggle role status
        /// </summary>
        /// <param name="id">Role Id</param>
        /// <returns></returns>
        Task ChangeStatus(int? id);
    }
}
