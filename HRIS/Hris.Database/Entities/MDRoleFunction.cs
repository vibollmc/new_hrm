using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Database.Entities
{
    public class MDRoleFunction
    {
        public int? RoleId { get; set; }
        public int? FunctionId { get; set; }
        
        public MDRole Role { get; set; }
        public MDFunction Function { get; set; }
    }
}
