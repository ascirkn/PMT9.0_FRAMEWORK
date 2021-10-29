using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Pages;
using PMT9._0_FRAMEWORK.Pages.EmployeeProfile;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMT9._0_FRAMEWORK.Tests
{
    class TS06EmployeeProfileTests : BaseTest
    {
        internal static Feedback Goal = new Feedback
        {
            CompetenceType = "Miękka",
            Competence = "APEX",
            Goal = "Umiec w APEXA"
        };

    [TestMethod, TestCategory("EmployeeProfile")]
        [Description("Check if feedback is added.")]
        public void TC01AddGoal()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var EmployeePage = new Goals(driver, wait);
            EmployeePage.GoToNewCustomerFeedback();
            EmployeePage.AddGoal(Goal);

            bool IsFeedbackAdded = EmployeePage.IsFeedbackAdded(Goal);
            Assert.IsTrue(IsFeedbackAdded, "Goal has not been added.");
        }
    }
}
