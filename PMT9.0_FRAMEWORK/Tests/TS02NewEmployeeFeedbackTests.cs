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
    [TestCategory("NewEmployeeFeedback")]
    public class TS02NewEmployeeFedbackTests : BaseTest
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
            SupperiorComment ="zxcv"
        };
        internal static Feedback ReportWithGoals = new Feedback
        {
            Comment1 = "reportuje",
            SupperiorComment = "GOOD"
        };
        internal static string NameOfUserToReport = "Jan Kowal";
        internal static string DateOfReport = "2023-10-13";
        internal string TodayPlus365 = DateTime.Now.AddDays(365).ToString("yyyy-MM-dd");
        internal static Feedback ReceiverOfQuestionnaire = new Feedback
        {
            Receiver = "Kuba Tester",
            Questionnaire = "test",
            DateFeedback = "2023-09-18"
        };
        internal static string Status = "Zaplanowany";
        [TestMethod, TestCategory("NewEmployeeFeedback")]
        [Description("Check if feedback is added.")]
        public void TC01AddFeedback()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddFeedbackNewEmployee(driver, wait);
            FeedbackPage.GoToNewCustomerFeedback();
            FeedbackPage.CreateFeedback(AddFeedbackFOr);

            bool IsFeedbackAdded = FeedbackPage.IsFeedbackAdded(AddFeedbackFOr);
            Assert.IsTrue(IsFeedbackAdded, "Feedback has not been added.");
        }
        [TestMethod, TestCategory("NewEmployeeFeedback")]
        [Description("Check if report is added without goals.")]
        public void TC03AddReportWithoutGoals()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddReportNewEmployee(driver, wait);
            FeedbackPage.GoToNewCustomerFeedback();
            FeedbackPage.NameOfUserToReport(NameOfUserToReport, DateOfReport, Status);
            FeedbackPage.CreateReportForApexJunior(report);

            bool isErrorDisplayed = FeedbackPage.isErrorDisplayed();
            Assert.IsTrue(isErrorDisplayed, "Report has not been added without goals.");
        }
        [TestMethod, TestCategory("NewEmployeeFeedback")]
        [Description("Check if report is added with goals.")]
        public void TC04AddReportWithGoals()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddReportNewEmployee(driver, wait);
            FeedbackPage.GoToNewCustomerFeedback();
            FeedbackPage.NameOfUserToReport(NameOfUserToReport, DateOfReport, Status);
            FeedbackPage.CreateGoalsForApexJuniorWithGoals(ReportWithGoals);

            bool IsAddedWithGoals = FeedbackPage.IsAddedWithGoals(NameOfUserToReport, TodayPlus365);
 
        }
        [TestMethod, TestCategory("NewEmployeeFeedback")]
        [Description("Checks if questionnaire is sent.")]
        public void TC02SendQuestionnaire()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new SendQuestionnaireGoalsReview(driver, wait);
            FeedbackPage.GoToNewCustomerFeedback();
            FeedbackPage.NameOfUserToSendQuestionnaireFor(NameOfUserToReport, DateOfReport, Status);
            FeedbackPage.NameOfReceiver(ReceiverOfQuestionnaire);

            bool isSent = FeedbackPage.isSent();
            Assert.IsTrue(isSent, "Questionnaire has not been sent.");
        }
    }
}
