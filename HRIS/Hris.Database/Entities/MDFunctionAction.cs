using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Database.Entities
{
    public class MDFunctionAction
    {
        public int? FunctionId { get; set; }
        public int? ActionId { get; set; }

        public MDFunction Function { get; set; }
        public MDAction Action { get; set; }
    }
}
