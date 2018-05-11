using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;

namespace Hris.Common.Business.Repositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get user by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>user</returns>
        Task<User> Get(string username, string password);
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> Get(int? id);
        /// <summary>
        /// Get users by status, status = null to get all available users
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<User>> Get(Status? status);
        /// <summary>
        /// Save user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<int?> Save(User user);
        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int? id);
        /// <summary>
        /// Toggle user status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task ChangeStatus(int? id);
    }
}
