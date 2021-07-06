using AventStack.ExtentReports;
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
    [Parallelizable]
    class ShareSkillsTest : CommonDriver
    {
        [Test]
        public void AddShareSkill()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "AddShareSkill method is called");

                //Share Skill page object

                ShareSkillsPage shareskillObj = new ShareSkillsPage();
                shareskillObj.createShareSkill(driver);

                test.Log(Status.Pass, "Share Skill added successfully");
                test.Pass("Test Passed");

            }
            catch (Exception e)
            {

                var mediaEntity = Helper.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }



        [Test]
        public void EditShareSkill()
        {

            try
            {

                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "EditShareSkill method is called");

                //Manage Listings object

                NavigateManageListningPage managelistingsObj = new NavigateManageListningPage();

                managelistingsObj.ClickManageListings(driver);


                //Edit Share Skill object

                ShareSkillsPage shareskillObj = new ShareSkillsPage();

                shareskillObj.EditShareSkill(driver);

                test.Log(Status.Pass, "ShareSkill updated successfully");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {

                var mediaEntity = Helper.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }
        }


        [Test]
        public void DeleteShareSkill()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "DeleteShareSkill method is called");

                //Manage Listings object

                NavigateManageListningPage managelistingsObj = new NavigateManageListningPage();

                managelistingsObj.ClickManageListings(driver);


                //Delete Share Skill object

                ShareSkillsPage shareskillObj = new ShareSkillsPage();

                shareskillObj.DeleteShareSkill(driver);

                test.Log(Status.Pass, "ShareSkill deleted successfully");
                test.Pass("Test Passed");
            }
            catch (Exception e)
            {

                var mediaEntity = Helper.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
                test.Log(Status.Fail, e.StackTrace.ToString());
                test.Fail("Test Failed", mediaEntity);
            }

        }
    }
}
