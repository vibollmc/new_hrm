using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hris.Database.Enums;

namespace Hris.Database.Entities
{
    public class Role : Base
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public Status Status { get; set; }

        public ICollection<RoleFunction> RoleFunctions { get; set; }
        public ICollection<RoleFunctionAction> RoleFunctionActions { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
