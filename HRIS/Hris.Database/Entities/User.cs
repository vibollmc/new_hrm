using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Hris.Database.Enums;

namespace Hris.Database.Entities
{
    public class User : Base
    {
        [MaxLength(50)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string Fullname { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(10)]
        public string Language { get; set; }
        public int? TimeZone { get; set; }
        [MaxLength(20)]
        public string DateFormat { get; set; }
        [MaxLength(10)]
        public string TimeFormat { get; set; }
        [MaxLength(1)]
        public string DecimalSymbol { get; set; }
        [MaxLength(1)]
        public string DigitGroupingSymbol { get; set; }
        public DateTime? LastLogin { get; set; }
        [MaxLength(50)]
        public string IpAddress { get; set; }
        public Status Status { get; set; }
    }
}
