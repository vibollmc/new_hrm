using System.ComponentModel.DataAnnotations;

namespace Hris.Database.Entities.Common
{
    public class MDFormLanguage:Base
    {
        public int? FunctionId { get; set; }
        [MaxLength(50)]
        public string FunctionKey { get; set; }
        public int? LanguageId { get; set; }
        [MaxLength(50)]
        public string Key { get; set; }
        [MaxLength(500)]
        public string Value { get; set; }

        public MDFunction Function { get; set; }
        public MDLanguage Language { get; set; }
    }
}
