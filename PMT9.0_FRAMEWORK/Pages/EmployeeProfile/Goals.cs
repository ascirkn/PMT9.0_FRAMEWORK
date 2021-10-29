using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.EmployeeProfile
{
    class Goals : BasePageWithSidebar
    {
        public Goals(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private IWebElement EnterFeedbacks => wait.Until(ElementIsVisible(By.XPath("//span[contains(text(), 'Feedbacki')]")));
        private IWebElement EnterGoals => EnterFeedbacks.FindElement(By.XPath("//span[contains(text(), 'Cele')]"));
        private IWebElement AddGoalButton => EnterGoals.FindElement(By.XPath("//*[@class='t-Button-label' and contains(text(), 'Dodaj cel')]"));
        private IWebElement CompetenceType => EnterGoals.FindElement(By.XPath("//select[@id='P311_COMPETENCY_TYPE']"));
        private SelectElement SelectCompetenceType => new SelectElement(CompetenceType);
        private IWebElement Competence => EnterGoals.FindElement(By.XPath("//select[@id='P311_COMPETENCIES_ID']"));
        private SelectElement SelectCompetence => new SelectElement(Competence);
        private IWebElement Goal => EnterGoals.FindElement(By.XPath("//select[@id='P311_GOALS_ID']"));
        private SelectElement SelectGoal => new SelectElement(Goal);
        private IWebElement SaveGoalButton => EnterGoals.FindElement(By.XPath("//button[@class='t-Button t-Button--hot ']"));
        internal void AddGoal(Feedback feedback)
        {
            EnterFeedbacks.Click();
            EnterGoals.Click();
            AddGoalButton.Click();
            SelectCompetenceType.SelectByText(feedback.CompetenceType);
            SelectCompetence.SelectByText(feedback.Competence);
            Goal.SendKeys(feedback.Goal);
            SaveGoalButton.Click();
        }
        internal bool IsFeedbackAdded(Feedback feedback)
        {
             
            try 
            { 
               IWebElement AddedFor = wait.Until(ElementIsVisible(By.XPath("//td[@class='C110730499904379450 B110730043561379446_110730176254379447_1' and contains(text(), '" + feedback.Goal + "')]")));
                return true;
            }
            catch (NoSuchElementException e)
            {
               return false;
            }
        }
    }
}
