﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Database.Entities
{
    public class RoleFunction
    {
        public int? RoleId { get; set; }
        public int? FunctionId { get; set; }
        
        public Role Role { get; set; }
        public Function Function { get; set; }
    }
}
