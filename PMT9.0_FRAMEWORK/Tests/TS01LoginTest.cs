using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT9._0_FRAMEWORK.Pages;
using System;

namespace PMT9._0_FRAMEWORK.Tests
{
    [TestClass]
    [TestCategory("Login")]
    public class TS01LoginTest : BaseTest
    {
        [TestMethod, TestCategory("Login")]
        [Description("log.")]
        public void LoginCorrectData()
        {

            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            Assert.IsTrue(loginPage.isDisplayed, "isn't");
        }
        [TestMethod, TestCategory("Login")]
        [Description("invalid log.")]
        public void LoginIncorrectData()
        {
            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp("invalidL0gin", myPassword);
            string errorMsg = loginPage.GetErrorMessage();

            Assert.IsTrue(errorMsg.Length > 0, "Error message is empty.");
        }
    }
}