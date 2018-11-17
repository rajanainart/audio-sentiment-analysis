using System;
using System.Linq;
using System.Configuration;

namespace AudioProcessing.Core
{
    public sealed class AppConfig
    {
        public static string GetConfigValue(string configName)
        {
            if (ConfigurationManager.AppSettings.AllKeys.Contains(configName))
                return ConfigurationManager.AppSettings.Get(configName);
            return string.Empty;
        }

        public static string GetAppBasePath()
        {
            return Environment.CurrentDirectory;
        }
    }
}
