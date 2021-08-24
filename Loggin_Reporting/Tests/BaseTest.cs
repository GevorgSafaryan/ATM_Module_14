using Loggin_Reporting.Utils;
using Loggin_Reporting.WebDriver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Loggin_Reporting.Tests
{
    public class BaseTest
    {
        protected Browser Instance;
        [SetUp]
        public void Setup()
        {
            Instance = Browser.Instance;
            Logger.Instance.Info("Browser instance was created");
            Browser.Instance.Navigate(Configuration.URL);
            Logger.Instance.Info($"Navigated to {Configuration.URL}");
        }

        [TearDown]
        public void CleanUp()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                ScreenshotMaker.TakeBrowserScreenshot();
                ScreenshotMaker.TakeFullDisplayScreenshot();
                Logger.Instance.Error("Test is faled");
            }
            Browser.Instance.Quit();
        }
    }
}
