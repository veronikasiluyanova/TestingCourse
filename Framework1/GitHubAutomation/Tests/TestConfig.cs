using AirAsiaAutomation.Driver;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;

namespace AirAsiaAutomation.Tests
{
    public class TestConfig
    {
        protected IWebDriver Driver { get; set; }

        [SetUp]
        public void TestStart()
        {
            Driver = DriverSingleton.GetDriver();
        }

        [TearDown]
        public void TestFinish()
        {
            if (TestContext.CurrentContext.Result.Outcome == ResultState.Failure)
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\Screenshots";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\Screenshot" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
            }

            DriverSingleton.CloseDriver();
        }
    }
}
