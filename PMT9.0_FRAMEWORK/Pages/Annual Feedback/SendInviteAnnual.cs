using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.Annual_Feedback
{
    internal class SendInviteAnnual : AddReportGoalsReview
    {
        private IWebElement AddReportButton => wait.Until(ElementIsVisible(By.Id("START")));
        public SendInviteAnnual(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        
    }
}
