using MarcCompTask.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
namespace MarcCompTask.Utilities
{
    class Wait
    {
        // generic fuction to wait element exist....


        public static void ElementExist(IWebDriver driver, string locator, string locatorVlaue, int Seconds)
        {
            try
            {
                if (locator == "Id")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(locatorVlaue)));
                }
                if (locator == "XPath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(locatorVlaue)));
                }
                if (locator == "CssSelector")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector(locatorVlaue)));
                }
                if (locator == "Name")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Name(locatorVlaue)));
                }
                if (locator == "LinkText")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.LinkText(locatorVlaue)));
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("test fail waitin for element exist", ex.Message);
            }



        }


        // generic fuction to wait element Clickable....


        public static void ElementToBeClickable(IWebDriver driver, string locator, string locatorVlaue, int Seconds)
        {
            try
            {
                if (locator == "Id")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(locatorVlaue)));
                }
                if (locator == "XPath")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(locatorVlaue)));
                }
                if (locator == "CssSelector")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector(locatorVlaue)));
                }
                if (locator == "Name")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Name(locatorVlaue)));
                }
                if (locator == "LinkText")
                {
                    var wait = new WebDriverWait(driver, new TimeSpan(0, 0, Seconds));
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.LinkText(locatorVlaue)));
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("test fail waitin for element exist", ex.Message);
            }


        }

        // method for implicit wait......

        //public static void ImplicitWait(IWebDriver driver, int time)
        //{
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);
        //}




        //Method to check the element is showing on screen......

        //public static bool ElementVisible(IWebDriver driver, string Locator, string locatorVlaue)
        //{
        //    try
        //    {
        //        if (Locator == "Id")
        //            return driver.FindElement(By.Id(locatorVlaue)).Displayed && driver.FindElement(By.Id(locatorVlaue)).Enabled;
        //        else if (Locator == "XPath")
        //            return driver.FindElement(By.XPath(locatorVlaue)).Displayed && driver.FindElement(By.XPath(locatorVlaue)).Enabled;
        //        else if (Locator == "CssSelector")
        //            return driver.FindElement(By.CssSelector(locatorVlaue)).Displayed && driver.FindElement(By.CssSelector(locatorVlaue)).Enabled;
        //        else if (Locator == "Name")
        //            return driver.FindElement(By.CssSelector(locatorVlaue)).Displayed && driver.FindElement(By.Name(locatorVlaue)).Enabled;
        //        else if (Locator == "LinkText")
        //            return driver.FindElement(By.CssSelector(locatorVlaue)).Displayed && driver.FindElement(By.LinkText(locatorVlaue)).Enabled;
        //        else
        //        {
        //            Console.WriteLine("Invalid Locator value");
        //            return false;
        //        }
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;

        //    }
        //}

        /// validate element present or not.....
       
        //public static bool isElementPresent(By by)
        //{
        //    try
        //    {
        //        CommonDriver.driver.FindElement(by);
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}
    }

}
