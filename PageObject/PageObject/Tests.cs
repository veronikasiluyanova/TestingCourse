using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObject
{
    [TestClass]
    [Obsolete]
    public class Tests
    {
        IWebDriver driver = new ChromeDriver();
        private const string NoPersonalDetailsError = "Please review and complete.";

        [TestMethod]
        public void NoPersonalDetailsTest()
        {
            driver.Navigate().GoToUrl("https://www.airnewzealand.com/");
            MainPage mainPage = new MainPage(driver).InputRouteDataAndSearch("Chicago", "Sydney", "11/21");
            FlightBookingPage flightBookingPage = new FlightBookingPage(driver).SelectFlight();
            PassengerDetailsPage passengerDetailsPage = new PassengerDetailsPage(driver).EnterPassengerDetails();
            Assert.AreEqual(NoPersonalDetailsError, passengerDetailsPage.NoPassengerDetailsError.Text);
            driver.Quit();
        }

        [TestMethod]
        public void SelectedNoFlightTest()
        {
            driver.Navigate().GoToUrl("https://www.airnewzealand.com/");
            MainPage mainPage = new MainPage(driver).InputRouteDataAndSearch("Chicago", "Sydney", "11/21");
            FlightBookingPage flightBookingPage = new FlightBookingPage(driver);
            Assert.IsTrue(flightBookingPage.ContinueButton.GetAttribute("aria-disabled") != null);
            driver.Quit();
        }
    }
}
