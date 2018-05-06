using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hris.Database.Enums;

namespace Hris.Database.Entities
{
    public class Function : Base
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public Module Module { get; set; }
        [MaxLength(50)]
        public string Key { get; set; }
        [MaxLength(50)]
        public string Icon { get; set; }
        public Status Status { get; set; }
    }
}
