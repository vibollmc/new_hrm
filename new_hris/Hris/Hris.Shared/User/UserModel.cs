using System;
using System.Collections.Generic;
using System.Text;

namespace Hris.Shared.User
{
    public class UserModel : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string LanguageCode { get; set; }
        public int? LanguageId { get; set; }
        public int? TimeZone { get; set; }
        public string DateFormat { get; set; }
        public string TimeFormat { get; set; }
        public string DecimalSymbol { get; set; }
        public string DigitGroupingSymbol { get; set; }
        public DateTime? LastLogin { get; set; }
        public string IpAddress { get; set; }
    }
}
