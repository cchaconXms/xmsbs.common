using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.NetCore.ModelBase
{
    public class OptionSetModel<ValueType>
    {
        public ValueType Value { get; set; }
        public string Label { get; set; }
    }
}
