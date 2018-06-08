using System;
using System.Globalization;
using Hris.Database.Enums;
using Hris.List.Business.Enums;

namespace Hris.List.Persistence.Transformations
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
