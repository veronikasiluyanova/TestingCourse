using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;


namespace SeleniumWebDriver
{
    [TestClass]
    public class WebDriverTests
    {
        private const string EmptyFieldError = "Please fill out this field";
        private const string TooManyPassengersError = "A maximum of 9 passengers applies per online booking. To continue you may either make multiple bookings or call Air New Zealand Reservations on 1‑800‑262‑1234 to complete your booking. ";

        [TestMethod]
        public void EmptyArrivalPlaceFieldTest()
        {
            RemoteWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://www.airnewzealand.com/");
                      
            var departurePlaceField = driver.FindElement(By.XPath("//*[@id='depart-from']"));
            departurePlaceField.Click();
            departurePlaceField.Clear();
            departurePlaceField.SendKeys("Chicago");

            var arrivalPlaceField = driver.FindElement(By.XPath("//*[@id='depart-to']"));
            arrivalPlaceField.Click();

            var oneWayOptionButton = driver.FindElement(By.XPath("//*[@id='field-search-journey-type-oneway']"));
            oneWayOptionButton.Click();

            var leaveDateFiled = driver.FindElement(By.XPath("//*[@id='leaveDate']"));
            leaveDateFiled.SendKeys("11/26");

            var searchButton = driver.FindElement(By.XPath("//*[@type='submit']"));
            searchButton.Click();

            string errorMessage = driver.FindElement(By.XPath("//*[@id='toSelectedOption-error']")).GetAttribute("textContent");
            Assert.AreEqual(EmptyFieldError, errorMessage);

            driver.Quit();
        }

        [TestMethod]
        public void TooManyPassengersTest()
        {
            RemoteWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(@"https://www.airnewzealand.com/");

            var departurePlaceField = driver.FindElement(By.XPath("//INPUT[@id='depart-from']"));
            departurePlaceField.Click();
            departurePlaceField.Clear();
            departurePlaceField.SendKeys("Chicago");
            var arrivalPlaceField = driver.FindElement(By.XPath("//INPUT[@id='depart-to']"));
            arrivalPlaceField.Click();
            arrivalPlaceField.SendKeys("Sydney");

            var oneWayOptionButton = driver.FindElement(By.XPath("//*[@id='field-search-journey-type-oneway']"));
            oneWayOptionButton.Click();

            var leaveDateFiled = driver.FindElement(By.XPath("//*[@id='leaveDate']"));
            leaveDateFiled.SendKeys("11/26");

            var addChildrenPassengerButton = driver.FindElement(By.XPath("//BUTTON[@name='add child']"));
            addChildrenPassengerButton.Click();
            addChildrenPassengerButton.Click();
            addChildrenPassengerButton.Click();
            addChildrenPassengerButton.Click();
            addChildrenPassengerButton.Click();
            addChildrenPassengerButton.Click();
            var addInfantPassengerButton = driver.FindElement(By.XPath("//BUTTON[@name='add infant']"));
            addInfantPassengerButton.Click();
            addInfantPassengerButton.Click();
            addInfantPassengerButton.Click();
            addInfantPassengerButton.Click();

            var searchButton = driver.FindElement(By.XPath("//*[@type='submit']"));
            searchButton.Click();

            string errorMessage = driver.FindElement(By.XPath("//*[@id='paxCounts-error']")).GetAttribute("textContent");
            Assert.AreEqual(TooManyPassengersError, errorMessage);

            driver.Quit();
        }
    }
}
