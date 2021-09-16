using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace PMT9._0_FRAMEWORK.Pages
{
    internal class BasePage
    {
        internal IWebDriver driver { get; set; }

        public WebDriverWait wait { get; set; }

        protected BasePage(IWebDriver driver, WebDriverWait wait)
        {
            this.driver = driver;
            this.wait = wait;

        }
    }
}