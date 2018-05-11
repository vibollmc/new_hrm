using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Hris.Common.Business.Enums;
using Hris.Database.Enums;

namespace Hris.Common.Persistence.Transformations
{
    public static class CommonTransformations
    {
        public static MDStatus Transform(this Status status)
        {
            return status.Parse<MDStatus, Status>();
        }

        public static Status Transform(this MDStatus status)
        {
            return status.Parse<Status, MDStatus>();
        }

        public static MDModule Transform(this Module module)
        {
            return module.Parse<MDModule, Module>();
        }

        public static Module Transform(this MDModule module)
        {
            return module.Parse<Module, MDModule>();
        }

        public static T Parse<T, TK>(this TK k) where T: struct, IConvertible where TK:struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type.");
            }

            if (!typeof(TK).IsEnum)
            {
                throw new ArgumentException("TK must be an enumerated type.");
            }

            return (T) Enum.Parse(typeof(T), k.ToString(CultureInfo.InvariantCulture));
        }


        public static string ToMd5Hash(this string text)
        {
            var md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            //get hash result after compute it
            var results = md5.Hash;

            var strBuilder = new StringBuilder();
            foreach (var t in results)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(t.ToString("x2"));
            }

            return strBuilder.ToString();
        }
    }
}
