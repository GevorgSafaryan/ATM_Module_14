using OpenQA.Selenium;

namespace Loggin_Reporting.PageObjects
{
    public class ProfileMenuPage : BasePage
    {
        private static readonly WebElement logoutButton = new WebElement(By.XPath("//div[text()= 'Выйти']"));

        public ProfileMenuPage() : base(logoutButton)
        {

        }

        public void ClickOnLogoutButton()
        {
            logoutButton.Click();
        }
    }
}
