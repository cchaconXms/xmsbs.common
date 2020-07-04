using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.NetCore.Extensions
{
    public static class StringExtemsions
    {
        static System.Globalization.TextInfo _textInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;

        public static string trimIfNotNull(this string _string)
        {
            return !string.IsNullOrEmpty(_string) ? _string.Trim() : _string;
        }

        public static bool isNullOrEmpty(this string _string)
        {
            return string.IsNullOrEmpty(_string);
        }
        public static bool isNotNullOrEmpty(this string _string)
        {
            return !string.IsNullOrEmpty(_string);
        }
        public static string right(this string value, int length)
        {
            if (value != null && value.Length > length)
                return value.Substring(value.Length - length);
            else
                return value;
        }

        public static string left(this string value, int length)
        {
            if (value != null && value.Length > length)
                return value.Substring(0, length);
            else
                return value;
        }

        public static string ToPropperCase(this string _stringToPropperCase)
        {
            return _textInfo.ToTitleCase(_stringToPropperCase.ToLower());
        }
    }
}
