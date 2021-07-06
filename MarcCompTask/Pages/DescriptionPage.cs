using MarcCompTask.Utilities;
using MarcCompTask.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static MarcCompTask.Utilities.Helper;

namespace MarcCompTask.Pages
{
    class DescriptionPage
    {
        LogInPage loginPage;
        public DescriptionPage()
        {
            loginPage = new LogInPage();
            PageFactory.InitElements(CommonDriver.driver, this);
        }
       
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3")]
        private IWebElement DescriptionText { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/h3/span/i")]
        private IWebElement DescriptionIcon { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/div[1]/textarea")]
        private IWebElement DescriptionTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/form/div/div/div[2]/button")]
        private IWebElement Save { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span")]
        private IWebElement SavedDescription { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement Message { get; set; }

        //Read Data from Excel
        private string profiledescription = ExcelLib.ReadData(1, "ProfileDescription");
        private string descriptionmessage = ExcelLib.ReadData(1, "DescriptionMessage");


        //adding profile description
        public void Description(IWebDriver driver)
        {
            loginPage.LoginSteps(driver);
            ValidateProfilePage();
            ClickDescriptionIcon();
            EnterDescription(profiledescription);
            ClickSave();
            bool isMessage = ValidateDescriptionSavedMessage(descriptionmessage);
            Assert.IsTrue(isMessage);
            bool isDescription = ValidateSavedDescription(driver,profiledescription);
            Assert.IsTrue(isDescription);
        }

        public void ValidateProfilePage()
        {
            bool isProfilePage = DescriptionText.Displayed;
            Assert.IsTrue(isProfilePage);
        }

        public void ClickDescriptionIcon()
        {
            //click description icon
            DescriptionIcon.Click();
        }

        public void EnterDescription(string profiledescription)
        {
            //enter description
            DescriptionTextBox.Clear();
            DescriptionTextBox.SendKeys(profiledescription);
        }

        public void ClickSave()
        {
            //click save
            Save.Click();

        }

        public bool ValidateDescriptionSavedMessage(string descriptionmessage)
        {

            if (Message.Text == descriptionmessage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateSavedDescription(IWebDriver driver,string profiledescription)
        {
            Wait.ElementExist(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/div/div/div/span", 500);

            //validate description is saved
            if (SavedDescription.Text == profiledescription)
            {
                //Console.WriteLine("Description is saved, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Description is not saved, test failed");
                return false;
            }
        }

    }
}
