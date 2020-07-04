using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace XMSBS.Common.NetCore.ModelBase.Enum
{
    public enum EstadoRegistroType
    {
        [Description("ACTIVO")]
        Activo = 1,
        [Description("INACTIVO")]
        Inactivo = 0
    }
}
