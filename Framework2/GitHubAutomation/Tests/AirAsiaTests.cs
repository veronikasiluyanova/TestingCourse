using AirAsiaAutomation.Models;
using AirAsiaAutomation.Pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AirAsiaAutomation.Tests
{
    public class AirAsiaTests : TestConfig
    {
        private const string IncorrectDateError = "The check-out date must occur after the check-in date. Please change the date.";
        private const string ExpectedHeaderText = "Guest Details";
        private const string UnableToLocateBookingError = "We're unable to locate your flight booking. You can only search for bookings made with AirAsia or other online travel websites.";
        private const string IncorrectGuestNameError = "Your name must be as stated on your ID or passport in English alphabets (A to Z) only. Special characters or symbols are not allowed.";
        private const string IncorrectFlightNumberError = "Search by route aaaa error Flight number must start with a valid airline code. Example: AK, FD, I5";

        private const string testDate = "05/12/2019";
        private const string testFlightNumber = "AAA";
        private const int testAdultPassengerNumber = 9;
        

        [Test]
        public void HotelCheckInDateLaterThanCheckOutDateTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            SearchHotelPage page = new MainPage(Driver)
                     .ClickHotelSelectionButton()
                     .InputBookingData(new SearchHotelPageData().Destination, new SearchHotelPageData().CheckInDate, new SearchHotelPageData().CheckOutDate)
                     .ClickHotelSearchButton();
            Assert.AreEqual(IncorrectDateError, page.incorrectDateError.Text);
        }


        [Test]
        public void FlightBookingTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            GuestDetailsPage page = new MainPage(Driver)
                     .InputRouteData(new MainPageData().DeparturePlace, new MainPageData().ArrivalPlace, new MainPageData().LeaveDate, new MainPageData().ReturnDate)
                     .ClickSearchButton()
                     .ClickContinueButton()
                     .ClickContinueButton();
            Assert.AreEqual(ExpectedHeaderText, page.header.Text);
        }

        [Test]
        public void NoBookingInformationTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            SearchBookingPage page = new MainPage(Driver)
                .ClickBagsMealsSeatsButton()
                .ClickSearchButton();
            Assert.AreEqual(UnableToLocateBookingError, page.unableToLocateBookingError.Text);
        }

        [Test]
        public void TooManyPassengersTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            MainPage page = new MainPage(Driver)
                .InputRouteData(new MainPageData().DeparturePlace, new MainPageData().ArrivalPlace, new MainPageData().LeaveDate, new MainPageData().ReturnDate)
                .ClickPassengerNumberListButton()
                .AddAdultPassenger(testAdultPassengerNumber);
            Assert.IsTrue(page.addAdultPassengerButtonDisabled.Displayed);
        }

        [Test]
        public void EmptyArrivalFieldTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            FlightSelectPage page = new MainPage(Driver)
                    .InputRouteData(new MainPageData().DeparturePlace, string.Empty, new MainPageData().LeaveDate, new MainPageData().ReturnDate)
                    .ClickSearchButton();
            Assert.IsTrue(Driver.FindElement(By.TagName("em")).Displayed);
        }

        [Test]
        public void EmptyDepartureFieldTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            FlightSelectPage page = new MainPage(Driver)
                    .InputRouteData(string.Empty, new MainPageData().ArrivalPlace, new MainPageData().LeaveDate, new MainPageData().ReturnDate)
                    .ClickSearchButton();
            Assert.IsTrue(Driver.FindElement(By.TagName("em")).Displayed);
        }

        [Test]
        public void SameDepartureandArrivalPlacesTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            FlightSelectPage page = new MainPage(Driver)
                    .InputRouteData(new MainPageData().DeparturePlace, new MainPageData().DeparturePlace, new MainPageData().LeaveDate, new MainPageData().ReturnDate)
                    .ClickSearchButton();
            Assert.IsTrue(Driver.FindElement(By.TagName("em")).Displayed);
        }

        [Test]
        public void IncorrectFormatOfGuestNameTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            GuestDetailsPage page = new MainPage(Driver)
                     .InputRouteData(new MainPageData().DeparturePlace, new MainPageData().ArrivalPlace, new MainPageData().LeaveDate, new MainPageData().ReturnDate)
                     .ClickSearchButton()
                     .ClickContinueButton()
                     .ClickContinueButton()
                     .InputGuestData(new GuestDetailsPageData().GivenName, new GuestDetailsPageData().Surname, new GuestDetailsPageData().Email);
            Assert.AreEqual(IncorrectGuestNameError, page.incorrectNameError.Text);
        }

        [Test]
        public void IncorrectFormatOfBookingNumberTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            FlightStatusPage page = new MainPage(Driver)
                .ClickFlighStatusButton()
                .InputFlightNumber(testFlightNumber)
                .ClickSearchButton();
            Assert.AreEqual(IncorrectFlightNumberError, page.incorrectFormatOfNumberError.Text);
        }

        [Test]
        public void BookingOnDayEarlierThanCurrentTest()
        {
            Driver.Navigate().GoToUrl("https://www.airasia.com/en/gb");
            MainPage page = new MainPage(Driver)
                     .InputRouteData(new MainPageData().DeparturePlace, new MainPageData().ArrivalPlace, testDate, new MainPageData().ReturnDate);
            Assert.AreNotEqual(page.leaveDateField.Text, testDate);
        }
    }
}
