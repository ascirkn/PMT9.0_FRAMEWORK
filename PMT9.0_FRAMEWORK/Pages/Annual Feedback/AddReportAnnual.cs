using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Model;
using PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback;
using PMT9._0_FRAMEWORK.Pages.NewEmployeeFeedback;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.Annual_Feedback
{
    class AddReportAnnual : AddReportNewEmployee
    {
        private IWebElement AddReportButton => wait.Until(ElementIsVisible(By.Id("START")));
        private List<IWebElement> Comments => new List<IWebElement>(SaveReportButton.FindElements(By.XPath("//*[@class=' u-tC']//textarea[@name='f02']")));
        private IWebElement SaveReportButton => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Button t-Button--icon t-Button--iconLeft t-Button--hot']")));
        private IWebElement SetGoalsCheckbox => SaveReportButton.FindElement(By.XPath("//label[@for='P433_SHOW_GOALS_0']"));
        private IWebElement InputActionPlan => EnterActionPlan.FindElement(By.XPath("//input[@name='f10']"));
        private IWebElement EnterActionPlan => SaveReportButton.FindElement(By.XPath("//label[@for='P433_SHOW_ACTION_PLAN_0']"));
        private List<IWebElement> Mark => new List<IWebElement>(SaveReportButton.FindElements(By.XPath("//*[@class=' u-tC']//select[@name='f01']")));
        //private SelectElement MarkSelect => new SelectElement(Mark);
        private List<IWebElement> Completed => new List<IWebElement>(WaitForDropdown.FindElements(By.XPath("//option[contains(text(), 'Zrealizowany (3)')]")));
        private List<IWebElement> Partially_completed => new List<IWebElement>(WaitForDropdown.FindElements(By.XPath("//option[contains(text(), 'Częsciowo zrealizowany (2)')]")));
        private List<IWebElement> Uncompleted => new List<IWebElement>(WaitForDropdown.FindElements(By.XPath("//option[contains(text(), 'Niezrealizowany (1)')]")));
        private IWebElement WhatIsOkComment => WaitForDropdown.FindElement(By.XPath("//textarea[@name='P433_MANAGER_OK']"));
        private IWebElement WhatToImproveComment => WaitForDropdown.FindElement(By.XPath("//textarea[@name='P433_MANAGER_TO_IMPROVE']"));
        private IWebElement WaitForDropdown => SaveReportButton.FindElement(By.XPath("//select[@name='f01']"));
        private IWebElement NameActionPlan => SaveReportButton.FindElement(By.XPath("//input[@id='P433_ACTION_PLAN_NAME']"));
        private List<IWebElement> EnterMarkDropdown => new List<IWebElement>(SaveReportButton.FindElements(By.XPath("//select[@name='f01']")));

        public AddReportAnnual(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        internal void CreateGoalsForApexJuniorWithGoals(Feedback feedback)
        {
            AddReportButton.Click();
            for (int i = 0; i < Comments.Count; i++)
            {
                Comments[i].Clear();
                Comments[i].SendKeys(feedback.Comment1);
            }
            foreach (IWebElement element in Mark) 
            {

                element.Click();

                        switch (feedback.MarkType)
                        {
                    case Model.Employees.Mark.Completed:
                        for (int i = 0; i < Completed.Count; i++)
                        {
                            Completed[i].Click();
                        };
                        break;
                    case Model.Employees.Mark.Partially_completed:
                        for (int i = 0; i < Partially_completed.Count; i++)
                        {
                            Partially_completed[i].Click();
                        };
                        break;
                    case Model.Employees.Mark.Uncompleted:
                        for (int i = 0; i < Uncompleted.Count; i++)
                        {
                            Uncompleted[i].Click();
                        };
                        break;
                         } 
            } 
            //MarkSelect.SelectByValue(feedback.Mark);
            WhatIsOkComment.SendKeys(feedback.WhatIsOkComment);
            WhatToImproveComment.SendKeys(feedback.WhatToImproveComment);
            SetGoalsCheckbox.Click();
            SaveReportButton.Click();

            //goto annual -> check if report avaliable
        }
        internal void CreateGoalsForApexJuniorWithActionPlan(Feedback feedback)
        {
            AddReportButton.Click();
            for (int i = 0; i < Comments.Count; i++)
            {
                Comments[i].Clear();
                Comments[i].SendKeys(feedback.Comment1);
            }
            EnterActionPlan.Click();
            InputActionPlan.SendKeys(feedback.ActionPlan);
            NameActionPlan.SendKeys(feedback.NameActionPlan);
            for (int i = 0; i < Comments.Count; i++)
            {
                Comments[i].Clear();
                Comments[i].SendKeys(feedback.Comment1);
            }
            foreach (IWebElement element in Mark)
            {

                element.Click();

                switch (feedback.MarkType)
                {
                    case Model.Employees.Mark.Completed:
                        for (int i = 0; i < Completed.Count; i++)
                        {
                            Completed[i].Click();
                        };
                        break;
                    case Model.Employees.Mark.Partially_completed:
                        for (int i = 0; i < Partially_completed.Count; i++)
                        {
                            Partially_completed[i].Click();
                        };
                        break;
                    case Model.Employees.Mark.Uncompleted:
                        for (int i = 0; i < Uncompleted.Count; i++)
                        {
                            Uncompleted[i].Click();
                        };
                        break;
                }
            }
            WhatIsOkComment.SendKeys(feedback.WhatIsOkComment);
            WhatToImproveComment.SendKeys(feedback.WhatToImproveComment);
            SetGoalsCheckbox.Click();
            SaveReportButton.Click();

            //goto annual -> check if report avaliable
        }
        internal void CreateReportWithoutGoals(Feedback feedback)
        {
            AddReportButton.Click();
            for (int i = 0; i < Comments.Count; i++)
            {
                Comments[i].Clear();
                Comments[i].SendKeys(feedback.Comment1);
            }
            //MarkSelect.SelectByValue(feedback.Mark);
            for (int i = 0; i < Comments.Count; i++)
            {
                Comments[i].Clear();
                Comments[i].SendKeys(feedback.Comment1);
            }
            foreach (IWebElement element in Mark)
            {

                element.Click();

                switch (feedback.MarkType)
                {
                    case Model.Employees.Mark.Completed:
                        for (int i = 0; i < Completed.Count; i++)
                        {
                            Completed[i].Click();
                        };
                        break;
                    case Model.Employees.Mark.Partially_completed:
                        for (int i = 0; i < Partially_completed.Count; i++)
                        {
                            Partially_completed[i].Click();
                        };
                        break;
                    case Model.Employees.Mark.Uncompleted:
                        for (int i = 0; i < Uncompleted.Count; i++)
                        {
                            Uncompleted[i].Click();
                        };
                        break;
                }
            }
            WhatIsOkComment.SendKeys(feedback.WhatIsOkComment);
            WhatToImproveComment.SendKeys(feedback.WhatToImproveComment);
            SaveReportButton.Click();
        }
        internal bool isErrorDisplayed()
        {
            try
            {
               IWebElement alert = driver.FindElement(By.XPath("//*[@class='a-Notification-link' and contains(text(), 'Żeby zatwierdzić feedback roczny musisz wyznaczyć cele roczne')]"));
                return true;
            } catch (NoSuchElementException e) {

                return false; }
        }
    }
}
