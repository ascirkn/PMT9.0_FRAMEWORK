using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Pages.Feedback_roczny;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.AtRequestFeedback
{
    class AddFeedbackAtRequest : GoalsReviewFeedbackPage
    {
        public AddFeedbackAtRequest(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }


    }
}
