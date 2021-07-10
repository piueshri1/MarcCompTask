using AventStack.ExtentReports;
using MarcCompTask.ExtentReport;
using MarcCompTask.Pages;
using MarcCompTask.Utilities;
using MarcCompTask.Utils;
using NUnit.Framework;
using System;

namespace MarcCompTask.Test
{
    [TestFixture]
    //[Parallelizable]
    class ProfilePageTest : CommonDriver
    {
        private Helper helper;
        ExtentReports extent = GenerateExtentReport.getInstence();
        ExtentTest test;

        public ProfilePageTest()
        {
            helper = new Helper();
        }
        [Test, Order(0)]
        public void AvailabilityTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Availability method is called");

                //Profile Page object

                ProfilePage profileObj = new ProfilePage();
                profileObj.Availability(driver);

                test.Log(Status.Pass, "Availability updated successfully");
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
        public void HoursTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Hours method is called");

                //Profile Page object

                ProfilePage profileObj = new ProfilePage();
                profileObj.Hours(driver);

                test.Log(Status.Pass, "Hours updated successfully");
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



        [Test, Order(2)]
        public void EarnTargetTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "EarnTarget method is called");

                //Profile Page object

                ProfilePage profileObj = new ProfilePage();
                profileObj.EarnTarget(driver);

                test.Log(Status.Pass, "EarnTarget updated successfully");
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


        [Test, Order(3)]
        public void ProfileDescriptionTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "ProfileDescription method is called");

                //Profile Description object

                DescriptionPage profileDescriptionObj = new DescriptionPage();
                profileDescriptionObj.Description(driver);

                test.Log(Status.Pass, "ProfileDescription updated successfully");
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


        [Test, Order(4)]
        public void LanguageTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Add Language method is called");

                //Language Test object

                LanguagePage profileLanguageObj = new LanguagePage();
                profileLanguageObj.Language(driver);

                test.Log(Status.Pass, "Language added successfully");
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


        [Test, Order(5)]
        public void SkillTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Add Skill method is called");

                //SkillTest object

                SkillsPage profileSkillObj = new SkillsPage();
                profileSkillObj.Skills(driver);

                test.Log(Status.Pass, "Skill added successfully");
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



        [Test, Order(6)]
        public void EducationTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Add Education method is called");

                //EducationTest object

                EducationPage profileEducationObj = new EducationPage();
                profileEducationObj.Education(driver);

                test.Log(Status.Pass, "Education added successfully");
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


        [Test, Order(7)]
        public void CertificationTest()
        {
            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Add Certification method is called");

                //CertificationTest object

                CertificationPage profileCertificationObj = new CertificationPage();
                profileCertificationObj.Certification(driver);

                test.Log(Status.Pass, "Certification added successfully");
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

        //ExtentReports rep = GenerateExtentReport.getInstence();
        //ExtentTest extentTest;


        //[Test]
        //public void EditProfileTest()
        //{
        //    try
        //    {

        //        extentTest = rep.CreateTest("EditProfileTest");
        //        extentTest.Log(Status.Info, "Startin the EditProfileTest test");
        //        ProfilePage profilePage = new ProfilePage();
        //        profilePage.EditProfile(driver);
        //        profilePage.EditDescription(driver);
        //        profilePage.EditNewLanguage(driver);
        //        profilePage.UpdateLanguage(driver);
        //        profilePage.DeleteLanguage(driver);
        //        profilePage.EditNewSkill(driver);
        //        profilePage.AddEducation(driver);
        //        profilePage.AddCertification(driver);
        //        extentTest.Log(Status.Pass, "test pass");

        //       // rep.Flush();
        //    }
        //    catch (Exception msg)
        //    {
        //        string ScreenShotPath = TakeScreenShots.CaptureScreenshotAndReturnModel(driver, "screenshot");
        //        Assert.Fail("Test fail at Edit profile", msg.Message);
        //        extentTest.Log(Status.Fail, "test fail");
        //        extentTest.AddScreenCaptureFromPath(ScreenShotPath);


        //        rep.Flush();
        //    }
        //}

    }
}
