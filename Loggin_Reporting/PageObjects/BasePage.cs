using Loggin_Reporting.Utils;
using OpenQA.Selenium.Support.UI;

namespace Loggin_Reporting.PageObjects
{
    public class BasePage
    {
        protected string title;
        protected WebElement pageUniqueElement;
        protected WebDriverWait wait = Wait.GetWait();

        public BasePage(string title)
        {
            this.title = title;
            CorrectPageIsOpenedByTitle();
        }

        public BasePage(WebElement pageUniqueElement)
        {
            this.pageUniqueElement = pageUniqueElement;
            CorretcPageIsOpenedByUniqueElement();
        }

        public BasePage() { }

        public void CorrectPageIsOpenedByTitle()
        {
            wait.Until(WaitConditions.TitleIs(title));
        }

        public void CorretcPageIsOpenedByUniqueElement()
        {
            wait.Until(WaitConditions.ElementExists(pageUniqueElement.GetLocator()));
        }
    }
}
