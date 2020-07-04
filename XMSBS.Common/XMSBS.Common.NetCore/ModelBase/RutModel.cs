using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.NetCore.ModelBase
{
    public class RutModel
    {
        public int Numero { get; set; }
        public string Dv { get; set; }

        public string fullFormatted
        {
            get
            {
                var returnValue = (Numero).ToString("#,###");

                if (Dv != null)
                    returnValue += "-" + Dv;

                return returnValue;
            }
        }
    }
}
