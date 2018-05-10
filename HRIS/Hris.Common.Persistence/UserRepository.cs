using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;
using Hris.Common.Business.Repositories;
using Hris.Common.Persistence.Transformations;
using Hris.Database;
using Microsoft.EntityFrameworkCore;

namespace Hris.Common.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly HrisContext _dbContext;

        public UserRepository(HrisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Get(string username, string password)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x =>
                x.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password == password.ToMd5Hash());

            return user.Transform();
        }

        public async Task<User> Get(int? id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x =>
                x.Id == id);

            return user.Transform();
        }

        public async Task<IEnumerable<User>> Get(Status? status)
        {
            var users = _dbContext.Users
                .Where(x => !x.DeletedAt.HasValue &&
                            (status == null || status != null && x.Status == status.Value.Transform()))
                .Select(x => x.Transform());

            return await users.ToListAsync();
        }

        public async Task Save(User user)
        {
            var userDb = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            if (userDb != null)
            {
                userDb.UpdateValue(user);
                userDb.UpdatedAt = DateTime.UtcNow;
            }
            else await _dbContext.Users.AddAsync(user.Transform());

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return;

            user.DeletedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeStatus(int? id)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null) return;

            user.UpdatedAt = DateTime.UtcNow;
            user.Status = user.Status == Database.Enums.Status.Active
                ? Database.Enums.Status.Inactive
                : Database.Enums.Status.Active;
            await _dbContext.SaveChangesAsync();
        }
    }
}
