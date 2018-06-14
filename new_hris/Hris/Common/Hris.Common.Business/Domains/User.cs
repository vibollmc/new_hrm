using System;
using System.Collections.Generic;
using System.Text;
using Hris.Common.Business.Enums;

namespace Hris.Common.Business.Domains
{
    public class User
    {
        public User(int? id, string username, string password, string fullname, string email, string languageCode,
            int? languageId, int? timeZone, string dateFormat, string timeFormat, string decimalSymbol,
            string digitGroupingSymbol, DateTime? lastLogin, string ipAddress, Status status)
        {
            Id = id;
            Username = username;
            Password = password;
            Fullname = fullname;
            Email = email;
            LanguageCode = languageCode;
            LanguageId = languageId;
            TimeZone = timeZone;
            DateFormat = dateFormat;
            TimeFormat = timeFormat;
            DecimalSymbol = decimalSymbol;
            DigitGroupingSymbol = digitGroupingSymbol;
            LastLogin = lastLogin;
            IpAddress = ipAddress;
            Status = status;
        }

        public int? Id { get; set; }
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
        public Status Status { get; set; }
    }
}
