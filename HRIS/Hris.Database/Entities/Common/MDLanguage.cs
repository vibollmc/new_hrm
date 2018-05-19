using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hris.Database.Enums;

namespace Hris.Database.Entities.Common
{
    public class MDLanguage : Base
    {
        [MaxLength(10)]
        public string Code { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public bool IsDefault { get; set; }
        public MDStatus Status { get; set; }

        public ICollection<MDActionLanguage> ActionLanguages { get; set; }
        public ICollection<MDFormLanguage> FormLanguages { get; set; }
        public ICollection<MDFunctionLanguage> FunctionLanguages { get; set; }
    }
}
