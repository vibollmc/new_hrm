using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Shared.Enum;
using Hris.Shared.User;

namespace Hris.Common.Api
{
    public partial class CommonApi
    {
        public async Task<UserModel> GetUser(string username, string password)
        {
            var user = await _userService.Get(username, password);

            var userModel = _mapper.Map<User, UserModel>(user);

            return userModel;
        }

        public async Task<UserModel> GetUser(int? id)
        {
            var user = await _userService.Get(id);

            return _mapper.Map<User, UserModel>(user);
        }

        public async Task<IEnumerable<UserModel>> GetUser(Status? status)
        {
            var users = await _userService.Get(_mapper.Map<Status?, Business.Enums.Status?>(status));

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);
        }

        public async Task<int?> SaveUser(UserModel user)
        {
            return await _userService.Save(_mapper.Map<UserModel, User>(user));
        }

        public async Task DeleteUser(int? id)
        {
            await _userService.Delete(id);
        }

        public async Task ChangeUserStatus(int? id)
        {
            await _userService.ChangeStatus(id);
        }
    }
}
