using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.NewEmployeeFeedback
{
    internal class AddReportNewEmployee : AddReportGoalsReview
    {
        public AddReportNewEmployee(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private IWebElement AddReportButton => wait.Until(ElementIsVisible(By.Id("START")));
        private List<IWebElement> Comments => new List<IWebElement>(SaveReportButton.FindElements(By.XPath("//*[@class=' u-tC']//textarea[@name='f02']")));
        private IWebElement SaveReportButton => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Button t-Button--icon t-Button--iconLeft t-Button--hot']")));
        private IWebElement SetGoalsCheckbox => SaveReportButton.FindElement(By.XPath("//label[@for='P448_SHOW_GOALS_0']"));
        private IWebElement Comment1 => SaveReportButton.FindElement(By.XPath("//textarea[@name='P448_MANAGER_OK']"));
        private IWebElement AnnualFeedbackLink => wait.Until(ElementIsVisible(By.XPath("//*[@class='a-TreeView-label' and contains(text(), 'Feedback roczny')]")));


 
        internal void CreateGoalsForApexJuniorWithGoals(Feedback feedback)
        {
            AddReportButton.Click();
            for (int i = 0; i < Comments.Count; i++)
            {
                Comments[i].Clear();
                Comments[i].SendKeys(feedback.Comment1);
            }
            SetGoalsCheckbox.Click();
            SaveReportButton.Click();

            //goto annual -> check if report avaliable
        }

        internal bool IsAddedWithGoals(string NameOfUserToReport, string DateOfReportPlus360d)
        {
            AnnualFeedbackLink.Click();
            IWebElement AddedFor = wait.Until(ElementIsVisible(By.XPath("//td[@class=' u-tL' and contains(text(), '" + NameOfUserToReport + "')]//following-sibling::td[@class=' u-tC' and contains(text(), '" + DateOfReportPlus360d + "')]")));
            Console.WriteLine(DateOfReportPlus360d);
            if (AddedFor.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
