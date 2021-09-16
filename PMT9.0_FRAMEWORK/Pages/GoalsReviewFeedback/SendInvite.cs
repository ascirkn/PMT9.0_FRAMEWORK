using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback
{
    class SendInvite : BasePageWithSidebar
    {
        private IWebElement AddInviteButton => wait.Until(ElementIsVisible(By.XPath("//button[@id='INVITE']")));
        private IWebElement Receiver => SendInviteButton.FindElement(By.XPath("//span[@class='select2-selection select2-selection--multiple']"));
        private IWebElement Deadline => SendInviteButton.FindElement(By.XPath("//input[@class='datepicker apex-item-text apex-item-datepicker hasDatepicker']"));
        private IWebElement SendInviteButton => wait.Until(ElementIsVisible(By.XPath("//button[@class='t-Button t-Button--icon t-Button--iconLeft t-Button--hot']")));
        private IWebElement JiraTask => SendInviteButton.FindElement(By.XPath("//label[@for='P431_CREATE_JIRA_0']"));
        private IWebElement OutReceiverWindow => SendInviteButton.FindElement(By.XPath("//div[@class='t-ButtonRegion-col t-ButtonRegion-col--content']"));
        public SendInvite(OpenQA.Selenium.IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        internal void NameOfUserToSendInviteFor(string NameOfUserToSendInviteFor, string DateOfFeedbackToReport)
        { 
            IWebElement AddFor = wait.Until(ElementIsVisible(By.XPath("//td[@class=' u-tL' and contains(text(), '" + NameOfUserToSendInviteFor + "')]//following-sibling::td[@class=' u-tC' and contains(text(), '" + DateOfFeedbackToReport + "')]//preceding-sibling::td[@class=' u-tL']//input[@name='f01']")));
            wait.Until(ElementToBeClickable(AddFor)).Click();
        }

        internal void NameOfReceiver(Feedback feedback)
        {
            AddInviteButton.Click();
            driver.SwitchTo().Frame(0);
            Receiver.SendKeys(feedback.Receiver);
            Receiver.SendKeys(Keys.Enter);
            OutReceiverWindow.Click();
            JiraTask.Click();
            Deadline.SendKeys(feedback.DateFeedback);
            SendInviteButton.Click();
        }
        internal bool isSent()
        {
            IWebElement alert = wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Alert-title' and contains(text(), 'Poprawnie wysłano zaproszenia')]")));
            if (alert.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
