using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Database.Entities
{
    public class ActionLanguage
    {
        public int? ActionId { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }

        public Action Action { get; set; }
        public Language Language { get; set; }
    }
}
