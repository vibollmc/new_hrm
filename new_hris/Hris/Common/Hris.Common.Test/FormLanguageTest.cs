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
    public class FormLanguageTest:BaseTest
    {
        private const int VietnameseLanguageId = 1;
        private const int EnglishLanguageId = 2;

        [TestMethod]
        public async Task AddFormLoginLanguage()
        {
            var repo = new FormLanguageRepository(DbContext);

            const int loginFunctionId = 1;
            const string loginFunctionKey = "login";

            await repo.Save(new FormLanguage(null, loginFunctionId, loginFunctionKey, VietnameseLanguageId, "USERNAME", "Tên đăng nhập"));
            await repo.Save(new FormLanguage(null, loginFunctionId, loginFunctionKey, VietnameseLanguageId, "PASSWORD", "Mật khẩu"));
            await repo.Save(new FormLanguage(null, loginFunctionId, loginFunctionKey, VietnameseLanguageId, "LOGIN_FAILED", "Tên đăng nhập hoặc mật khẩu không chính xác"));

            await repo.Save(new FormLanguage(null, loginFunctionId, loginFunctionKey, EnglishLanguageId, "USERNAME", "Username"));
            await repo.Save(new FormLanguage(null, loginFunctionId, loginFunctionKey, EnglishLanguageId, "PASSWORD", "Password"));
            await repo.Save(new FormLanguage(null, loginFunctionId, loginFunctionKey, EnglishLanguageId, "LOGIN_FAILED", "The username or password is incorrect"));

            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task AddFormGenderLanguage()
        {
            var repo = new FormLanguageRepository(DbContext);

            const int genderFunctionId = 2;
            const string genderFunctionKey = "gender";

            await repo.Save(new FormLanguage(null, genderFunctionId, genderFunctionKey, VietnameseLanguageId, "NAME", "Giới tính"));
            await repo.Save(new FormLanguage(null, genderFunctionId, genderFunctionKey, VietnameseLanguageId, "STATUS", "Trạng thái"));
            await repo.Save(new FormLanguage(null, genderFunctionId, genderFunctionKey, VietnameseLanguageId, "CREATED_AT", "Ngày tạo"));
            await repo.Save(new FormLanguage(null, genderFunctionId, genderFunctionKey, VietnameseLanguageId, "UPDATED_AT", "Ngày cập nhật"));

        }
    }
}
