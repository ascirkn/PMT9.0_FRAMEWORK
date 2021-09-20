using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMT9._0_FRAMEWORK.Pages.NewEmployeeFeedback
{
    class SendQuestionnaireNewEmployee : SendQuestionnaireGoalsReview
    {
        public SendQuestionnaireNewEmployee(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
    
    }
}
