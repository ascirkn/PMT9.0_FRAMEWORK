using Microsoft.VisualStudio.TestTools.UnitTesting;
using PMT9._0_FRAMEWORK.Pages;
using System;

namespace PMT9._0_FRAMEWORK
{
    [TestClass]
    [TestCategory("Login")]
    public class LoginTest : BaseTest
    {
        [TestMethod]
        public void LoginCorrectData()
        {

            var loginPage = new LoginPage(driver, wait);
            loginPage.GoTo();
            loginPage.SignUp(myLogin, myPassword);

            Assert.IsTrue(loginPage.isDisplayed, "isn't");
        }
        public void LoginIncorrectData()
        {

        }
    }
}