using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XMSBS.Common.NetCore.Extensions
{
    public static class EnumExtensions
    {
        public static T ParseEnum<T>(this int value) where T : struct, IConvertible
        {
            if (typeof(T).IsEnum && typeof(T).IsEnumDefined(value))
            {
                return (T)Enum.ToObject(typeof(T), value);
            }
            else
            {
                throw new InvalidCastException("El tipo no es un enumerador o el valor no está asociado");
            }

        }

        public static T ParseEnum<T>(this string text) where T : struct
        {
            T result;
            if (Enum.TryParse<T>(text, out result))
            {
                return result;
            }

            return default(T);
        }

        public static string ToDescription(this Enum val)
        {
            var field = val.GetType().GetField(val.ToString());

            if (field == null)
            {
                return string.Empty;
            }
            
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                DescriptionAttribute[] attributesType = (DescriptionAttribute[])attributes;
                return attributesType.Length > 0 ? attributesType[0].Description : val.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
