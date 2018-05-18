using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Repositories;
using Hris.Common.Persistence.Transformations;
using Hris.Database;
using Microsoft.EntityFrameworkCore;

namespace Hris.Common.Persistence
{
    public class FormLanguageRepository: IFormLanguageRepository
    {
        private readonly HrisContext _dbContext;

        public FormLanguageRepository(HrisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int?> Save(FormLanguage formLanguage)
        {
            var language = await _dbContext.FormLanguages.FirstOrDefaultAsync(x => x.Id == formLanguage.Id);

            if (language == null)
            {
                language = formLanguage.Transform();
                await _dbContext.AddAsync(language);
            }
            else
            {
                language.UpdateValue(formLanguage);
                language.UpdatedAt = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();

            return language.Id;
        }

        public async Task<IEnumerable<FormLanguage>> Select(int? functionId, string functionKey, int? languageId)
        {
            var formLanguages = _dbContext.FormLanguages
                .Where(x =>
                    (x.FunctionId == functionId || x.FunctionKey == functionKey) && x.LanguageId == languageId)
                .Select(x => x.Transform());

            return await formLanguages.ToListAsync();
        }
    }
}
