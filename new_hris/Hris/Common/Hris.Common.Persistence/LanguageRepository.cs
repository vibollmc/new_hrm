﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;
using Hris.Common.Business.Repositories;
using Hris.Common.Persistence.Transformations;
using Hris.Database;
using Hris.Database.Enums;
using Microsoft.EntityFrameworkCore;

namespace Hris.Common.Persistence
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly HrisContext _dbContext;

        public LanguageRepository(HrisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Language>> Get(Status? status)
        {
            var languages = _dbContext.Languages.Where(x =>
                    !x.DeletedAt.HasValue &&
                    (status == null ||
                     status != null && x.Status == status.Value.Transform()))
                .Select(x => x.Transform());

            return await languages.ToListAsync();
        }

        public async Task<int?> Save(Language language)
        {
            var item = await _dbContext.Languages.FirstOrDefaultAsync(x => x.Id == language.Id);

            if (item != null)
            {
                item.UpdateValue(language);
                item.UpdatedAt = DateTime.UtcNow;
            }
            else
            {
                item = language.Transform();
                await _dbContext.AddAsync(item);
            }

            await _dbContext.SaveChangesAsync();

            return item.Id;
        }

        public async Task Delete(int? id)
        {
            var language = await _dbContext.Languages.FirstOrDefaultAsync(x => x.Id == id);
            if (language == null) return;

            language.DeletedAt = DateTime.UtcNow;
            await _dbContext.SaveChangesAsync();
        }

        public async Task ChangeStatus(int? id)
        {
            var language = await _dbContext.Languages.FirstOrDefaultAsync(x => x.Id == id);
            if (language == null) return;

            language.Status = language.Status == MDStatus.Active
                ? MDStatus.Inactive
                : MDStatus.Active;
            language.UpdatedAt = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }
    }
}
