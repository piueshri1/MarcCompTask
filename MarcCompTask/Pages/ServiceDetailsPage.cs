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
    class ServiceDetailsPage
    {
        LogInPage logInPage;
        SearchPage searchPage;

        public ServiceDetailsPage()
        {
            // this.driver = driver;
            logInPage = new LogInPage();
            searchPage = new SearchPage();
            PageFactory.InitElements(CommonDriver.driver, this);
        }
        //page factory design pattern
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[1]/div/div[1]/div/a")]
        private IWebElement ChatButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[3]")]
        private IWebElement Request { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-detail-section']/div[2]/div/div[2]/div[2]/div[2]/div/div[2]/div/div[1]/textarea")]
        private IWebElement MessageTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[4]/div/div[3]/button[1]")]
        private IWebElement Yes { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement Message { get; set; }

        //Read data from Excel
        private string messagetoseller = ExcelLib.ReadData(1, "MessageToSeller");
        private string sentrequestmessage = ExcelLib.ReadData(1, "SentRequestMessage");

        public void SendServiceRequest(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            searchPage.SearchSkillsByAllCategories(driver);
            searchPage.ClickSearchedSkill();
            ValidateYouAreAtServiceDetailPage();
            EnterMessageToSeller(messagetoseller);
            ClickRequest();
            ClickYes();
            bool isRequestSent = ValidateRequestSent(driver,sentrequestmessage);
            Assert.IsTrue(isRequestSent);

        }



        public void ValidateYouAreAtServiceDetailPage()
        {
            bool isServicePage = ChatButton.Displayed;
            Assert.IsTrue(isServicePage);
        }

        public void ClickChat()
        {
            //click chat button
            ChatButton.Click();
        }


        public void EnterMessageToSeller(string messagetoseller)
        {
            //enter message in message text box
            MessageTextBox.SendKeys(messagetoseller);

        }

        public void ClickRequest()
        {
            //click request button
            Request.Click();
        }


        public void ClickYes()
        {
            //click yes on confirm popup
            Yes.Click();
        }

        public bool ValidateRequestSent(IWebDriver driver,string sentrequestmessage)
        {
            Wait.ElementExist(driver, "XPath", "/html/body/div[1]/div", 1000);
            //validate request is sent
            if (Message.Text == sentrequestmessage)
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
