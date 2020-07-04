using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using XMSBS.Common.Helpers;
using XMSBS.Common.ModelBase.Enum;

namespace XMSBS.Common.ModelBase
{
    public abstract class BaseModel<idT>
    {
        public idT Id { get; set; }
        public String Name { get; set; }

        [JsonConverter(typeof(EnumJsonConverter))]
        public EstadoRegistroType EstadoRegistro { get; set; }
        
    }
}
