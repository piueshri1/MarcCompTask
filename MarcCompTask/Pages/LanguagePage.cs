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
    class LanguagePage
    {
        LogInPage logInPage;
        DescriptionPage descriptionPage;
        public LanguagePage()
        {
            logInPage = new LogInPage();
            descriptionPage = new DescriptionPage();
            PageFactory.InitElements(CommonDriver.driver, this);
        }

        //Page Factory
    
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/thead/tr/th[3]/div")]
        private IWebElement AddNewLangBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/div/div[1]/input")]
        private IWebElement AddLangText { get; set; }
        [FindsBy(How = How.XPath, Using = "//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[2]/select[1]")]
        private IWebElement Languagedropdown { get; set; }
        [FindsBy(How = How.XPath, Using = "//option[contains(text(),'Fluent')]")]
        private IWebElement LangLevel { get; set; }
        [FindsBy(How = How.XPath, Using = "//body/div[@id='account-profile-section']/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/div[1]/div[3]/input[1]")]
        private IWebElement AddLang { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[1]")]
        private IWebElement AddedLanguage { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement Message { get; set; }
        [FindsBy(How = How.XPath, Using = "//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[1]/i[1]")]
        private IWebElement EditLangBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]")]
        private IWebElement ClearLangText { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/div[1]/input[1]")]
        private IWebElement EditLangText { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/span[1]/input[1]")]
        private IWebElement UpdateLang { get; set; }
        [FindsBy(How = How.XPath, Using = "//body[1]/div[1]/div[1]/section[2]/div[1]/div[1]/div[1]/div[3]/form[1]/div[2]/div[1]/div[2]/div[1]/table[1]/tbody[1]/tr[1]/td[3]/span[2]/i[1]")]
        private IWebElement DeleteLang { get; set; }


        //Read Data from Excel
        private string language = ExcelLib.ReadData(1, "Language");
        private string validatelanguagemessage = ExcelLib.ReadData(1, "ValidateLanguageMessage");
        private string editlanguage = ExcelLib.ReadData(1, "EditLanguage");




        //adding language
        public void Language(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            descriptionPage.ValidateProfilePage();
            ClickAddNewLanguage();
            EnterLanguage(language);
            ChooseLanguageLevel();
            ClickAdd();
            bool isMessage = ValidateLanguageSavedMessage();
            Assert.IsTrue(isMessage);
            bool isLanguage = ValidateAddedLanguage();
            Assert.IsTrue(isLanguage);
            EditLanguage(editlanguage);
            //DeleteLanguage();
        }


        public void ClickAddNewLanguage()
        {
            //click add new for language
            AddNewLangBtn.Click();
        }

        public void EnterLanguage(string language)
        {
            // enter language
            AddLangText.SendKeys(language);
        }

        public void ChooseLanguageLevel()
        {
            //choose language lavel
            Languagedropdown.Click();
            LangLevel.Click();
        }

        public void ClickAdd()
        {
            //click add for language
            AddLang.Click();

        }

        public bool ValidateLanguageSavedMessage()
        {

            if (Message.Text == validatelanguagemessage)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ValidateAddedLanguage()
        {

            //validate language is added
            if (AddedLanguage.Text == language)
            {
                //Console.WriteLine("Language is added, test passed");
                return true;
            }
            else
            {
                //Console.WriteLine("Language is not added, test failed");
                return false;
            }
        }


        public void EditLanguage(string editlanguage)
        {
            //Edit Language Button
            EditLangBtn.Click();

            //Edit Language
            ClearLangText.Clear();
            EditLangText.SendKeys(editlanguage);

            //Click Add
            UpdateLang.Click();

        }

        public void DeleteLanguage()
        {

            //Delete Language            
            DeleteLang.Click();

        }

    }
}
