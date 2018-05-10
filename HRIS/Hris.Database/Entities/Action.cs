using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hris.Database.Enums;

namespace Hris.Database.Entities
{
    public class Action: Base
    {
        [MaxLength(50)]
        public string Key { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Event { get; set; }
        public int Order { get; set; }
        public Status Status { get; set; }

        public ICollection<ActionLanguage> ActionLanguages { get; set; }
        public ICollection<FunctionAction> FunctionActions { get; set; }
        public ICollection<RoleFunctionAction> RoleFunctionActions { get; set; }
    }
}
