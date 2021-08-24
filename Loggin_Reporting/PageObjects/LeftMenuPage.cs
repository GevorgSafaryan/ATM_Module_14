using Loggin_Reporting.Utils;
using OpenQA.Selenium;

namespace Loggin_Reporting.PageObjects
{
    public class LeftMenuPage : BasePage
    {
        private static readonly WebElement newFolder = new WebElement(By.XPath("//div[@class = 'new-folder-btn__button-wrapper']"));
        private readonly WebElement composeButton = new WebElement(By.XPath("//span[@class = 'compose-button__wrapper']"));
        private readonly WebElement draftsFolder = new WebElement(By.XPath("//div[text() = 'Черновики']"));
        private readonly WebElement sentFolder = new WebElement(By.XPath("//a[@href = '/sent/']"));
        private readonly WebElement activeFolder = new WebElement(By.XPath("//a[@class = 'nav__item js-shortcut nav__item_active nav__item_shortcut nav__item_expanded_true nav__item_child-level_0']"));

        public LeftMenuPage() : base(newFolder)
        {

        }

        public void ClickOnComposeButton()
        {
            composeButton.Click();
        }

        public void OpenDraftsFolder()
        {
            draftsFolder.JSClick();
            wait.Until(WaitConditions.ElementDisplayed(activeFolder.GetLocator()));
        }

        public void OpenSentFolder()
        {
            sentFolder.Click();
            wait.Until(WaitConditions.ElementDisplayed(activeFolder.GetLocator()));
        }
    }
}
