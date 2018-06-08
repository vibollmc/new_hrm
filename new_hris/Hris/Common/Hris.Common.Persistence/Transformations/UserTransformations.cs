using Hris.Common.Business.Domains;
using Hris.Database.Entities;
using Hris.Database.Entities.Common;

namespace Hris.Common.Persistence.Transformations
{
    public static class UserTransformations
    {
        public static MDUser Transform(this User user)
        {
            
            return user == null
                ? null
                : new MDUser
                {
                    Id = user.Id,
                    Status = user.Status.Transform(),
                    DateFormat = user.DateFormat,
                    DecimalSymbol = user.DecimalSymbol,
                    DigitGroupingSymbol = user.DigitGroupingSymbol,
                    Email = user.Email,
                    Fullname = user.Fullname,
                    LanguageCode = user.LanguageCode,
                    LanguageId = user.LanguageId,
                    LastLogin = user.LastLogin,
                    IpAddress = user.IpAddress,
                    Password = user.Password.ToMd5Hash(),
                    TimeFormat = user.TimeFormat,
                    TimeZone = user.TimeZone,
                    Username = user.Username
                };
        }

        public static User Transform(this MDUser user)
        {
            return user == null
                ? null
                : new Business.Domains.User(user.Id, user.Username, user.Password, user.Fullname, user.Email,
                    user.LanguageCode, user.LanguageId, user.TimeZone, user.DateFormat, user.TimeFormat,
                    user.DecimalSymbol, user.DigitGroupingSymbol, user.LastLogin, user.IpAddress,
                    user.Status.Transform());
        }

        public static void UpdateValue(this MDUser user, User value)
        {
            if (value == null) return;
            if (user == null) user = new MDUser {Id = value.Id};

            user.Status = value.Status.Transform();
            user.DateFormat = value.DateFormat;
            user.DecimalSymbol = value.DecimalSymbol;
            user.DigitGroupingSymbol = value.DigitGroupingSymbol;
            user.Email = value.Email;
            user.Fullname = value.Fullname;
            user.LanguageCode = value.LanguageCode;
            user.LanguageId = value.LanguageId;
            user.LastLogin = value.LastLogin;
            user.IpAddress = value.IpAddress;
            user.Password = value.Password;
            user.TimeFormat = value.TimeFormat;
            user.TimeZone = value.TimeZone;
            user.Username = value.Username;
        }
    }
}
