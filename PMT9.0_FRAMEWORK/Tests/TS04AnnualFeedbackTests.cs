using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Model.Employees;
using PMT9._0_FRAMEWORK.Pages;
using PMT9._0_FRAMEWORK.Pages.Annual_Feedback;
using PMT9._0_FRAMEWORK.Pages.Feedback_roczny;
using PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback;
using PMT9._0_FRAMEWORK.Pages.NewEmployeeFeedback;
using System;
using System.Threading;

namespace PMT9._0_FRAMEWORK.Tests
{
    [TestClass]
    [TestCategory("AnnualFeedback")]
    public class TS04AnnualFeedbackTests : BaseTest
    {
        internal static Feedback AddFeedbackFOr = new Feedback
        {
            Employee = "Jan Kowal",
            DateFeedback = DateTime.Now.ToString("yyyy-MM-dd"),
            Comment1 = "aaaaa",
            SupperiorComment ="super",
            MarkType = Mark.Completed
        };
        internal static Feedback report = new Feedback
        {
            Comment1 = "komentuje",
            WhatIsOkComment = "ok!",
            WhatToImproveComment = "apex",
            MarkType = Mark.Completed,
            ActionPlan = "woda",
            NameActionPlan ="name=name"
        };
        internal static string NameOfUserToReport = "Jan Kowal";
        internal static string DateOfReport = "2023-10-13";
        internal static string Status = "Zaplanowany";
        internal static string StatusComplete = "Przeprowadzony";
        internal string TodayPlus365 = DateTime.Now.AddDays(365).ToString("yyyy-MM-dd");
        [TestMethod]
        [Description("Check if error is displayed when goals are not designated during approval attempt.")]
        public void TC01AddReportWithoutGoals()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddReportAnnual(driver, wait);
            FeedbackPage.GoToAnnualFeedbacks();
            FeedbackPage.NameOfUserToReport(NameOfUserToReport, TodayPlus365, Status);
            FeedbackPage.CreateReportWithoutGoals(report);

            bool isErrorDisplayed = FeedbackPage.isErrorDisplayed();
            Assert.IsTrue(isErrorDisplayed, "Report has been added while it should not. There was no error window");
        }
        [TestMethod]
        [Description("Check if report is added with goals.")]
        public void TC02AddReportWithGoals()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddReportAnnual(driver, wait);
            FeedbackPage.GoToAnnualFeedbacks();
            FeedbackPage.NameOfUserToReport(NameOfUserToReport, TodayPlus365, Status);
            FeedbackPage.CreateGoalsForApexJuniorWithGoals(report);

            bool IsAddedWithGoals = FeedbackPage.IsAddedWithGoals(NameOfUserToReport, TodayPlus365);
        }
        [TestMethod]
        [Description("Check if report is added with action plans.")]
        public void TC03AddReportWithActionPlan()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            var NewEmployeeAddFeedback = new AddFeedbackNewEmployee(driver, wait);
            NewEmployeeAddFeedback.GoToNewCustomerFeedback();
            NewEmployeeAddFeedback.CreateFeedback(AddFeedbackFOr);
            var NewEmployeeFeedbackPage = new AddReportNewEmployee(driver, wait);
            NewEmployeeFeedbackPage.NameOfUserToReport(NameOfUserToReport, DateTime.Now.ToString("yyyy-MM-dd"), Status);
            NewEmployeeFeedbackPage.CreateGoalsForApexJuniorWithGoals(AddFeedbackFOr);
            var FeedbackPage = new AddReportAnnual(driver, wait);
            Thread.Sleep(2000);
            FeedbackPage.GoToAnnualFeedbacksWhenMenuExpanded();
            FeedbackPage.NameOfUserToReport(NameOfUserToReport, TodayPlus365, Status);
            FeedbackPage.CreateGoalsForApexJuniorWithActionPlan(report);

            bool isAdded = FeedbackPage.isAdded();
            Assert.IsTrue(isAdded, "Feedback has not been added. Alert with error has been displayed.");
            bool isErrorDisplayed = FeedbackPage.isErrorDisplayed();
            Assert.IsFalse(isErrorDisplayed, "There was no error occured when approving");
            bool isFeedbackStatusComplete = FeedbackPage.isFeedbackStatusComplete(NameOfUserToReport, TodayPlus365, StatusComplete);
            Assert.IsTrue(isFeedbackStatusComplete, "Feedback has not been added. Can't find feedback on list with status=complete");

        }

    }
}