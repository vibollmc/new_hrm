using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hris.Database.Enums;

namespace Hris.Database.Entities.Common
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
