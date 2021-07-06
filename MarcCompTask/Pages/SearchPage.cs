using MarcCompTask.Utilities;
using MarcCompTask.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using static MarcCompTask.Utilities.Helper;

namespace MarcCompTask.Pages
{
    class SearchPage
    {
        LogInPage loginPage;
       

        public SearchPage()
        {
            // this.driver = driver;
            loginPage = new LogInPage();
            PageFactory.InitElements(CommonDriver.driver, this);
        }

        //page factory design
        [FindsBy(How = How.XPath, Using = "//*[@id='account-profile-section']/div/div[1]/div[1]/i")]
        private IWebElement SearchIcon { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[2]/input")]
        private IWebElement SearchSkillsTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[2]/div/div[2]/div/div/div/div[1]/a[2]/p")]
        private  IWebElement SearchedSkillResult { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='service-search-section']/div[2]/div/section/div/div[1]/div[5]/button[1]")]
        private IWebElement FilterOnline { get; set; }

        //Read data from Excel
        private string searchskill = ExcelLib.ReadData(1, "SearchSkill");

        // searching a skill from all categories
        public void SearchSkillsByAllCategories(IWebDriver driver)
        {
            loginPage.LoginSteps(driver);
            ClickSearchIcon();
            EnterSearchSkill(searchskill);
            bool isSearchResult = ValidateSearchResult(searchskill);
            Assert.IsTrue(isSearchResult);
        }

        //searching a skill using filter
        public void SearchSkillsByFilters(IWebDriver driver)
        {
            loginPage.LoginSteps(driver);
            ClickSearchIcon();
            ClickOnline();
            EnterSearchSkill(searchskill);
            bool isSearchResult = ValidateSearchResult(searchskill);
            Assert.IsTrue(isSearchResult);
        }
        public void ClickSearchIcon()
        {
            //click search icon
            SearchIcon.Click();
        }

        public void EnterSearchSkill(string searchskill)
        {
            //enter skill to search
            SearchSkillsTextBox.SendKeys(searchskill);

            //Click enter
            SearchSkillsTextBox.SendKeys(Keys.Enter);
        }

        public void ClickOnline()
        {
            //click online filter
            FilterOnline.Click();
        }

        public void ClickSearchedSkill()
        {

            //Click search skill
            SearchedSkillResult.Click();
        }


        public bool ValidateSearchResult(string searchskill)
        {

            //validate search skill result
            if (SearchedSkillResult.Text == searchskill)
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
