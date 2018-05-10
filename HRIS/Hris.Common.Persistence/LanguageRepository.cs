using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;
using Hris.Common.Business.Repositories;

namespace Hris.Common.Persistence
{
    public class LanguageRepository : ILanguageRepository
    {
        public Task<IEnumerable<Language>> Get(Status? status)
        {
            throw new NotImplementedException();
        }
    }
}
