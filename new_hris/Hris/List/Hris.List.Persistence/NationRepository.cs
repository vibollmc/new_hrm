using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hris.Database;
using Hris.Database.Entities.List;
using Hris.Database.Enums;
using Hris.List.Business.Domains;
using Hris.List.Business.Enums;
using Hris.List.Business.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hris.List.Persistence
{
    public class NationRepository : INationRepository
    {
        private readonly HrisContext _dbContext;
        private readonly IMapper _mapper;

        public NationRepository(HrisContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int?> Save(Nation nation)
        {
            if (nation == null) return null;

            var nationDb = await _dbContext.Nations.FirstOrDefaultAsync(x => x.Id == nation.Id);

            if (nationDb == null)
            {
                nationDb = _mapper.Map<MDNation>(nation);
                await _dbContext.Nations.AddAsync(nationDb);
            }
            else
            {
                nationDb.Name = nation.Name;
                nationDb.NameEn = nation.NameEn;
                nationDb.Status = _mapper.Map<MDStatus>(nation.Status);
                nationDb.UpdatedBy = nation.UpdatedBy;
                nationDb.UpdatedAt = DateTime.UtcNow;
            }
            await _dbContext.SaveChangesAsync();

            return nationDb.Id;
        }

        public async Task<IEnumerable<Nation>> Select()
        {
            var nations = _dbContext.Nations
                .Where(x => !x.DeletedAt.HasValue).Select(x => _mapper.Map<Nation>(x));

            return await nations.ToListAsync();
        }

        public async Task<IEnumerable<Nation>> Select(Status status)
        {
            var nations = _dbContext.Nations
                .Where(x => x.Status == _mapper.Map<MDStatus>(status) && !x.DeletedAt.HasValue)
                .Select(x => _mapper.Map<Nation>(x));

            return await nations.ToListAsync();
        }

        public async Task<int?> ToggleStatus(Nation nation)
        {
            var nationdb = await _dbContext.Nations.FirstOrDefaultAsync(x => x.Id == nation.Id);
            if (nationdb == null) return 0;

            nationdb.Status = nationdb.Status == MDStatus.Active ? MDStatus.Inactive : MDStatus.Active;
            nationdb.UpdatedAt = DateTime.UtcNow;
            nationdb.UpdatedBy = nation.UpdatedBy;

            await _dbContext.SaveChangesAsync();

            return nationdb.Id;
        }

        public async Task<int?> Delete(Nation nation)
        {
            var nationDb = await _dbContext.Nations.FirstOrDefaultAsync(x => x.Id == nation.Id);
            if (nationDb == null) return 0;

            nationDb.DeletedAt = DateTime.UtcNow;
            nationDb.DeletedBy = nation.DeletedBy;

            await _dbContext.SaveChangesAsync();

            return nationDb.Id;
        }
    }
}
