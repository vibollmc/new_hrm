using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hris.Database.Enums;

namespace Hris.Database.Entities
{
    public class MDRole : Base
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public MDStatus Status { get; set; }

        public ICollection<MDRoleFunction> RoleFunctions { get; set; }
        public ICollection<MDRoleFunctionAction> RoleFunctionActions { get; set; }
        public ICollection<MDUserRole> UserRoles { get; set; }
    }
}
