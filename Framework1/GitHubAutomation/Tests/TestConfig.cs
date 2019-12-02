using AirAsiaAutomation.Driver;
using NUnit.Framework;
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
        public void OpenDriver()
        {
            Driver = DriverSingleton.GetDriver();
        }

        protected void MakeScreenshotWhenFail(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                string screenFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screens";
                Directory.CreateDirectory(screenFolder);
                var screen = Driver.TakeScreenshot();
                screen.SaveAsFile(screenFolder + @"\Screenshot" + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                    ScreenshotImageFormat.Png);
                throw;
            }
        }

        [TearDown]
        public void ClearDriver()
        {
            DriverSingleton.CloseDriver();
        }
    }
}
