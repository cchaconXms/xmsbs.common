using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using XMSBS.Common.NetCore.Helpers;
using XMSBS.Common.NetCore.ModelBase.Enum;

namespace XMSBS.Common.NetCore.ModelBase
{
    public abstract class BaseModel<idT>
    {
        public idT Id { get; set; }
        public String Name { get; set; }

        [JsonConverter(typeof(EnumJsonConverter))]
        public EstadoRegistroType EstadoRegistro { get; set; }
        
    }
}
