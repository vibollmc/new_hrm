using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Database.Entities
{
    public class FunctionAction
    {
        public int? FunctionId { get; set; }
        public int? ActionId { get; set; }

        public Function Function { get; set; }
        public Action Action { get; set; }
    }
}
