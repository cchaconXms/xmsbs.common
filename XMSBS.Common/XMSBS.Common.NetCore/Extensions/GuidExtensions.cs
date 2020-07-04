using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.NetCore.Extensions
{
    public static class GuidExtensions
    {
        public static bool isGuidEmpty(this Guid _guid)
        {
            return _guid == Guid.Empty;
        }

        public static Guid toNewIfNullOrEmpty(this Guid? _guid)
        {
            return _guid.HasValue || _guid == Guid.Empty ? _guid.Value : Guid.NewGuid();
        }

        public static bool isNullOrEmpty(this Guid? _guid)
        {
            return _guid.HasValue ? _guid.Value == Guid.Empty : !_guid.HasValue;
        }
    }
}
