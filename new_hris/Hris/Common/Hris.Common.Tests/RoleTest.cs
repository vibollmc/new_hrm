using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;
using Hris.Common.Persistence;
using Hris.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hris.Common.Tests
{
    [TestClass]
    public class RoleTest: BaseTest
    {
        [TestMethod]
        public async Task AddRole()
        {
            var roleRepo = new RoleRepository(DbContext);

            var id = await roleRepo.Save(new Role(null, "Administrators", Status.Active));
            
            Assert.IsTrue(id != null);
        }
    }
}
