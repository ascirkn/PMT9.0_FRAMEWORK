using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Model.Employees;
using PMT9._0_FRAMEWORK.Pages;
using PMT9._0_FRAMEWORK.Pages.Feedback_roczny;
using PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback;
using System;

namespace PMT9._0_FRAMEWORK
{
    [TestClass]
    [TestCategory("GoalsReviewFeedback")]
    public class GoalsReviewFeedbackTests : BaseTest
    {
        internal static Feedback feedback = new Feedback
        {
            //MarkType = Mark.Completed
            Mark = "1",
            CommentApex1 = "komentuje",
            CommentApex2 = "komentuje drugi raz"
        };

        internal static Feedback AddFeedbackFOr = new Feedback
        {
            Employee = "Jan Kowal",
            DateFeedback = "2020-09-02"
        };
        internal static Feedback ReceiverOfQuestionnaire = new Feedback
        {
            Receiver ="Kuba Tester",
            Questionnaire = "test",
            DateFeedback = "2021-09-18"
        };
        internal static Feedback ReceiverOfInvite = new Feedback
        {
            Receiver = "Kuba Tester",
            DateFeedback = "2021-09-16 14:29:00"
        };
        [TestMethod]
        [Description("Checks if feedback is added.")]
        public void AddNewFeedback()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new GoalsReviewFeedbackPage(driver, wait);
            FeedbackPage.GoToGoalsReview();
            FeedbackPage.CreateFeedback(AddFeedbackFOr);
        }

        [TestMethod]
        [Description("Checks if invite is sent.")]
        public void SendInviteForFeedback()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new SendInvite(driver, wait);
            FeedbackPage.GoToGoalsReview();
            FeedbackPage.NameOfUserToSendInviteFor("Jan Kowal", "2021-09-23");
            FeedbackPage.NameOfReceiver(ReceiverOfInvite);

            bool isSent = FeedbackPage.isSent();
            Assert.IsTrue(isSent, "Invite has not been sent.");
        }

        [TestMethod]
        [Description("Checks if report is added.")]
        public void AddReport()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddReport(driver, wait);
            FeedbackPage.GoToGoalsReview();
            FeedbackPage.NameOfUserToReport("Jan Kowal", "2021-09-23");
            FeedbackPage.CreateReportForApexJunior(feedback);

            bool isAdded = FeedbackPage.isAdded();
            Assert.IsTrue(isAdded, "Report isn't added. Something went wrong");
        }

        [TestMethod]
        [Description("Checks if questionnaire is sent.")]
        public void SendQuestionnaire()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new SendQuestionnaire(driver, wait);
            FeedbackPage.GoToGoalsReview();
            FeedbackPage.NameOfUserToSendQuestionnaireFor("Jan Kowal", "2021-09-23");
            FeedbackPage.NameOfReceiver(ReceiverOfQuestionnaire);

            bool isSent = FeedbackPage.isSent();
            Assert.IsTrue(isSent, "Questionnaire has not been sent.");
        }
    }
}
