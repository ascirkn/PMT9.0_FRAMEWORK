using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Model.Employees;
using PMT9._0_FRAMEWORK.Pages;
using PMT9._0_FRAMEWORK.Pages.Annual_Feedback;
using PMT9._0_FRAMEWORK.Pages.Feedback_roczny;
using PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback;
using System;

namespace PMT9._0_FRAMEWORK.Tests
{
    [TestClass]
    [TestCategory("AnnualFeedback")]
    public class AnnualFeedbackTests : BaseTest
    {
        internal static Feedback report = new Feedback
        {
            Mark = "1",
            Comment1 = "komentuje",
            Comment2 = "komentuje drugi raz",
            Comment3 = "komentuje 3 raz"
        };
        [TestMethod]
        [Description("Checks if report is added.")]
        public void AddReport()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddReportAnnual(driver, wait);
            FeedbackPage.GoToAnnualFeedbacks();
            FeedbackPage.NameOfUserToReport("Jan Kowal", "2022-09-13");
            FeedbackPage.CreateReportForApexJunior(report);
        }

    }
}
