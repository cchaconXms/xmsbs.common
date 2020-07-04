using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;

namespace XMSBS.Common.Helpers
{
    public class ConfigurationObject
    {
        public static T GetConfigurationObject<T>(string key)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

            var obj = configuration.GetValue<T>(key);

            return obj;
        }
    }
}
