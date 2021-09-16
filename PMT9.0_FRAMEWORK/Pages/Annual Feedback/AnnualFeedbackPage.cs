using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.Feedback_roczny
{
    class AnnualFeedbackPage : BasePageWithSidebar
    {
        public AnnualFeedbackPage(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }


    }
}
