using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Hris.Shared.Enum;

namespace Hris.List.Api.Transformations
{
    public static class CommonTransformations
    {
        public static Status Transform(this Business.Enums.Status status)
        {
            return status.Parse<Status, Business.Enums.Status>();
        }

        public static Business.Enums.Status Transform(this Status status)
        {
            return status.Parse<Business.Enums.Status, Status>();
        }

        public static T Parse<T, TK>(this TK k) where T : struct, IConvertible where TK : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type.");
            }

            if (!typeof(TK).IsEnum)
            {
                throw new ArgumentException("TK must be an enumerated type.");
            }

            return (T)Enum.Parse(typeof(T), k.ToString(CultureInfo.InvariantCulture));
        }
    }
}
