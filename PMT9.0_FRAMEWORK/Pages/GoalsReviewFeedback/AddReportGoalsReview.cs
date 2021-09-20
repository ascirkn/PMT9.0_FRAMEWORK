using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages.GoalsReviewFeedback
{
    internal class AddReportGoalsReview : BasePageWithSidebar
    {
        public AddReportGoalsReview(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }
        private IWebElement AddReportButton => wait.Until(ElementIsVisible(By.Id("START")));
        private IWebElement SaveReportButton => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Button t-Button--icon t-Button--iconLeft t-Button--hot']")));
        private IWebElement Mark => SaveReportButton.FindElement(By.XPath("//*[@headers='C104598843634383101 B104597634355383100_1']//select[@name='f01']"));
        private SelectElement MarkSelect => new SelectElement(Mark);
        private List<IWebElement> Comments => new List<IWebElement>(SaveReportButton.FindElements(By.XPath("//*[@class=' u-tC']//textarea[@name='f02']")));
        private IWebElement actualResult => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Alert-title' and contains(text(), 'Poprawnie zapisano zmiany w Feedback')]")));
        internal void NameOfUserToReport(string NameOfUserToReport, string DateOfFeedbackToReport)
        {
            //IWebElement AddFor = wait.Until(ElementIsVisible(By.XPath("//input[@name='f01']/parent::td[@class=' u-tL']//following-sibling::td[@class=' u-tL' and contains(text(), '" + NameOfUserToReport + "')]//following-sibling::td[@class=' u-tC' and contains(text(), '" + DateOfFeedbackToReport + "')]")));
            //IWebElement AddFor = wait.Until(ElementIsVisible(By.XPath("//input[@name='f01']/parent::td[@class=' u-tL']//following-sibling::td[@class=' u-tL' and contains(text(), '" + NameOfUserToReport + "')]//following-sibling::td[@class=' u-tC' and contains(text(), '" + DateOfFeedbackToReport + "')]//following::td[@class=' u-tL']//input[@name='f01']")));
            IWebElement AddFor = wait.Until(ElementIsVisible(By.XPath("//td[@class=' u-tL' and contains(text(), '" + NameOfUserToReport + "')]//following-sibling::td[@class=' u-tC' and contains(text(), '" + DateOfFeedbackToReport + "')]//preceding-sibling::td[@class=' u-tL']//input[@name='f01']")));
            wait.Until(ElementToBeClickable(AddFor)).Click();
        }
        internal void CreateReportForApexJunior(Feedback feedback)
        {
            AddReportButton.Click();
            for (int i = 0; i < Comments.Count; i++)
            {
                Comments[i].Clear();
                Comments[i].SendKeys(feedback.Comment1);
            }
            //MarkSelect.SelectByValue(feedback.Mark);
            SaveReportButton.Click();
        }
        internal bool isAdded()
        {
            IWebElement alert = wait.Until(ElementIsVisible(By.XPath("//*[@class='t-Alert-title' and contains(text(), 'Poprawnie zapisano zmiany w Feedback')]")));
            if (alert.Displayed)
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
