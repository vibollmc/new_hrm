using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hris.Database.Entities
{
    public class FormLanguage:Base
    {
        public int? FunctionId { get; set; }
        [MaxLength(50)]
        public string KeyFunction { get; set; }
        public int? LanguageId { get; set; }
        [MaxLength(50)]
        public string Key { get; set; }
        [MaxLength(500)]
        public string Value { get; set; }
    }
}
