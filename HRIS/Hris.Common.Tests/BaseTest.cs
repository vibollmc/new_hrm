using System;
using System.Collections.Generic;
using System.Text;
using Hris.Database;
using Microsoft.EntityFrameworkCore;

namespace Hris.Common.Tests
{
    public class BaseTest
    {
        protected readonly HrisContext DbContext;

        public BaseTest()
        {
            var options = new DbContextOptionsBuilder<HrisContext>()
                .UseSqlServer(Constant.ConnectionString)
                .Options;

            DbContext = new HrisContext(options);
        }
    }
}
