using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Model.Employees;
using PMT9._0_FRAMEWORK.Pages;
using PMT9._0_FRAMEWORK.Pages.Feedback_roczny;
using PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback;
using System;

namespace PMT9._0_FRAMEWORK.Tests
{
    class AnnualFeedbackTests : BaseTest
    {
        public void AddFeedback()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new GoalsReviewFeedbackPage(driver, wait);
            FeedbackPage.GoToAnnualFeedbacks();
        }

    }
}
