
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace PMT9._0_FRAMEWORK.Pages
{
    internal class LoginPage : BasePage
    {

        public LoginPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private IWebElement UsernameField => wait.Until(ElementIsVisible(By.Id("P1_USERNAME")));
        private IWebElement PasswordField => wait.Until(ElementIsVisible(By.Id("P1_PASSWORD")));
        private IWebElement ErrorMessage => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Alert-body']")));
     

        private IWebElement Button => driver.FindElement(By.Id("B3203672799006821347"));
        public IWebElement logOut => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Header-navBar']//ul[@class='t-NavigationBar ']//li[@class='t-NavigationBar-item ']//button[@class='t-Button t-Button--icon t-Button t-Button--header t-Button--navBar js-menuButton']//span[@class='t-Button-label' and contains(text(),'IARABAS')]")));
     

        public bool isDisplayed => logOut.Displayed;
        internal void SignUp(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            Button.Click();
        }
        internal void GoTo()
        {
            driver.Navigate().GoToUrl("http://172.31.1.90:8080/apex/f?p=401:LOGIN:336298854305");
        }
        internal string GetErrorMessage()
        {
            Assert.IsTrue(ErrorMessage.Displayed, "Error message is not displayed.");
            System.Console.WriteLine("Error message: " + ErrorMessage.Text);
            return ErrorMessage.Text;
        }
    }
}