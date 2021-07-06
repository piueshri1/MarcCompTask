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
    class SkillsPage
    {
        LogInPage logInPage;
        DescriptionPage descriptionPage;
        public SkillsPage()
        {
            logInPage = new LogInPage();
            descriptionPage = new DescriptionPage();
            PageFactory.InitElements(CommonDriver.driver, this);
        }
        //Page Factory design
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNew { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/span/input[1]")]
        private IWebElement Add { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[2]")]
        private IWebElement SkillsTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[1]/input")]
        private IWebElement Skill { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/div/div[2]/select/option[2]")]
        private IWebElement SkillLevel { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]")]
        private IWebElement AddedSkill { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement Message { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[3]/span[1]/i[1]")]
        private IWebElement EditSkillBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]")]
        private IWebElement ClearSkillText { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]/html/body/div[1]/div")]
        private IWebElement EditSkillText { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/span[1]/input[1]")]
        private IWebElement UpdateSkill { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[3]/span[2]/i[1]")]
        private IWebElement DeleteSkill { get; set; }

        //Read data from Excel
        private string skill = ExcelLib.ReadData(1, "Skill");
        private string skillmessage = ExcelLib.ReadData(1, "SkillMessage");
        private string editskill = ExcelLib.ReadData(1, "EditSkill");

        // adding a skill
        public void Skills(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            descriptionPage.ValidateProfilePage();
            ClickSkillsTab();
            ClickAddNew();
            EnterSkill(skill);
            ChooseSkillLevel();
            ClickAdd();
            bool isMessage = ValidateSkillSavedMessage(skillmessage);
            Assert.IsTrue(isMessage);
            bool isSkill = ValidateAddedSkill(driver,skill);
            Assert.IsTrue(isSkill);
            EditSkill(editskill);
            DeleteNewSkill();
        }


        public void ClickSkillsTab()
        {
            //click skills tab
            SkillsTab.Click();
        }

        public void ClickAddNew()
        {
            //click add new for skill
            AddNew.Click();
        }

        public void ClickAdd()
        {
            //click add for skill
            Add.Click();
        }


        public void EnterSkill(string skill)
        {
            //enter skill
            Skill.SendKeys(skill);
        }

        public void ChooseSkillLevel()
        {
            //choose skill level
            SkillLevel.Click();

        }

        public bool ValidateSkillSavedMessage(string skillmessage)
        {

            if (Message.Text == skillmessage)
            {
                //Console.WriteLine("Success message is displayed, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Success message is not displayed, test failed");
                return false;
            }
        }

        public bool ValidateAddedSkill(IWebDriver driver,string skill)
        {
            Wait.ElementExist(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[3]/div/div[2]/div/table/tbody/tr/td[1]", 30);

            //validate skill is added
            if (AddedSkill.Text == skill)
            {
                //Console.WriteLine("Skill is added, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Skill is not added, test failed");
                return false;
            }
        }


        public void EditSkill(string editskill)
        {

            //Edit Skill Button
            EditSkillBtn.Click();

            //Edit Skill
            ClearSkillText.Clear();
            EditSkillText.SendKeys(editskill);

            //Click Update Skill
            UpdateSkill.Click();

        }

        public void DeleteNewSkill()
        {

            //Delete Skill            
            DeleteSkill.Click();

        }
    }
}
