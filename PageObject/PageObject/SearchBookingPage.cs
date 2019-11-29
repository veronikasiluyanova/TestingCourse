using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace PageObject
{
    public class SearchBookingPage
    {
        [FindsBy(How = How.Id, Using = "ControlGroupRetrieveBookingExpediaAKView_BookingRetrieveInputExpediaAKView_CONFIRMATIONNUMBER1")]
        private IWebElement bookingNumberField;

        [FindsBy(How = How.Id, Using = "ControlGroupRetrieveBookingExpediaAKView_BookingRetrieveInputExpediaAKView_PAXLASTNAME1")]
        private IWebElement familyNameSurnameField;

        [FindsBy(How = How.Id, Using = "ControlGroupRetrieveBookingExpediaAKView_BookingRetrieveInputExpediaAKView_ButtonRetrieve")]
        public IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='errorSectionContent']/p")]
        public IWebElement unableToLocateBookingError;
    }
}
