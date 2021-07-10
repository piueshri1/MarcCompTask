using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using MarcCompTask.Pages;
using MarcCompTask.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text;
using static MarcCompTask.Utilities.Helper;

namespace MarcCompTask.Utils
{
    class CommonDriver
    {
         //intitialise driver
        public static IWebDriver driver { get; set; }
       // public static LogInPage LogIn;
        //public static ExtentReports extent;
        //public static ExtentHtmlReporter hTMLReporter;
        //public static ExtentTest test;


        [OneTimeSetUp]
        public void Initialize()
        {
            //hTMLReporter = new ExtentHtmlReporter(ConstantClass.ReportsPath);
            //hTMLReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
            //extent = new ExtentReports();
            //extent.AttachReporter(hTMLReporter);

            //Defining the browser
            driver = new ChromeDriver();

            //Maximise the window
            driver.Manage().Window.Maximize();

            NavigateUrl();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            ExcelLib.PopulateInCollection(ConstantClass.DataFilePath, "SignUp");
            ExcelLib.PopulateInCollection(ConstantClass.DataFilePath, "Login");
            ExcelLib.PopulateInCollection(ConstantClass.DataFilePath, "ProfilePage");
            ExcelLib.PopulateInCollection(ConstantClass.DataFilePath, "AddSkill");
            ExcelLib.PopulateInCollection(ConstantClass.DataFilePath, "ManageListings");
            ExcelLib.PopulateInCollection(ConstantClass.DataFilePath, "SearchSkill");
            ExcelLib.PopulateInCollection(ConstantClass.DataFilePath, "ServiceDetail");
            ExcelLib.PopulateInCollection(ConstantClass.DataFilePath, "Chat");
            ExcelLib.PopulateInCollection(ConstantClass.DataFilePath, "ManageRequests");



           
            //LogIn = new LoginPage(driver);
            //LogIn.LoginSteps();

        }

        public static string BaseUrl
        {
            get { return ConstantClass.Url; }
        }


        public static void NavigateUrl()
        {
            driver.Navigate().GoToUrl(BaseUrl);
        }


        [OneTimeTearDown]
        public void FinalSteps()
        {
            // close the driver
            driver.Close();
            driver.Quit();
           // extent.Flush();
        }

    }
}
