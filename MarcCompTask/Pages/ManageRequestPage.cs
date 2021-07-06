using MarcCompTask.Utilities;
using MarcCompTask.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using static MarcCompTask.Utilities.Helper;

namespace MarcCompTask.Pages
{
    class ManageRequestPage
    {
        LogInPage logInPage;
        public ManageRequestPage()
        {
            logInPage = new LogInPage();
            PageFactory.InitElements(CommonDriver.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[1]")]
        private IWebElement ManageRequests { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[1]")]
        private IWebElement ReceivedRequests { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[1]/div/a[2]")]
        private IWebElement SentRequests { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='received-request-section']/div[2]/h2")]
        private IWebElement ReceivedRequestsTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/h2")]
        private IWebElement SentRequestsTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr/td[8]/button")]
        private IWebElement ActionsButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[1]")]
        private IWebElement Accept { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[8]/button[2]")]
        private IWebElement Decline { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='received-request-section']/div[2]/div[1]/table/tbody/tr[1]/td[5]")]
        private IWebElement ReceivedRequestStatus { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='sent-request-section']/div[2]/div[1]/table/tbody/tr/td[5]")]
        private IWebElement SentRequestStatus { get; set; }

        //Read data from Excel
        private string acceptreceived = ExcelLib.ReadData(1, "AcceptReceivedRequest");
        private string declinereceived = ExcelLib.ReadData(1, "DeclineReceivedRequest");
        private string withdrawsent = ExcelLib.ReadData(1, "WithdrawSentRequest");
        private string completesent = ExcelLib.ReadData(1, "CompleteSentRequest");

        //Received Request Actions - Accept
        public void AcceptReceivedRequest(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            ClickManageRequests();
            ClickReceivedRequests();
            ValidateAtReceivedRequestsPage();
            ClickAccept();
            bool isStatusAccepted = ValidateReceivedRequestStatus(acceptreceived);
            Assert.IsTrue(isStatusAccepted);
        }


        //Received Request Actions - Decline
        public void DeclineReceivedRequest(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            ClickManageRequests();
            ClickReceivedRequests();
            ValidateAtReceivedRequestsPage();
            ClickDecline();
            bool isStatusDeclined = ValidateReceivedRequestStatus(declinereceived);
            Assert.IsTrue(isStatusDeclined);

        }
        public void ClickManageRequests()
        {
            ManageRequests.Click();
        }

        public void ClickReceivedRequests()
        {
            ReceivedRequests.Click();
        }

        public void ValidateAtReceivedRequestsPage()
        {
            bool isAtReceivedRequestsPage = ReceivedRequestsTitle.Displayed;
            Assert.IsTrue(isAtReceivedRequestsPage);
        }

        public void ClickAccept()
        {
            Accept.Click();
        }

        public bool ValidateReceivedRequestStatus(string status)
        {
            if (ReceivedRequestStatus.Text == status)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void ClickDecline()
        {
            Decline.Click();
        }



        //Sent Request Actions - Withdraw
        public void WithdrawSentRequest(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            ClickManageRequests();
            ClickSentRequests();
            ValidateAtSentRequestsPage();
            ClickActionsButton();
            bool isStatusWithdrawn = ValidateSentRequestStatus(withdrawsent);
            Assert.IsTrue(isStatusWithdrawn);
        }


        //Sent Request Actions - Completed
        public void CompleteSentRequest(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            ClickManageRequests();
            ClickSentRequests();
            ValidateAtSentRequestsPage();
            ClickActionsButton();
            bool isStatusCompleted = ValidateSentRequestStatus(completesent);
            Assert.IsTrue(isStatusCompleted);
        }


        public void ClickSentRequests()
        {
            SentRequests.Click();
        }

        public void ValidateAtSentRequestsPage()
        {
            bool isSentRequestsPage = SentRequestsTitle.Displayed;
            Assert.IsTrue(isSentRequestsPage);
        }

        public void ClickActionsButton()
        {
            ActionsButton.Click();
        }

        public bool ValidateSentRequestStatus(string status)
        {

            if (SentRequestStatus.Text == status)
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
