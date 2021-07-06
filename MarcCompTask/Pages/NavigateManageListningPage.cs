using MarcCompTask.Utils;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarcCompTask.Pages
{
    class NavigateManageListningPage
    {

        LogInPage logInPage;
        public NavigateManageListningPage()
        {
            logInPage = new LogInPage();
            PageFactory.InitElements(CommonDriver.driver, this);
        }
        //Page Factory

        //Finding the Manage Listings tab
        [FindsBy(How =How.XPath , Using = "//a[contains(text(),'Manage Listings')]")]
        private IWebElement ManageListingstab { get; set; }

        // Finding the Manage Listings Page Title
        [FindsBy(How = How.XPath, Using = "//h2[contains(text(),'Manage Listings')]")]
        private IWebElement ManageListings{ get; set; }


        public bool ClickManageListings(IWebDriver driver)

        {
            logInPage.LoginSteps(driver);

            //Click Manage Listings tab

            ManageListingstab.Click();


            //Validate at Manage Listings Page

            if (ManageListings.Text == "Manage Listings")
            {

                return true;
            }
            else
            {
                return false;
            }

            //Assert.That(managelistPage.ManageListings.Text == "Manage Listings");

            //Assert.Pass("Test Passed");

        }

    }
}
