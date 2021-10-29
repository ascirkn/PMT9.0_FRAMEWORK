using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.Feedback_roczny
{
    internal class GoalsReviewFeedbackPage : BasePageWithSidebar
    {
        public GoalsReviewFeedbackPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private IWebElement AddFeedbackButton => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Button js-ignoreChange']")));
        private IWebElement SaveFeedbackButton => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Button t-Button--icon t-Button--iconLeft t-Button--hot']")));
        private IWebElement Employee => SaveFeedbackButton.FindElement(By.XPath("//select[@id='P435_EMPLOYEE']"));
        private SelectElement EmployeeSelect => new SelectElement(Employee);
        private IWebElement Date => wait.Until(ElementIsVisible(By.XPath("//*[@class='datepicker apex-item-text apex-item-datepicker hasDatepicker']")));
        private IWebElement OpenFeedbackWindow => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Button js-ignoreChange']")));
        private IWebElement AddFeedbackEmployee => OpenFeedbackWindow.FindElement(By.XPath("//*[@class='selectlist apex-item-select']"));
        private IWebElement AddDateWindow => SaveFeedbackWindow.FindElement(By.XPath("//*[@class='datepicker apex-item-text apex-item-datepicker hasDatepicker']"));
        private IWebElement ExpandEmployees => wait.Until(ElementIsVisible(By.XPath("//select[@class='selectlist apex-item-select']")));
        private IWebElement SaveFeedbackWindow => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Button t-Button--icon t-Button--iconLeft t-Button--hot']")));

        internal void CreateFeedback(Feedback feedback)
        {
            OpenFeedbackWindow.Click();
            driver.SwitchTo().Frame(0);
            EmployeeSelect.SelectByText(feedback.Employee);
            AddDateWindow.SendKeys(feedback.DateFeedback);
            SaveFeedbackWindow.Click();
        }
        internal bool IsFeedbackAdded(Feedback feedback)
        {
            IWebElement AddedFor = wait.Until(ElementIsVisible(By.XPath("//td[@class=' u-tL' and contains(text(), '" + feedback.Employee + "')]//following-sibling::td[@class=' u-tC' and contains(text(), '" + feedback.DateFeedback + "')]")));
            if (AddedFor.Displayed)
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
