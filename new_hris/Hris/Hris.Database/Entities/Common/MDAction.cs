using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hris.Database.Enums;

namespace Hris.Database.Entities.Common
{
    public class MDAction: Base
    {
        [MaxLength(50)]
        public string Key { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Event { get; set; }
        public int Order { get; set; }
        public MDStatus Status { get; set; }

        public ICollection<MDActionLanguage> ActionLanguages { get; set; }
        public ICollection<MDFunctionAction> FunctionActions { get; set; }
        public ICollection<MDRoleFunctionAction> RoleFunctionActions { get; set; }
    }
}
