using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Hris.Common.Persistence.Transformations
{
    public static class CommonTransformations
    {
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
    }
}
