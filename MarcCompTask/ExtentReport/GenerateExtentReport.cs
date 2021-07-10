using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarcCompTask.ExtentReport
{
    class GenerateExtentReport
    {

        private static ExtentReports extentReports;
        private static ExtentHtmlReporter htmlReporter;

        public GenerateExtentReport()
        {

        }
        public static ExtentReports getInstence()
        {
            if (extentReports == null)
            {
                htmlReporter = new ExtentHtmlReporter(@"C:\testingProject\MarcCompTask\MarcCompTask\ExtentReport\GenerateExtentReport.html");
                extentReports = new ExtentReports();
                extentReports.AttachReporter(htmlReporter);
                extentReports.AddSystemInfo("OS", "Windows");
                extentReports.AddSystemInfo("Host Name", "Piue");
                extentReports.AddSystemInfo("Envirment", "QA");
                extentReports.AddSystemInfo("UserNmae", "Piue Shri");
            }
            return extentReports;
        }
    }
}
