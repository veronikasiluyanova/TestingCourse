using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObject
{
    [TestFixture]
    [Obsolete]
    public class Tests
    {
        private IWebDriver driver;
        private const string url = "https://www.airasia.com/en/gb";
        private const string UnableToLocateBookingError = "We're unable to locate your flight booking. You can only search for bookings made with AirAsia or other online travel websites.";

        private MainPageData mainPageData = new MainPageData("Srinagar", "Goa", "10/12/2019", "20/12/2019");

        private int adultPassengerNumber = 9;

        [SetUp]
        public void OpenBrowser()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(900);
        }

        [Test]
        public void NoBookingInformationTest()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.bagsMealsSeatsButton.Click();
            SearchBookingPage searchBookingPage = new SearchBookingPage();
            searchBookingPage.searchButton.Click();
            Assert.AreEqual(UnableToLocateBookingError, searchBookingPage.unableToLocateBookingError.Text);
        }
        
        [Test]
        public void TooManyPassengersTest()
        {
            MainPage mainPage = new MainPage(driver);
            mainPage.InputRouteData(mainPageData);
            mainPage.passengerNumberListButton.Click();
            mainPage.AddAdultPassenger(adultPassengerNumber);
            Assert.IsFalse(mainPage.passengerNumberListButton.Enabled);
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
