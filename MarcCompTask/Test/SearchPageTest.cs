using AventStack.ExtentReports;
using MarcCompTask.ExtentReport;
using MarcCompTask.Pages;
using MarcCompTask.Utilities;
using MarcCompTask.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarcCompTask.Test
{
    [TestFixture]
   // [Parallelizable]
    class SearchPageTest : CommonDriver
    {
        private Helper helper;
        ExtentReports extent = GenerateExtentReport.getInstence();
        ExtentTest test;
        public SearchPageTest()
        {
            helper = new Helper();
        }

        [Test, Order(0)]
        public void SearchSkillsByAllCategoriesTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "SearchSkillsByAllCategories method is called");

                //Search Page Objects
                SearchPage searchPageObj = new SearchPage();
                searchPageObj.SearchSkillsByAllCategories(driver);

                test.Log(Status.Pass, "SearchSkill by AllCategories successfully");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {

                var mediaEntity = helper.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
                extent.Flush();
            }
         
        }


        [Test, Order(1)]
        public void SearchSkillsByFilterTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "SearchSkillsByFilter method is called");

                //Search Page Objects
                SearchPage searchPageObj = new SearchPage();
                searchPageObj.SearchSkillsByFilters(driver);

                test.Log(Status.Pass, "SearchSkill by Filter successfully");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {

                var mediaEntity = helper.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
                extent.Flush();
            }
           
        }
    }
}
