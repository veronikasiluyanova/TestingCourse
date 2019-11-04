using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Opera;
using System.Threading;

namespace SeleniumWebDriver
{
    [TestClass]
    public class WebDriverTests
    {
        private const string EmptyFieldError = "Please fill out this field";
        private const string SameFieldError = "Please fill out this field";

        [TestMethod]
        public void EmptyArrivalPlaceFieldTest()
        {
            RemoteWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://www.airnewzealand.com/");
                      
            var departurePlaceField = driver.FindElement(By.XPath("//*[@id='depart-from']"));
            departurePlaceField.Click();
            departurePlaceField.Clear();
            departurePlaceField.SendKeys("Chicago");
            var leaveDatePicker = driver.FindElement(By.XPath("//*[@id='search-leavedate']"));
            leaveDatePicker.Click();
            var leaveDate = driver.FindElement(By.XPath("//*[@id='calendarpanel-0']/div[2]/table/tbody/tr[4]/td[3]/div"));
            leaveDate.Click();
            var returnDate = driver.FindElement(By.XPath("//*[@id='calendarpanel-0']/div[2]/table/tbody/tr[4]/td[6]/div"));
            returnDate.Click();
            var searchButton = driver.FindElement(By.XPath("//*[@id='farefinder-flight-search-container']/div[4]/div[2]/div/button"));
            searchButton.Click();

            string errorMessage = driver.FindElement(By.XPath("//*[@id='toSelectedOption-error']")).GetAttribute("textContent");
            Assert.AreEqual(EmptyFieldError, errorMessage);

            driver.Quit();
        }

        [TestMethod]
        public void SameDepartureAndArrivalPlacesTest()
        {
            RemoteWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://www.airnewzealand.com/");

            var departurePlaceField = driver.FindElement(By.XPath("//*[@id='depart-from']"));
            departurePlaceField.Click();
            departurePlaceField.Clear();
            departurePlaceField.SendKeys("Chicago");
            var arrivalPlaceField = driver.FindElement(By.XPath("//*[@id='depart-to']"));
            arrivalPlaceField.Click();
            arrivalPlaceField.SendKeys("Chicago");

            var leaveDatePicker = driver.FindElement(By.XPath("//*[@id='search-leavedate']/div/span"));
            leaveDatePicker.Click();
            var leaveDate = driver.FindElement(By.XPath("//*[@id='calendarpanel-0']/div[2]/table/tbody/tr[4]/td[3]/div"));
            leaveDate.Click();
            var returnDate = driver.FindElement(By.XPath("//*[@id='calendarpanel-0']/div[2]/table/tbody/tr[4]/td[6]/div"));
            returnDate.Click();

            var searchButton = driver.FindElement(By.XPath("//*[@id='farefinder-flight-search-container']/div[4]/div[2]/div/button"));
            searchButton.Click();

            string errorMessage = driver.FindElement(By.XPath("//*[@id='toSelectedOption-error']")).GetAttribute("textContent");
            Assert.AreEqual(SameFieldError, errorMessage);

            driver.Quit();
        }
    }
}
