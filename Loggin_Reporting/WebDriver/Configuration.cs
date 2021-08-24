using System.Configuration;

namespace Loggin_Reporting.WebDriver
{
    public class Configuration
    {
        public static string GetConfigs(string configKey, string defaultValue)
        {
            return ConfigurationManager.AppSettings[configKey] ?? defaultValue;
        }

        public static string Browser => GetConfigs("browser", "Chrome");
        public static string URL => GetConfigs("url", "https://mail.ru/");
        public static string HUB => GetConfigs("hub", "http://192.168.0.11:4444/wd/hub");
        public static string SauceLabs => GetConfigs("sauceLabs", "");
        public static string Platform => GetConfigs("platform", "Windows 10");
    }
}
