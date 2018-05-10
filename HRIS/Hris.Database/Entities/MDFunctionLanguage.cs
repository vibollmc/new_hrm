using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Database.Entities
{
    public class MDFunctionLanguage
    {
        public int? FunctionId { get; set; }
        public int? LanguageId { get; set; }
        public string Name { get; set; }

        public MDFunction Function { get; set; }
        public MDLanguage Language { get; set; }
    }
}
