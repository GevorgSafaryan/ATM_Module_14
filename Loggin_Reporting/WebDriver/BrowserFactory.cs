using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace Loggin_Reporting.WebDriver
{
    public class BrowserFactory
    {
        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver driver = null;
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArgument("--start-maximized");
                    options.AddArgument("disable-infobars");
                    options.AddExcludedArgument("enable-automation");
                    options.AddAdditionalCapability("useAutomationExtension", false);
                    options.AddUserProfilePreference("credentials_enable_service", false);
                    options.AddUserProfilePreference("profile.password_manager_enabled", false);
                    driver = new ChromeDriver(options);
                    break;
                case "FF":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "Edge":
                    break;
                case "Remote Chrome":
                    ChromeOptions option = new ChromeOptions();
                    option.AddArgument("--start-maximized");
                    option.AddArgument("disable-infobars");
                    option.AddExcludedArgument("enable-automation");
                    option.AddAdditionalCapability("useAutomationExtension", false);
                    option.AddUserProfilePreference("credentials_enable_service", false);
                    option.AddUserProfilePreference("profile.password_manager_enabled", false);
                    option.PlatformName = Configuration.Platform;
                    driver = new RemoteWebDriver(new Uri(Configuration.HUB), option.ToCapabilities());
                    break;
                case "Remote FF":
                    FirefoxOptions ffOptions = new FirefoxOptions
                    {
                        PlatformName = Configuration.Platform
                    };
                    driver = new RemoteWebDriver(new Uri(Configuration.HUB), ffOptions.ToCapabilities());
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    break;
            }
            return driver;
        }
    }
}
