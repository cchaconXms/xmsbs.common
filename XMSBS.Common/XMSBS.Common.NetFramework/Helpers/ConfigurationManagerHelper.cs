using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace XMSBS.Common.Helpers
{
    public abstract class ConfigurationManagerHelper
    {

        protected static string getStringValue(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (ConfigurationErrorsException ex)
            {
                throw new Exception("error al buscar el valor de: " + key, ex);
            }
        }

        protected static int getIntValue(string key)
        {
            int value;
            int.TryParse(getStringValue(key), out value);
            return value;
        }

        protected static double getDoubleValue(string key)
        {
            double value;
            double.TryParse(getStringValue(key), out value);
            return value;
        }

        protected static Boolean getBooleanValue(string key)
        {
            Boolean value;
            Boolean.TryParse(getStringValue(key), out value);
            return value;
        }

        protected static Guid getGuidValue(string key)
        {
            Guid value;
            Guid.TryParse(getStringValue(key), out value);
            return value;
        }
    }
}
