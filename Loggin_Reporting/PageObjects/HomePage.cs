using Loggin_Reporting.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Loggin_Reporting.PageObjects
{
    public class HomePage : BasePage
    {
        private static readonly string homePageTitle = "Mail.ru: почта, поиск в интернете, новости, игры";
        private readonly WebElement loginField = new WebElement(By.XPath("//input[@name = 'login']"));
        private readonly WebElement enterPasswordButton = new WebElement(By.XPath("//button[@data-testid= 'enter-password']"));
        private readonly WebElement passwordField = new WebElement(By.XPath("//input[@name= 'password']"));
        private readonly WebElement enterButton = new WebElement(By.XPath("//button[@data-testid= 'login-to-mail']"));
        private readonly WebElement createAccountButton = new WebElement(By.XPath("//a[@href = '//account.mail.ru/signup?from=main&rf=auth.mail.ru&app_id_mytracker=52848']"));
        private readonly WebElement errorMessage = new WebElement(By.XPath("//div[@class = 'error svelte-1eyrl7y']"));
        private readonly WebElement domainsList = new WebElement(By.Name("domain"));

        public HomePage() : base(homePageTitle)
        {

        }

        public void EnterLogin(string login)
        {
            loginField.SendKeys(login);
        }

        public void ClickOnEnterPasswordButton()
        {
            enterPasswordButton.Click();
        }

        public void EnterPassword(string password)
        {
            passwordField.SendKeys(password);
        }

        public void ClickOnEnterButton()
        {
            enterButton.Click();
        }

        public void Login(string login, string password)
        {
            EnterLogin(login);
            ClickOnEnterPasswordButton();
            EnterPassword(password);
            ClickOnEnterButton();
        }

        public void SelectDomain(string domain)
        {
            SelectElement domains = new SelectElement(domainsList.GetElement());
            switch (domain)
            {
                case "mail.ru":
                    domains.SelectByIndex(0);
                    break;
                case "inbox.ru":
                    domains.SelectByIndex(1);
                    break;
                case "list.ru":
                    domains.SelectByIndex(2);
                    break;
                case "bk.ru":
                    domains.SelectByIndex(3);
                    break;
                case "internet.ru":
                    domains.SelectByIndex(4);
                    break;
                default:
                    domains.SelectByIndex(0);
                    break;
            }
        }

        public bool VerifySuccessfullLogout()
        {
            return wait.Until(WaitConditions.IsElementDisplayed(createAccountButton.GetElement()));
        }

        public bool VerifyErrorMessage(string message)
        {
            return errorMessage.GetText().Equals(message);
        }
    }
}
