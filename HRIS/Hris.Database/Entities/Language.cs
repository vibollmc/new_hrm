using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hris.Database.Enums;

namespace Hris.Database.Entities
{
    public class Language : Base
    {
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public Status Status { get; set; }
    }
}
