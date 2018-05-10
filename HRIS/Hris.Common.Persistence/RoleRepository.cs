using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;
using Hris.Common.Business.Repositories;
using Hris.Common.Persistence.Transformations;
using Hris.Database;
using Microsoft.EntityFrameworkCore;

namespace Hris.Common.Persistence
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HrisContext _dbContext;

        public RoleRepository(HrisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Role> Get(int? id)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);

            return role.Transform();
        }

        public async Task<IEnumerable<Role>> Get(Status? status)
        {
            var roles = _dbContext.Roles
                .Where(x =>
                    !x.DeletedAt.HasValue && (status == null ||
                                              status != null &&
                                              x.Status == status.Value.Transform()))
                .Select(x => x.Transform());

            return await roles.ToListAsync();
        }

        public async Task Save(Role role)
        {
            var item = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == role.Id);

            if (item != null)
            {
                item.UpdateValue(role);
                item.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                await _dbContext.AddAsync(role.Transform());
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int? id)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null) return;
            
            role.DeletedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeStatus(int? id)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
            if (role == null) return;

            role.Status = role.Status == Database.Enums.Status.Active
                ? Database.Enums.Status.Inactive
                : Database.Enums.Status.Active;
            await _dbContext.SaveChangesAsync();
        }
    }
}
