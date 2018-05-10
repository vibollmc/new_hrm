using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Database.Entities
{
    public class FunctionLanguage
    {
        public int? FunctionId { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }

        public Function Function { get; set; }
        public Language Language { get; set; }
    }
}
