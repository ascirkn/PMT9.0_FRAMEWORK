using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback
{
    class SendQuestionnaireGoalsReview : BasePageWithSidebar
    {
        public SendQuestionnaireGoalsReview(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private IWebElement AddQuestionnaireButton => wait.Until(ElementIsVisible(By.XPath("//*[@id='SEND_SURVEY']")));
        private IWebElement Receiver => wait.Until(ElementIsVisible(By.XPath("//span[@class='select2-selection select2-selection--multiple']")));
        private IWebElement Questionnaire => SendQuestionnaireButton.FindElement(By.XPath("//select[@name='P432_SURVEY_TEMPLATE']"));
        private SelectElement QuestionnaireSelect => new SelectElement(Questionnaire);
        private IWebElement SendQuestionnaireButton => wait.Until(ElementIsVisible(By.XPath("//button[@class='t-Button t-Button--icon t-Button--iconLeft t-Button--hot']")));
        private IWebElement Deadline => SendQuestionnaireButton.FindElement(By.XPath("//input[@class='datepicker apex-item-text apex-item-datepicker hasDatepicker']"));
        internal void NameOfUserToSendQuestionnaireFor(string NameOfUserToSendQuestionnaireFor, string DateOfFeedbackToReport)
        {
            //IWebElement AddFor = wait.Until(ElementIsVisible(By.XPath("//select[@id='P435_EMPLOYEE']//option[contains(text(), '" + NameOfUserToSendQuestionnaireFor + "')]")));
            IWebElement AddFor = wait.Until(ElementIsVisible(By.XPath("//td[@class=' u-tL' and contains(text(), '" + NameOfUserToSendQuestionnaireFor + "')]//following-sibling::td[@class=' u-tC' and contains(text(), '" + DateOfFeedbackToReport + "')]//preceding-sibling::td[@class=' u-tL']//input[@name='f01']")));
            wait.Until(ElementToBeClickable(AddFor)).Click();
        }

        internal void NameOfReceiver(Feedback feedback)
        {
            AddQuestionnaireButton.Click();
            driver.SwitchTo().Frame(0);
            Receiver.SendKeys(feedback.Receiver);
            Receiver.SendKeys(Keys.Enter);
            QuestionnaireSelect.SelectByText(feedback.Questionnaire);
            Deadline.SendKeys(feedback.DateFeedback);
            SendQuestionnaireButton.Click();
        }
        internal bool isSent()
        {
            IWebElement alert = wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Alert-title' and contains(text(), 'Poprawnie wysłano ankiety')]")));
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
