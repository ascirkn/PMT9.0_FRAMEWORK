using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Pages.Feedback_roczny;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.NewEmployeeFeedback
{
    class AddFeedbackNewEmployee : GoalsReviewFeedbackPage
    {
        public AddFeedbackNewEmployee(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private IWebElement Employee => SaveFeedbackButton.FindElement(By.XPath("//select[@id='P436_EMPLOYEE']")); 
        private SelectElement EmployeeSelect => new SelectElement(Employee);
        private IWebElement SaveFeedbackWindow => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Button t-Button--icon t-Button--iconLeft t-Button--hot']")));
        private IWebElement SaveFeedbackButton => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Button t-Button--icon t-Button--iconLeft t-Button--hot']")));
        private IWebElement AddDateWindow => SaveFeedbackWindow.FindElement(By.XPath("//*[@class='datepicker apex-item-text apex-item-datepicker hasDatepicker']"));
        private IWebElement OpenFeedbackWindow => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Button js-ignoreChange']")));

        internal void CreateFeedback(Feedback feedback)
        {
            OpenFeedbackWindow.Click();
            driver.SwitchTo().Frame(0);
            EmployeeSelect.SelectByText(feedback.Employee);
            AddDateWindow.SendKeys(feedback.DateFeedback);
            SaveFeedbackWindow.Click();
        }
    }
}
