using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hris.Database.Enums;

namespace Hris.Database.Entities
{
    public class MDFunction : Base
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public MDModule Module { get; set; }
        [MaxLength(50)]
        public string Key { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        public int OrderIndex { get; set; }
        public MDStatus Status { get; set; }

        public ICollection<MDFormLanguage> FormLanguages { get; set; }
        public ICollection<MDFunctionAction> FunctionActions { get; set; }
        public ICollection<MDFunctionLanguage> FunctionLanguages { get; set; }
        public ICollection<MDRoleFunction> RoleFunctions { get; set; }
        public ICollection<MDRoleFunctionAction> RoleFunctionActions { get; set; }
    }
}
