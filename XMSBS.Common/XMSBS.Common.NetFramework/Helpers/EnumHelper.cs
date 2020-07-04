using System;
using System.Collections.Generic;
using System.Text;
using XMSBS.Common.Extensions;
using XMSBS.Common.ModelBase;

namespace XMSBS.Common.Helpers
{
    public class EnumHelper
    {
        public List<OptionSetModel<int>> EnumToOptionSetList<T>()
        {
            var lista = new List<OptionSetModel<int>>();

            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var option = new OptionSetModel<int>();
                option.Value = (int)item;
                option.Label = (item as Enum).ToDescription();
                lista.Add(option);
            }

            return lista;
        }

        public OptionSetModel<int> EnumToOption(Enum eOption)
        {

            var option = new OptionSetModel<int>();
            option.Value = Convert.ToInt32(eOption);
            option.Label = eOption.ToDescription();
            return option;
        }
    }
}
