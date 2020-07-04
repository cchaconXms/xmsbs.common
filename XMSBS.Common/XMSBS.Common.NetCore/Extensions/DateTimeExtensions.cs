using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.NetCore.Extensions
{
    public static class DateTimeExtensions
    {
        public static int MonthDifference(this DateTime lValue, DateTime rValue)
        {
            return (lValue.Month - rValue.Month) + 12 * (lValue.Year - rValue.Year);
        }
    }
}
