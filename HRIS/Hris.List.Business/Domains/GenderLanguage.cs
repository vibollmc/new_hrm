using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.List.Business.Domains
{
    public class GenderLanguage
    {
        public GenderLanguage(int? genderId, int? languageId, string name)
        {
            GenderId = genderId;
            LanguageId = languageId;
            Name = name;
        }

        public int? GenderId { get; }
        public int? LanguageId { get; }
        public string Name { get; }
    }
}
