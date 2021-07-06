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
    class CertificationPage
    {
       
        private readonly LogInPage logInPage = new LogInPage();
        private readonly DescriptionPage descriptionPage = new DescriptionPage();


        public CertificationPage()
        {
    
            PageFactory.InitElements(CommonDriver.driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/thead/tr/th[4]/div")]
        private IWebElement AddNew { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input")]
        private IWebElement Certificate { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[1]/input")]
        private IWebElement CertifiedFrom { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[2]/div[2]/select/option[13]")]
        private IWebElement Year { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[1]")]
        private IWebElement Add { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/table/tbody/tr/td[1]")]
        private IWebElement AddedCertificate { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement Message { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[1]/a[4]")]
        private IWebElement CertificationsTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[4]/span[1]/i[1]")]
        private IWebElement EditCertificationBtn { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement ClearCertificationText { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/div[1]/div[1]/input[1]")]
        private IWebElement EditCertificationText { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[1]/div[1]/span[1]/input[1]")]
        private IWebElement UpdateCertification { get; set; }
        [FindsBy(How = How.XPath, Using = "//tbody/tr[1]/td[4]/span[2]/i[1]")]
        private IWebElement DeleteCertification { get; set; }


        //Read data from Excel
        private string certificate = ExcelLib.ReadData(1, "Certificate");
        private string certifiedfrom = ExcelLib.ReadData(1, "CertifiedFrom");
        private string certificatemessage = ExcelLib.ReadData(1, "CertificateMessage");
        private string editcertificate = ExcelLib.ReadData(1, "EditCertificate");


        //adding a certification
        public void Certification(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            descriptionPage.ValidateProfilePage();
            ClickCertificationsTab(driver);
            ClickAddNew();
            EnterCertificate(certificate);
            EnterCertifiedFrom(certifiedfrom);
            SelectYear();
            ClickAdd();
            bool isMessage = ValidateCertificateSavedMessage(certificatemessage);
            Assert.IsTrue(isMessage);
            bool isCertificate = ValidateAddedCertificate(certificate);
            Assert.IsTrue(isCertificate);
            EditCertification(editcertificate);
            DeleteNewCertification();
        }

        public void ClickCertificationsTab(IWebDriver driver)
        {
            Wait.ElementExist(driver, "XPath", "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[1]/div/input", 5);
            //click Certifications Tab
            CertificationsTab.Click();
        }

        public void ClickAddNew()
        {
            //click add new for Certifications
            AddNew.Click();
        }

        public void EnterCertificate(string certificate)
        {
            // enter Certificate
            Certificate.SendKeys(certificate);
        }

        public void EnterCertifiedFrom(string certifiedfrom)
        {
            // enter Certified From
            CertifiedFrom.SendKeys(certifiedfrom);
        }


        public void SelectYear()
        {
            //select year
            Year.Click();
        }

        public void ClickAdd()
        {
            //click add for Certifications
            Add.Click();
        }

        public bool ValidateCertificateSavedMessage(string certificatemessage)
        {

            if (Message.Text == certificatemessage)
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

        public bool ValidateAddedCertificate(string certificate)
        {

            //validate Certificate is added
            if (AddedCertificate.Text == certificate)
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


        public void EditCertification(string editcertificate)
        {
            //Edit Education Button
            EditCertificationBtn.Click();

            //Edit Education
            ClearCertificationText.Clear();
            EditCertificationText.SendKeys(editcertificate);


            //Click Update Education
            UpdateCertification.Click();

        }

        public void DeleteNewCertification()
        {
            //Delete Education            
            DeleteCertification.Click();

        }

    }
}
