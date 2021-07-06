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
  
    class EducationPage
    {
        LogInPage logInPage;
        DescriptionPage descriptionPage;
        public EducationPage()
        {
            logInPage = new LogInPage();
            descriptionPage = new DescriptionPage();
            PageFactory.InitElements(CommonDriver.driver, this);
        }

        //page factory design pattern
      
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/thead/tr/th[6]/div")]
        private IWebElement AddNew { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[1]/input")]
        private IWebElement College { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[1]/div[2]/select/option[11]")]
        private IWebElement Country  { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[1]/select/option[8]")]
        private IWebElement Title { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[2]/input")]
        private IWebElement Degree { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[2]/div[3]/select/option[8]")]
        private IWebElement Year { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/div/div[3]/div/input[1]")]
        private IWebElement Add { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]")]
        private IWebElement AddedDegree { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement Message { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[3]")]
        private IWebElement EducationTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[6]/span[1]/i[1]")]
        private IWebElement EditEducationBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]")]
        private IWebElement ClearUniversityText { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]")]
        private IWebElement EditUniversityText { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[3]/input[1]")]
        private IWebElement UpdateEducation { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[6]/span[2]/i[1]")]
        private IWebElement DeleteEducation { get; set; }

        //Read data from Excel
        private string university = ExcelLib.ReadData(1, "University");
        private string degree = ExcelLib.ReadData(1, "Degree");
        private string educationmessage = ExcelLib.ReadData(1, "EducationMessage");
        private string edituniversity = ExcelLib.ReadData(1, "EditUniversity");


        //adding education details
        public void Education(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            descriptionPage.ValidateProfilePage();
            ClickEducationTab();
            ClickAddNew();
            EnterCollege(university);
            SelectCountry();
            SelectTitle();
            EnterDegree(degree);
            SelectYear();
            ClickAdd();
            bool isMessage = ValidateEducationSavedMessage(driver,educationmessage);
            Assert.IsTrue(isMessage);
            bool isEducation = ValidateAddedEducation(driver);
            Assert.IsTrue(isEducation);
            EditEducation(edituniversity);
            DeleteNewEducation();
        }

        public void ClickEducationTab()
        {
            //click Education Tab
            EducationTab.Click();
        }

        public void ClickAddNew()
        {
            //click add new 
            AddNew.Click();
        }

        public void EnterCollege(string university)
        {
            // enter College
            College.SendKeys(university);
        }

        public void EnterDegree(string degree)
        {
            // enter Degree
            Degree.SendKeys(degree);
        }

        public void SelectCountry()
        {
            //select country
            Country.Click();
        }

        public void SelectTitle()
        {
            //select title
            Title.Click();
        }

        public void SelectYear()
        {
            //select year
            Year.Click();
        }

        public void ClickAdd()
        {
            //click add 
            Add.Click();
        }

        public bool ValidateEducationSavedMessage(IWebDriver driver,string educationmessage)
        {
            Wait.ElementExist(driver, "XPath", "/html/body/div[1]/div", 30);

            if (Message.Text == educationmessage)
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

        public bool ValidateAddedEducation(IWebDriver driver)
        {
            Wait.ElementExist(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody/tr/td[4]", 30);

            //validate Education is added
            if (AddedDegree.Text == degree)
            {
                //Console.WriteLine("Certificate is added, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Certificate is not added, test failed");
                return false;
            }
        }

        public void EditEducation(string edituniversity)
        {
            //Edit Education Button
            EditEducationBtn.Click();

            //Edit Education
            ClearUniversityText.Clear();
            EditUniversityText.SendKeys(edituniversity);


            //Click Update Education
            UpdateEducation.Click();

        }

        public void DeleteNewEducation()
        {
            //Delete Education            
            DeleteEducation.Click();

        }

    }
}
