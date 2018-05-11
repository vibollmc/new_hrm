using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;
using Hris.Common.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hris.Common.Tests
{
    [TestClass]
    public class FunctionTest : BaseTest
    {
        [TestMethod]
        public async Task AddFunction()
        {
            var funcRepo = new FunctionRepository(DbContext);

            var id = await funcRepo.Save(new Function(null, "Đăng nhập", Module.Common, "login", null, 0, Status.Inactive));

            Assert.IsTrue(id != null);
        }
    }
}
