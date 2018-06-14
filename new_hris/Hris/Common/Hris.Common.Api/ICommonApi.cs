using System.Collections.Generic;
using System.Threading.Tasks;
using Hris.Shared.Enum;
using Hris.Shared.User;

namespace Hris.Common.Api
{
    public interface ICommonApi
    {
        #region user

        /// <summary>
        /// Get user by username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>user</returns>
        Task<UserModel> GetUser(string username, string password);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserModel> GetUser(int? id);

        /// <summary>
        /// Get users by status, status = null to get all available users
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<UserModel>> GetUser(Status? status);

        /// <summary>
        /// Save user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<int?> SaveUser(UserModel user);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteUser(int? id);

        /// <summary>
        /// Toggle user status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task ChangeUserStatus(int? id);

        #endregion
    }
}
