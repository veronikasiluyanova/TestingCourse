using AirAsiaAutomation.Pages;
using AirAsiaAutomation.Services;
using NUnit.Framework;

namespace AirAsiaAutomation.Tests
{
    public class AirAsiaTests : TestConfig
    {
        private const string IncorrectDateError = "The check-out date must occur after the check-in date. Please change the date.";
        private const string ExpectedHeaderText = "Guest Details";

        [Test]
        public void HotelCheckInDateLaterThanCheckOutDateTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            HotelSearchPage mainPage = new MainPage(Driver)
                     .ClickHotelSelectionButton()
                     .InputBookingData(SearchHotelPageDataCreator.SetAllProperties())
                     .ClickHotelSearchButton();
            Assert.AreEqual(IncorrectDateError, mainPage.incorrectDateError.Text);
        }


        [Test]
        public void FlightBookingTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            GuestDetailsPage mainPage = new MainPage(Driver)
                     .InputRouteData(MainPageDataCreator.SetAllProperties())
                     .ClickSearchButton()
                     .ClickContinueButton()
                     .ClickContinueButton();
            Assert.AreEqual(ExpectedHeaderText, mainPage.header.Text);
        }
    }
}
