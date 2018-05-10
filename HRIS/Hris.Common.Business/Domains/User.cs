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

        public int? Id { get; }
        public string Username { get; }
        public string Password { get; }
        public string Fullname { get;}
        public string Email { get;}
        public string LanguageCode { get;}
        public int? LanguageId { get;}
        public int? TimeZone { get;}
        public string DateFormat { get;}
        public string TimeFormat { get;}
        public string DecimalSymbol { get;}
        public string DigitGroupingSymbol { get;}
        public DateTime? LastLogin { get;}
        public string IpAddress { get;}
        public Status Status { get;}
    }
}
