using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;
using Hris.Common.Business.Repositories;
using Hris.Common.Business.Services.Implementations;

namespace Hris.Common.Business.Services.Interfaces
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Get(string username, string password)
        {
            return await _userRepository.Get(username, password);
        }

        public async Task<User> Get(int? id)
        {
            return await _userRepository.Get(id);
        }

        public async Task<IEnumerable<User>> Get(Status? status)
        {
            return await _userRepository.Get(status);
        }

        public async Task<int?> Save(User user)
        {
            return await _userRepository.Save(user);
        }

        public async Task Delete(int? id)
        {
            await _userRepository.Delete(id);
        }

        public async Task ChangeStatus(int? id)
        {
            await _userRepository.ChangeStatus(id);
        }
    }
}
