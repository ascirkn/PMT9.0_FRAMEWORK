using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PMT9._0_FRAMEWORK.Pages.Annual_Feedback;
using PMT9._0_FRAMEWORK.Pages.AtRequestFeedback;
using PMT9._0_FRAMEWORK.Pages.Feedback_roczny;
using System;
using System.Collections.Generic;
using System.Text;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace PMT9._0_FRAMEWORK.Pages
{
    internal class BasePageWithSidebar : BasePage
    {
        protected BasePageWithSidebar(IWebDriver driver, WebDriverWait wait) : base(driver, wait) { }

        private IWebElement SidebarMenu => wait.Until(ElementIsVisible(By.XPath("//*[@class='t-TreeNav  a-TreeView']")));
        // MENU:
        //private IWebElement FeedbackLink => wait.Until(ElementIsVisible(By.XPath("//*[@class='a-TreeView-node is-expandable a-TreeView-node--topLevel']//div[@class='a-TreeView-content is-selected']//span[@class='a-TreeView-label' and contains(text(), 'Feedback')]")));
        private IWebElement FeedbackLink => wait.Until(ElementIsVisible(By.XPath("//*[@id='t_TreeNav_11']//span[@class='a-TreeView-toggle']")));
        private IWebElement AnnualFeedbackLink => wait.Until(ElementIsVisible(By.XPath("//*[@class='a-TreeView-label' and contains(text(), 'Feedback roczny')]")));
        private IWebElement GoalsReviewFeedback => wait.Until(ElementIsVisible(By.XPath("//*[@class='a-TreeView-label' and contains(text(), 'Feedback - weryfikacja celów')]")));
        private IWebElement NewCustomerFeedback => wait.Until(ElementIsVisible(By.XPath("//*[@class='a-TreeView-label' and contains(text(), 'Feedback - nowy pracownik')]")));
        private IWebElement AtRequestFeedback => wait.Until(ElementIsVisible(By.XPath("//*[@class='a-TreeView-label' and contains(text(), 'Feedback at request')]")));
        private IWebElement HrLink => wait.Until(ElementIsVisible(By.XPath("//*[@id='t_TreeNav_5']//span[@class='a-TreeView-toggle']")));
        private IWebElement Customers => wait.Until(ElementIsVisible(By.XPath("//*[@class='a-TreeView-label' and contains(text(), 'Ludzie')]")));
        internal AnnualFeedbackPage GoToAnnualFeedbacks()
        {
            Assert.IsTrue(SidebarMenu.Displayed, "Sidebar menu is not displayed.");
            wait.Until(ElementToBeClickable(FeedbackLink)).Click();
            wait.Until(ElementToBeClickable(AnnualFeedbackLink)).Click();
            return new AnnualFeedbackPage(driver, wait);
        }
        internal AnnualFeedbackPage GoToAnnualFeedbacksWhenMenuExpanded()
        {
            Assert.IsTrue(SidebarMenu.Displayed, "Sidebar menu is not displayed.");
            wait.Until(ElementToBeClickable(AnnualFeedbackLink)).Click();
            return new AnnualFeedbackPage(driver, wait);
        }
        internal GoalsReviewFeedbackPage GoToGoalsReview()
        {
            Assert.IsTrue(SidebarMenu.Displayed, "Sidebar menu is not displayed.");
            wait.Until(ElementToBeClickable(FeedbackLink)).Click();
            wait.Until(ElementToBeClickable(GoalsReviewFeedback)).Click();
            return new GoalsReviewFeedbackPage(driver, wait);
        }
        internal AtRequestFeedbackPage GoToAtRequest()
        {
            Assert.IsTrue(SidebarMenu.Displayed, "Sidebar menu is not displayed.");
            wait.Until(ElementToBeClickable(FeedbackLink)).Click();
            wait.Until(ElementToBeClickable(AtRequestFeedback)).Click();
            return new AtRequestFeedbackPage(driver, wait);
        }
        internal SendInviteAnnual GoToNewCustomerFeedback()
        {
            Assert.IsTrue(SidebarMenu.Displayed, "Sidebar menu is not displayed.");
            wait.Until(ElementToBeClickable(FeedbackLink)).Click();
            wait.Until(ElementToBeClickable(NewCustomerFeedback)).Click();
            return new SendInviteAnnual(driver, wait);
        }
        internal AnnualFeedbackPage GoToHR()
        {
            Assert.IsTrue(SidebarMenu.Displayed, "Sidebar menu is not displayed.");
            wait.Until(ElementToBeClickable(HrLink)).Click();
            wait.Until(ElementToBeClickable(Customers)).Click();
            return new AnnualFeedbackPage(driver, wait);
        }
    }
}
