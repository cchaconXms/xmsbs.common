using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.NetCore.Extensions
{
    public static class ObjectExtensions
    {
        public static void SetValue(this object item, string propiedad, object value)
        {
            var arr = propiedad.Split('.');
            var itemType = item.GetType();

            if (arr.Length == 1)
            {
                itemType.GetProperty(propiedad).SetValue(item, value);
            }
            else
            {
                Object nextObj = item;

                for (int i = 0; i < arr.Length; i++)
                {
                    var propName = arr[i];

                    if (i + 1 == arr.Length)
                    {
                        nextObj.GetType().GetProperty(propName).SetValue(nextObj, value);
                        break;
                    }

                    nextObj = nextObj.GetType().GetProperty(propName).GetValue(nextObj);

                }
            }

        }
    }
}
