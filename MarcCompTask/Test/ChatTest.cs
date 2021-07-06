using AventStack.ExtentReports;
using MarcCompTask.Pages;
using MarcCompTask.Utilities;
using MarcCompTask.Utils;
using NUnit.Framework;
using System;


namespace MarcCompTask.Test
{
    [TestFixture]
    [Parallelizable]
    class ChatTest : CommonDriver
    {
        [Test]
        public void SendChatTest()
        {

            try
            {
                test = extent.CreateTest(TestContext.CurrentContext.Test.Name).Info("Test Started");
                test.Log(Status.Info, "SendChat method is called");

                //Chat Page objects
                ChatPage chatPageObj = new ChatPage();
                chatPageObj.ChatWithSeller(driver);

                test.Log(Status.Pass, "Chat sent successfully");
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
