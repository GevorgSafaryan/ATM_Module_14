using Loggin_Reporting.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Loggin_Reporting.PageObjects
{
    public class CreateEmailPage : BasePage
    {
        private static readonly WebElement composeWindow = new WebElement(By.XPath("//div[@class = 'compose-app compose-app_fix compose-app_popup compose-app_window compose-app_adaptive']"));
        private readonly WebElement recipientField = new WebElement(By.XPath("(//input[@class = 'container--H9L5q size_s--3_M-_'])[1]"));
        private readonly WebElement subjectField = new WebElement(By.XPath("(//input[@class = 'container--H9L5q size_s--3_M-_'])[2]"));
        private readonly WebElement body = new WebElement(By.XPath("//div[contains(@class, 'editable-container')]/div/div[1]"));
        private readonly WebElement sendButton = new WebElement(By.XPath("//span[@data-title-shortcut = 'Ctrl+Enter']"));
        private readonly WebElement saveButton = new WebElement(By.XPath("//span[@data-title-shortcut = 'Ctrl+S']"));
        private readonly WebElement closeNewEmailForm = new WebElement(By.XPath("(//button[@class = 'container--2lPGK type_base--rkphf color_base--hO-yz'])[3]"));
        private readonly WebElement enteredRecipient = new WebElement(By.XPath("//div[@class = 'container--3B3Lm status_base--wsRcM']"));
        private readonly WebElement draftedEmailBody = new WebElement(By.XPath("//div[@class = 'js-helper js-readmsg-msg']/div/div/div/div[1]"));
        private readonly WebElement closIconAfterSendingEmail = new WebElement(By.XPath("//div[@class = 'layer__controls']//span[@class = 'button2__wrapper']"));
        private readonly WebElement footer = new WebElement(By.XPath("//div[@class = 'compose-app__footer']"));

        public CreateEmailPage() : base(composeWindow)
        {

        }

        public void FillRecipient(string recipient)
        {
            recipientField.SendKeys(recipient);
        }

        public void FillSubject(string subject)
        {
            subjectField.SendKeys(subject);
        }

        public void FillBody(string bodyText)
        {
            //body.SendKeys(bodyText);
            body.JSSendkeysByInnerText(bodyText);
        }

        public void ClickOnSendButton()
        {
            sendButton.Click();
        }

        public void SendEmailByActions()
        {
            Actions actions = new Actions(Browser.Instance.GetDriver());
            footer.Click();
            actions.KeyDown(Keys.Control).SendKeys(Keys.Enter).KeyUp(Keys.Control).Build().Perform();
        }

        public void ClickOnSaveButton()
        {
            saveButton.Click();
        }

        public void SaveEmailByActions()
        {
            Actions actions = new Actions(Browser.Instance.GetDriver());
            actions.SendKeys(Keys.Tab).Perform();
            actions.KeyDown(Keys.Control).SendKeys("s").KeyUp(Keys.Control).Build().Perform();
        }

        public void CloseNewEmailForm()
        {
            closeNewEmailForm.Click();
        }

        public bool VerifyDraftEmailsContent(string recipient, string subject, string bodyText)
        {
            bool assertRecipient = enteredRecipient.GetAttribute("title").Equals(recipient);
            bool assertSubject = subjectField.GetAttribute("value").Equals(subject);
            bool assertBody = draftedEmailBody.GetText().Equals(bodyText);
            return assertRecipient && assertSubject && assertBody;
        }

        public void ClickOnCloseButtonAfterSendingEmail()
        {
            closIconAfterSendingEmail.Click();
        }
    }
}
