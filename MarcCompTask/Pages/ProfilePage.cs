using MarcCompTask.Utilities;
using MarcCompTask.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
namespace MarcCompTask.Pages
{
    class ProfilePage
    {
        LogInPage logInPage;
        DescriptionPage descriptionPage;

        public ProfilePage()
        {
            // this.driver = driver;
            logInPage = new LogInPage();
            descriptionPage = new DescriptionPage();
            PageFactory.InitElements(CommonDriver.driver, this);
        }
        [FindsBy(How =How.XPath , Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/i")]
        private IWebElement AvailabilityIcon { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[2]")]
        private IWebElement PartTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[2]/div/span/select/option[3]")]
        private IWebElement FullTime { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/i")]
        private IWebElement HoursIcon { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[2]")]
        private IWebElement LessThan30Hours { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[3]")]
        private IWebElement MoreThan30Hours { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[3]/div/span/select/option[4]")]
        private IWebElement AsNeeded { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/i")]
        private IWebElement EarnTargetIcon { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[2]")]
        private IWebElement LessThan500 { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[3]")]
        private IWebElement Between500And1000 { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/section[2]/div/div/div/div[2]/div/div/div/div/div/div[3]/div/div[4]/div/span/select/option[4]")]
        private IWebElement MoreThan1000 { get; set; }
        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div")]
        private IWebElement Message { get; set; }

        //Read from Excel
        private string availability = ExcelLib.ReadData(1, "Availability");
        private string hours = ExcelLib.ReadData(1, "Hours");
        private string earntarget = ExcelLib.ReadData(1, "EarnTarget");
        private string availabilitymessage = ExcelLib.ReadData(1, "AvailabilityMessage");
        private string hoursmessage = ExcelLib.ReadData(1, "HoursMessage");
        private string earntargetmessage = ExcelLib.ReadData(1, "EarnTargetMessage");

        //selecting availability
        public void Availability(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            descriptionPage.ValidateProfilePage();
            ClickAvailability();
            SelectAvailability();
            bool isAvailability = ValidateSuccessMessage(availabilitymessage);
            Assert.IsTrue(isAvailability);
        }

        //selecting hours
        public void Hours(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            descriptionPage.ValidateProfilePage();
            ClickHours();
            SelectHours(hours);
            //bool isHours = ValidateSuccessMessage(hoursmessage);
            //Assert.IsTrue(isHours);
        }

        //selecting earn target
        public void EarnTarget(IWebDriver driver)
        {
            logInPage.LoginSteps(driver);
            descriptionPage.ValidateProfilePage();
            ClickEarnTarget();
            SelectEarnTarget(earntarget);
            //bool isEarnTarget = ValidateSuccessMessage(earntargetmessage);
            //Assert.IsTrue(isEarnTarget);
        }

        public void ClickAvailability()
        {
            //click availability icon
            AvailabilityIcon.Click();
        }

        public void SelectAvailability()
        {
            if (availability == "Part Time")
            {
                PartTime.Click();
            }
            else
            {
                FullTime.Click();
            }
        }

        public void ClickHours()
        {
            // click hours icon
            HoursIcon.Click();
        }

        public void SelectHours(string hours)
        {
            switch (hours)
            {
                case "Less than 30hours a week":

                    LessThan30Hours.Click();
                    break;

                case "More than 30hours a week":

                    MoreThan30Hours.Click();
                    break;

                default:

                    AsNeeded.Click();
                    break;
            }

        }

        public void ClickEarnTarget()
        {
            //click earn target
            EarnTargetIcon.Click();
        }

        public void SelectEarnTarget(string earnTarget)
        {
            switch (earnTarget)
            {
                case "Less than $500 per month":

                    LessThan500.Click();
                    break;

                case "Between $500 and $1000 per month":

                    Between500And1000.Click();
                    break;

                default:

                    MoreThan1000.Click();
                    break;
            }
        }

        public bool ValidateSuccessMessage(string message)

        {
            //validate updation message
            if (Message.Text == message)
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