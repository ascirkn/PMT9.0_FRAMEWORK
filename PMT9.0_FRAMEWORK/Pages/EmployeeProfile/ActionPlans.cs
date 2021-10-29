using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.EmployeeProfile
{
    class ActionPlans : BasePageWithSidebar
    {
        public ActionPlans(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private IWebElement EnterFeedbacks => wait.Until(ElementIsVisible(By.XPath("//span[contains(text(), 'Feedbacki')]")));
        private IWebElement EnterActionPlans => EnterFeedbacks.FindElement(By.XPath("//span[contains(text(), 'Action plany')]"));
        private IWebElement AddActionPlanButton => EnterActionPlans.FindElement(By.XPath("//*[@class='t-Button-label' and contains(text(), 'Dodaj action plan')]"));
        private IWebElement ActionPlanName => EnterActionPlans.FindElement(By.XPath("//input[@text='P451_NAME']"));
        private IWebElement ActionPlanDate => EnterActionPlans.FindElement(By.XPath("//input[@text='P451_DEADLINE']")); 
            private IWebElement ActionTask => EnterActionPlans.FindElement(By.XPath("//input[@text='f10']"));    
        internal void AddActionPlan(Feedback feedback)
        {
            EnterFeedbacks.Click();
            EnterActionPlans.Click();
            AddActionPlanButton.Click();
        }
    }

    
}
