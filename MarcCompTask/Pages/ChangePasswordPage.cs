using MarcCompTask.Utilities;
using MarcCompTask.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using static MarcCompTask.Utilities.Helper;
namespace MarcCompTask.Pages
{
    class ChangePasswordPage
    {
        private readonly LogInPage LogInPage = new LogInPage();
        public  ChangePasswordPage()
        {
           
            PageFactory.InitElements(CommonDriver.driver, this);
        }


        [FindsBy(How = How.XPath, Using = "//body/div[@id='account-profile-section']/div[1]/div[1]/div[2]/div[1]/span[1]")]
        private IWebElement ProfileName { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Change Password')]")]
        private IWebElement ChangePass { get; set; }
        [FindsBy(How = How.XPath, Using = "//body/div[4]/div[1]/div[2]/form[1]/div[1]/input[1]")]
        private IWebElement CurrentPass { get; set; }
        [FindsBy(How = How.XPath, Using = "//body/div[4]/div[1]/div[2]/form[1]/div[2]/input[1]")]
        private IWebElement NewPass { get; set; }
        [FindsBy(How = How.XPath, Using = "//body/div[4]/div[1]/div[2]/form[1]/div[3]/input[1]")]
        private IWebElement ConfirmPass { get; set; }
        [FindsBy(How = How.XPath, Using = "//body/div[4]/div[1]/div[2]/form[1]/div[4]/button[1]")]
        private IWebElement SavePassword { get; set; }


        //Read Data from Excel
        private string currentpassword = ExcelLib.ReadData(1, "CurrentPassword");
        private string newpassword = ExcelLib.ReadData(1, "NewPassword");
        private string confirmpassword = ExcelLib.ReadData(1, "ConfirmPassword");

      
        public void ChangePassword(IWebDriver driver)
        {
            LogInPage.LoginSteps(driver);
            ClickChangePassword(driver);
            Wait.ElementExist(driver, "XPath", "//body/div[4]/div[1]/div[2]/form[1]/div[1]/input[1]", 5);

            EnterPasswordDetails(currentpassword, newpassword, confirmpassword);
            ClickSavePassword();

        }


        public void ClickChangePassword(IWebDriver driver)
        {

            Wait.ElementExist(driver, "XPath", "//body/div[@id='account-profile-section']/div[1]/div[1]/div[2]/div[1]/span[1]", 5);


            ProfileName.Click();

            ChangePass.Click();

        }

        public void EnterPasswordDetails(string currentpassword, string newpassword, string confirmpassword)
        {
            try
            {

                CurrentPass.SendKeys(currentpassword);

                NewPass.SendKeys(newpassword);

                ConfirmPass.SendKeys(confirmpassword);
            }
            catch (Exception msg)
            {
                Assert.Fail("Test failed at ChangePassword page", msg.Message);
            }

        }

        public void ClickSavePassword()
        {
            SavePassword.Click();
        }

    }
}
