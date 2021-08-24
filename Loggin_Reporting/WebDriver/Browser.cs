using OpenQA.Selenium;

namespace Loggin_Reporting.WebDriver
{
    public class Browser
    {
        private static Browser currentInstance;
        private IWebDriver driver;
        private readonly string browser;

        private Browser()
        {
            browser = Configuration.Browser;
            driver = BrowserFactory.GetDriver(browser);
        }

        public static Browser Instance => currentInstance ?? (currentInstance = new Browser());

        public void Navigate(string url)
        {
            driver.Url = url;
        }

        public void Refresh()
        {
            driver.Navigate().Refresh();
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void Quit()
        {
            driver.Dispose();
            driver = null;
            currentInstance = null;
        }
    }
}
