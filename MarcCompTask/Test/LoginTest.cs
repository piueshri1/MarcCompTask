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
   // [Parallelizable]
    class LoginTest : CommonDriver
    {
        private Helper helper;
        ExtentReports extent = GenerateExtentReport.getInstence();
        ExtentTest test;

        public LoginTest()
        {
            helper = new Helper();
        }
        [Test,Order(0)]
        public void SignUp()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "RegisterUser method is called");

                //Register page object

                SignUpPage registerObj = new SignUpPage();
                registerObj.Register(driver);

                test.Log(Status.Pass, "User Registered Successfully");
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
        public void Login()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "Login method is called");


                //LogInPage objects
                LogInPage loginobj = new LogInPage();
                loginobj.LoginSteps(driver);

                test.Log(Status.Pass, "User login successful");
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


        //[Test]
        //public void ChangePassword()
        //{

        //    try
        //    {
        //        test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
        //        test.Log(Status.Info, "ChangePassword method is called");


        //        //ChangePasswordPage objects
        //        ChangePasswordPage changepasswordobj = new ChangePasswordPage();
        //        changepasswordobj.ChangePassword(driver);

        //        test.Log(Status.Pass, "Password changed successful");
        //        test.Pass("Test Passed");
        //    }
        //    catch (Exception e)
        //    {

        //        var mediaEntity = helper.CaptureScreenshotAndReturnModel(TestContext.CurrentContext.Test.Name.Trim());
        //        test.Log(Status.Fail, e.StackTrace.ToString());
        //        test.Fail("Test Failed", mediaEntity);
        //    }

        //}
    }
}
