﻿using System.Threading.Tasks;
using Hris.Common.Business.Domains;
using Hris.Common.Business.Enums;
using Hris.Common.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hris.Database;
using Microsoft.EntityFrameworkCore;

namespace Hris.Common.Tests
{
    [TestClass]
    public class LanguageTest : BaseTest
    {
        [TestMethod]
        public async Task AddLanguage()
        {
            var languageRepository = new LanguageRepository(DbContext);

            var id1 = await languageRepository.Save(new Language(null, "VN", "Tiếng Việt", true, Status.Active));
            var id2 = await languageRepository.Save(new Language(null, "EN", "English", true, Status.Active));

            Assert.IsTrue(id1 != null && id2 != null);
        }
    }
}
