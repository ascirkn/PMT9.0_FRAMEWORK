using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace PMT9._0_FRAMEWORK
{
    [TestClass]
    public class BaseTest
    {
        public IWebDriver driver;
        public WebDriverWait wait { get; private set; }

        public static readonly string myLogin = "iarabas";
        public static readonly string myPassword = "78sd78a";

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TestCleanup]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}
