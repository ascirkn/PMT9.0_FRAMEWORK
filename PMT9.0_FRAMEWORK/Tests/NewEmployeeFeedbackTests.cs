using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Model.Employees;
using PMT9._0_FRAMEWORK.Pages;
using PMT9._0_FRAMEWORK.Pages.Annual_Feedback;
using PMT9._0_FRAMEWORK.Pages.Feedback_roczny;
using PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback;
using PMT9._0_FRAMEWORK.Pages.NewEmployeeFeedback;
using System;

namespace PMT9._0_FRAMEWORK.Tests
{
    [TestClass]
    [TestCategory("AnnualFeedback")]
    public class NewEmployeeFedbackTests : BaseTest
    {
        internal static Feedback AddFeedbackFOr = new Feedback
        {
            Employee = "Jan Kowal",
            DateFeedback = "2023-10-13"
        };
        internal static Feedback report = new Feedback
        {
            //MarkType = Mark.Completed
            Mark = "1",
            Comment1 = "komentuje",
            Comment2 = "komentuje drugi raz",
            Comment3 = "komentuje 3 raz"
        };
        internal static Feedback ReportWithGoals = new Feedback
        {
            Comment0 = "reportuje",
        };
        internal static string NameOfUserToReport = "Jan Kowal";
        internal static string DateOfReport = "2021-09-23";
        internal string TodayPlus365 = DateTime.Now.AddDays(365).ToString("yyyy-MM-dd");
        internal static Feedback ReceiverOfQuestionnaire = new Feedback
        {
            Receiver = "Kuba Tester",
            Questionnaire = "test",
            DateFeedback = "2021-09-18"
        };
        [TestMethod]
        [Description("Checks if feedback is added.")]
        public void AddFeedback()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddFeedbackNewEmployee(driver, wait);
            FeedbackPage.GoToNewCustomerFeedback();
            FeedbackPage.CreateFeedback(AddFeedbackFOr);
        }
        [TestMethod]
        [Description("Checks if report is added without goals.")]
        public void AddReportWithoutGoals()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddReportNewEmployee(driver, wait);
            FeedbackPage.GoToNewCustomerFeedback();
            FeedbackPage.NameOfUserToReport("Jan Kowal", "2021-09-23");
            FeedbackPage.CreateReportForApexJunior(report);
        }
        [TestMethod]
        [Description("Checks if report is added with goals.")]
        public void AddReportWithGoals()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddReportNewEmployee(driver, wait);
            FeedbackPage.GoToNewCustomerFeedback();
            FeedbackPage.NameOfUserToReport("Jan Kowal", "2021-09-23");
            FeedbackPage.CreateGoalsForApexJuniorWithGoals(ReportWithGoals);

            bool IsAddedWithGoals = FeedbackPage.IsAddedWithGoals(NameOfUserToReport, TodayPlus365);
 
        }
        [TestMethod]
        [Description("Checks if report is added with action plans.")]
        public void AddReportWithActionPlan()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

        }
        [TestMethod]
        [Description("Checks if questionnaire is sent.")]
        public void SendQuestionnaire()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new SendQuestionnaireGoalsReview(driver, wait);
            FeedbackPage.GoToGoalsReview();
            FeedbackPage.NameOfUserToSendQuestionnaireFor("Jan Kowal", "2021-09-23");
            FeedbackPage.NameOfReceiver(ReceiverOfQuestionnaire);

            bool isSent = FeedbackPage.isSent();
            Assert.IsTrue(isSent, "Questionnaire has not been sent.");
        }
    }
}
