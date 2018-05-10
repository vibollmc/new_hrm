using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Database.Entities
{
    public class MDActionLanguage
    {
        public int? ActionId { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }

        public MDAction Action { get; set; }
        public MDLanguage Language { get; set; }
    }
}
