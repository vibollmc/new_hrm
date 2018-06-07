using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.Database;
using Hris.Database.Enums;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;
using Hris.List.Business.Repositories;
using Hris.List.Persistence.Transformations;
using Microsoft.EntityFrameworkCore;

namespace Hris.List.Persistence
{
    public class GenderRepository: IGenderRepository
    {
        private readonly HrisContext _dbContext;

        public GenderRepository(HrisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int?> Save(Gender gender)
        {
            if (gender == null) return null;

            var genderDb = await _dbContext.Genders.FirstOrDefaultAsync(x => x.Id == gender.Id);

            if (genderDb == null)
            {
                genderDb = gender.Transform();
                await _dbContext.Genders.AddAsync(genderDb);
            }
            else
            {
                genderDb.UpdateValue(gender);
                genderDb.UpdatedAt = DateTime.UtcNow;
            }
            await _dbContext.SaveChangesAsync();

            return genderDb.Id;
        }

        public async Task<IEnumerable<Gender>> Select(Status? status)
        {
            var genders = _dbContext.Genders
                .Where(x => (status == null || x.Status == status.Value.Transform()) && !x.DeletedAt.HasValue)
                .Select(x => x.Transform());

            return await genders.ToListAsync();
        }

        public async Task<int?> ToggleStatus(int? genderId)
        {
            var gender = await _dbContext.Genders.FirstOrDefaultAsync(x=> x.Id == genderId);
            if (gender == null) return 0;

            gender.Status = gender.Status == MDStatus.Active ? MDStatus.Inactive : MDStatus.Active;
            gender.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return genderId;
        }

        public async Task<int?> Delete(int? genderId)
        {
            var gender = await _dbContext.Genders.FirstOrDefaultAsync(x => x.Id == genderId);
            if (gender == null) return 0;

            gender.DeletedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();

            return genderId;
        }
    }
}
