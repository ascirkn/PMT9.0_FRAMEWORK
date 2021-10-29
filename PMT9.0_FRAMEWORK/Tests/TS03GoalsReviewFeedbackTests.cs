using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Model.Employees;
using PMT9._0_FRAMEWORK.Pages;
using PMT9._0_FRAMEWORK.Pages.Feedback_roczny;
using PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback;
using System;

namespace PMT9._0_FRAMEWORK.Tests
{
    [TestClass]
    [TestCategory("GoalsReviewFeedback")]
    public class TS03GoalsReviewFeedbackTests : BaseTest
    {
        internal static Feedback AddFeedbackFOr = new Feedback
        {
            Employee = "Jan Kowal",
            DateFeedback = "2022-09-02"
        };
        internal static Feedback feedback = new Feedback
        {
            //MarkType = Mark.Completed
            Mark = "1",
            Comment1 = "komentuje",
            Comment2 = "komentuje drugi raz",
            SupperiorComment = "komentarz przelożonego"
        };
        internal static Feedback ReceiverOfQuestionnaire = new Feedback
        {
            Receiver ="Kuba Tester",
            Questionnaire = "test",
            DateFeedback = "2022-09-18"
        };
        internal static Feedback ReceiverOfInvite = new Feedback
        {
            Receiver = "Kuba Tester",
            DateFeedback = "2022-09-02 14:29:00"
        };
        internal static string HisName = "Jan Kowal";
        internal static string HisFeedbackDate = "2022-09-02";
        internal static string Status = "Zaplanowany";
        [TestMethod, TestCategory("GoalsReviewFeedback")]
        [Description("Checks if feedback is added.")]
        public void TC01AddNewFeedback()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new GoalsReviewFeedbackPage(driver, wait);
            FeedbackPage.GoToGoalsReview();
            FeedbackPage.CreateFeedback(AddFeedbackFOr);

            bool IsFeedbackAdded = FeedbackPage.IsFeedbackAdded(AddFeedbackFOr);
            Assert.IsTrue(IsFeedbackAdded, "Feedback has not been added.");
        }

        [TestMethod, TestCategory("GoalsReviewFeedback")]
        [Description("Checks if invite is sent.")]
        public void TC02SendInviteForFeedback()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new SendInviteGoalsReview(driver, wait);
            FeedbackPage.GoToGoalsReview();
            FeedbackPage.NameOfUserToSendInviteFor(HisName, HisFeedbackDate, Status);
            FeedbackPage.NameOfReceiver(ReceiverOfInvite);

            bool isSent = FeedbackPage.isSent();
            Assert.IsTrue(isSent, "Invite has not been sent.");
        }

        [TestMethod, TestCategory("GoalsReviewFeedback")]
        [Description("Checks if report is added.")]
        public void TC04AddReport()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddReportGoalsReview(driver, wait);
            FeedbackPage.GoToGoalsReview();
            FeedbackPage.NameOfUserToReport(HisName, HisFeedbackDate, Status);
            FeedbackPage.CreateReportForApexJunior(feedback);

            bool isAdded = FeedbackPage.isAdded();
            Assert.IsTrue(isAdded, "Report has not been added");
        }

        [TestMethod, TestCategory("GoalsReviewFeedback")]
        [Description("Checks if questionnaire is sent.")]
        public void TC03SendQuestionnaire()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new SendQuestionnaireGoalsReview(driver, wait);
            FeedbackPage.GoToGoalsReview();
            FeedbackPage.NameOfUserToSendQuestionnaireFor(HisName, HisFeedbackDate, Status);
            FeedbackPage.NameOfReceiver(ReceiverOfQuestionnaire);

            bool isSent = FeedbackPage.isSent();
            Assert.IsTrue(isSent, "Questionnaire has not been sent.");
        }
    }
}
