using MarcCompTask.Utilities;
using MarcCompTask.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using static MarcCompTask.Utilities.Helper;

namespace MarcCompTask.Pages
{
    class ShareSkillsPage
    {
        LogInPage logInPage;
        public ShareSkillsPage()
        {
            logInPage = new LogInPage();
            PageFactory.InitElements(CommonDriver.driver, this);
        }

        //Finding the Share Skill Button
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[1]/div/div[2]/a")]
        private IWebElement ShareSkillButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input")]
        private IWebElement Title { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea")]
        private IWebElement Description { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[2]")]
        private IWebElement GraphicsDesign { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[3]")]
        private IWebElement DigitalMarketing { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[4]")]
        private IWebElement WritingTranslation { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[5]")]
        private IWebElement VideoAnimation { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[6]")]
        private IWebElement MusicAudio { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]")]
        private IWebElement ProgrammingTech { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[8]")]
        private IWebElement Business { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[9]")]
        private IWebElement FunLifestyle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[2]")]
        private IWebElement SubCategory { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input")]
        private IWebElement Tags { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")]
        private IWebElement HourlyBasisService { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input")]
        private IWebElement OneOffService { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")]
        private IWebElement Onsite { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")]
        private IWebElement Online { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input")]
        private IWebElement StartDate { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input")]
        private IWebElement EndDate { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")]
        private IWebElement SkillExchange { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[2]/div/div[2]/div/input")]
        private IWebElement Credit { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/input")]
        private IWebElement CreditServiceCharge { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")]
        private IWebElement SkillExchangeTag { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")]
        private IWebElement Active { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[10]/div[2]/div/div[2]/div/input")]
        private IWebElement Hidden { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-listing-section']/div[2]/div/form/div[11]/div/input[1]")]
        private IWebElement SaveButton { get; set; }

        //Finding the Edit Button
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[8]/div[1]/button[2]/i[1]")]
        private IWebElement Edit { get; set; }
        [FindsBy(How = How.XPath, Using = "//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[1]/div[1]/div[2]/div[1]/div[1]/input[1]")]
        private IWebElement EditTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[2]/div[1]/div[2]/div[1]/textarea[1]")]
        private IWebElement EditDescription { get; set; }
        [FindsBy(How = How.XPath, Using = "//body/div[1]/div[1]/div[1]/div[2]/div[1]/form[1]/div[11]/div[1]/input[1]")]
        private IWebElement SaveB { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[3]")]
        private IWebElement UpdateTitle { get; set; }

        //Finding the delete Button
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[8]/div[1]/button[3]/i[1]")]
        private IWebElement Delete { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'Yes')]")]
        private IWebElement DeleteYes { get; set; }
        [FindsBy(How = How.XPath, Using = "/html[1]/body[1]/div[1]/div[1]")]
        private IWebElement Message { get; set; }


        //Read Data from Excel
        private string title = ExcelLib.ReadData(1, "Title");
        private string description = ExcelLib.ReadData(1, "Description");
        private string category = ExcelLib.ReadData(1, "Category");
        private string tags = ExcelLib.ReadData(1, "Tags");
        private string serviceType = ExcelLib.ReadData(1, "ServiceType");
        private string locationType = ExcelLib.ReadData(1, "LocationType");
        private string skillTrade = ExcelLib.ReadData(1, "SkillTrade");
        private string active = ExcelLib.ReadData(1, "Active");
        private string skillExchangeTag = ExcelLib.ReadData(1, "SkillExchangeTag");
        private string creditServiceCharge = ExcelLib.ReadData(1, "CreditServiceCharge");
        private int addDaysToStartDate = Convert.ToInt32(ExcelLib.ReadData(1, "AddDaysInCurrentDateToStart"));
        private int addDaysToEndDate = Convert.ToInt32(ExcelLib.ReadData(1, "AddDaysInCurrentDateToEnd"));

        //Edit
        private string editTitle = ExcelLib.ReadData(1, "EditTitle");
        private string editDescription = ExcelLib.ReadData(1, "EditDescription");

        //Delete
        private string deleteMessage = ExcelLib.ReadData(1, "DeleteMessage");


        public void createShareSkill(IWebDriver driver)

        {
            logInPage.LoginSteps(driver);
            ClickShareSkill();
            EnterTitle(title);
            EnterDescription(description);
            SelectCategory(category);
            SelectSubCategory();
            EnterTags(tags);
            SelectServiceType(serviceType);
            SelectLocationType(locationType);
            EnterStartDate(addDaysToStartDate);
            EnterEndDate(addDaysToStartDate, addDaysToEndDate);
            SelectSkillTrade(skillTrade, skillExchangeTag, creditServiceCharge);
            //WorkSamples();
            SelectActive(active);
            ClickSaveButton();
        }

        public void ClickShareSkill()
        {

            //Click Share Skill Button from Profile Page

            ShareSkillButton.Click();
        }

        public void EnterTitle(string title)
        {

            //Enter Title
            Title.SendKeys(title);

        }

        public void EnterDescription(string description)
        {

            //Enter Description
            Description.SendKeys(description);
        }

        public void SelectCategory(string category)
        {

            switch (category)
            {
                case "Graphics & Design":

                    GraphicsDesign.Click();
                    break;

                case "Digital Marketing":
                    DigitalMarketing.Click();
                    break;

                case "Writing & Translation":
                    WritingTranslation.Click();
                    break;

                case "Video & Animation":
                    VideoAnimation.Click();
                    break;


                case "Music & Audio":
                    MusicAudio.Click();
                    break;

                case "Programming & Tech":
                    ProgrammingTech.Click();
                    break;

                case "Business":
                    Business.Click();
                    break;


                default:
                    FunLifestyle.Click();
                    break;

            }
        }

        public void SelectSubCategory()
        {

            SubCategory.Click();

        }

        public void EnterTags(string tags)
        {

            //Enter Tags
            Tags.SendKeys(tags);
            Tags.SendKeys(Keys.Enter);
        }


        public void SelectServiceType(string serviceType)
        {

            if (serviceType == "Hourly basis service")
            {
                HourlyBasisService.Click();

            }
            else
            {
                OneOffService.Click();

            }

        }

        public void SelectLocationType(string locationType)
        {

            if (locationType == "On-site")
            {
                Onsite.Click();

            }
            else
            {
                Online.Click();
            }
        }

        public void EnterStartDate(int addDaysToStartDate)
        {

            DateTime currentDate = DateTime.Now;

            StartDate.Clear();

            StartDate.SendKeys(currentDate.AddDays(addDaysToStartDate).ToString("yyyy-MM-dd"));


        }

        public void EnterEndDate(int addDaysToStartDate, int addDaysToEndDate)
        {

            DateTime currentDate = DateTime.Now;
            EndDate.Clear();

            if (addDaysToStartDate > addDaysToEndDate)
            {
                EndDate.SendKeys(currentDate.AddDays(addDaysToStartDate).ToString("yyyy-MM-dd"));
            }
            else
            {
                EndDate.SendKeys(currentDate.AddDays(addDaysToEndDate).ToString("yyyy-MM-dd"));
            }
        }

        public void SelectSkillTrade(string skillTrade, string skillExchangeTag, string creditServiceCharge)
        {

            if (skillTrade == "Skill-exchange")
            {
                SkillExchange.Click();
                SkillExchangeTag.SendKeys(skillExchangeTag);
                SkillExchangeTag.SendKeys(Keys.Enter);
            }
            else
            {
                Credit.Click();
                CreditServiceCharge.Clear();
                CreditServiceCharge.SendKeys(creditServiceCharge);
            }
        }
        public void SelectActive(string active)
        {

            if (active == "Active")
            {
                Active.Click();
            }
            else
            {
                Hidden.Click();
            }
        }

        public void ClickSaveButton()
        {
            SaveButton.Click();

        }





        public void EditShareSkill(IWebDriver driver)
        {
            EditRecord(driver);
            ValidateServiceUpdatedSuccessfully(editTitle);

        }

        public void EditRecord(IWebDriver driver)
        {

            //Edit Manage Listings            

            Edit.Click();

            EditTitle.Clear();

            EditTitle.SendKeys(editTitle);

            //Edit Description

            EditDescription.Clear();

            EditDescription.SendKeys(editDescription);

            SaveB.Click();

        }


        public bool ValidateServiceUpdatedSuccessfully(string editTitle)
        {

            //Wait.ElementExists(driver, "XPath", "//tbody/tr[1]/td[3]", 5);

            if (UpdateTitle.Text == editTitle)
            {
                return true;

            }
            else
            {
                return false;
            }

        }





        public void DeleteShareSkill(IWebDriver driver)
        {

            DeleteRecord();
            ValidateServiceDeletedSuccessfully();

        }

        public void DeleteRecord()
        {
            var deleteskillPage = new ShareSkillsPage();

            //Delete Manage Listings            

            deleteskillPage.Delete.Click();

            deleteskillPage.DeleteYes.Click();

        }


        public bool ValidateServiceDeletedSuccessfully()
        {
            var deleteskillPage = new ShareSkillsPage();

            if (deleteskillPage.Message.Displayed)
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
