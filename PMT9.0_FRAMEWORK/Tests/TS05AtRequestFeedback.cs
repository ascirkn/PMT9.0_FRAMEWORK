using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Pages;
using PMT9._0_FRAMEWORK.Pages.AtRequestFeedback;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMT9._0_FRAMEWORK.Tests
{
    [TestClass]
    [TestCategory("AtRequestFeedback")]
    class TS05AtRequestFeedback : BaseTest
    {
        internal static Feedback user = new Feedback
    {
        Employee = "Jan Kowal",
        DateFeedback = "2023-10-13"
    };
    public void TC01AddFeedback()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);
            var FeedbackPage = new AddFeedbackAtRequest(driver, wait);
            FeedbackPage.CreateFeedback(user);

            bool isFeedbackAdded = FeedbackPage.IsFeedbackAdded(user);
            Assert.IsTrue(isFeedbackAdded, "Feedback has not been added");
        }

    }
}
