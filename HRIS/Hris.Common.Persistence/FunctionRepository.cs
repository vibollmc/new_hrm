using System;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Repositories;
using Hris.Common.Persistence.Transformations;
using Hris.Database;
using Microsoft.EntityFrameworkCore;

namespace Hris.Common.Persistence
{
    public class FunctionRepository:IFunctionRepository
    {
        private readonly HrisContext _dbContext;

        public FunctionRepository(HrisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int?> Save(Function function)
        {
            var func = await _dbContext.Functions.FirstOrDefaultAsync(x => x.Id == function.Id);
            if (func == null)
            {
                func = function.Transform();
                await _dbContext.Functions.AddAsync(func);
            }
            else
            {
                func.UpdateValue(function);
                func.UpdatedAt = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();

            return func.Id;
        }

        public async Task<int?> SaveAction(Business.Domains.Action action)
        {
            var act = await _dbContext.Actions.FirstOrDefaultAsync(x => x.Id == action.Id);
            if (act == null)
            {
                act = action.Transform();
                await _dbContext.Actions.AddAsync(act);
            }
            else
            {
                act.UpdateValue(action);
                act.UpdatedAt = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();

            return act.Id;
        }
    }
}
