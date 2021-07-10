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
    class ManageRequestTest : CommonDriver
    {
        private Helper helper;
        ExtentReports extent = GenerateExtentReport.getInstence();
        ExtentTest test;
        public ManageRequestTest()
        {
            helper = new Helper();
        }

        [Test, Order(0)]
        public void AcceptRequestTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "AcceptRequest method is called");

                //Manage Requests Page Objects
                ManageRequestPage manageRequestObj = new ManageRequestPage();
                manageRequestObj.AcceptReceivedRequest(driver);

                test.Log(Status.Pass, "Received Request Accepted");
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
        public void DeclineRequest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "DeclineRequest method is called");

                //Manage Requests Page Objects
                ManageRequestPage manageRequestObj = new ManageRequestPage();
                manageRequestObj.DeclineReceivedRequest(driver);

                test.Log(Status.Pass, "Received Request Declined");
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
        public void WithdrawSentRequest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "WithdrawSentRequest method is called");

                //Manage Requests Page Objects
                ManageRequestPage manageRequestObj = new ManageRequestPage();
                manageRequestObj.WithdrawSentRequest(driver);

                test.Log(Status.Pass, "Sent Request Withdrawn");
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
        public void CompleteSentRequest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "CompleteSentRequest method is called");

                //Register page object

                //Manage Requests Page Objects
                ManageRequestPage manageRequestObj = new ManageRequestPage();
                manageRequestObj.CompleteSentRequest(driver);

                test.Log(Status.Pass, "Sent Request Completed");
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
