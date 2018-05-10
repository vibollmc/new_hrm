using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Database.Entities
{
    public class MDRoleFunctionAction
    {
        public int? RoleId { get; set; }
        public int? FunctionId { get; set; }
        public int? ActionId { get; set; }

        public MDRole Role { get; set; }
        public MDFunction Function { get; set; }
        public MDAction Action { get; set; }
    }
}
