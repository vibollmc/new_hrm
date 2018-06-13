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
    public class UserTest : BaseTest
    {
        [TestMethod]
        public async Task AddUser()
        {
            var userRepository = new UserRepository(DbContext);

            var id = await userRepository.Save(new User(null, "admin", "admin", "Administrator", "admin.hris@gmail.com", null,
                null, null, null, null, null, null, null, null, Status.Active));

            Assert.IsTrue(id != null);
        }
    }
}
