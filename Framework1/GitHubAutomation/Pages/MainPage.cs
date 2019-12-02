using AirAsiaAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    [Obsolete]
    public class MainPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "home-origin-autocomplete-heatmap")]
        private IWebElement departurePlaceField;

        [FindsBy(How = How.Id, Using = "home-destination-autocomplete-heatmap")]
        private IWebElement arrivalPlaceField;
        
        [FindsBy(How = How.Id, Using = "home-depart-date-heatmap")]
        private IWebElement leaveDateField;

        [FindsBy(How = How.Id, Using = "home-return-date-heatmap")]
        private IWebElement returnDateField;

        [FindsBy(How = How.Id, Using = "home-airasia-numeric-selector-div-toggle-dropdown-heatmap")]
        public IWebElement passengerNumberListButton;

        [FindsBy(How = How.Id, Using = "home-airasia-numeric-selector-a-home-enabled-increase-main.adult-heatmap")]
        public IWebElement addAdultPassengerButton;

        [FindsBy(How = How.Id, Using = "home-flight-search-airasia-button-inner-button-select-flight-heatmap")]
        public IWebElement searchButton;

        [FindsBy(How = How.Id, Using = "product-tile-hotels")]
        public IWebElement hotelSelectionButton;

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MainPage InputRouteData(MainPageData mainPageData)
        {
            departurePlaceField.Clear();
            departurePlaceField.SendKeys(mainPageData.DeparturePlace);
            arrivalPlaceField.SendKeys(mainPageData.ArrivalPlace);
            leaveDateField.Clear();
            leaveDateField.SendKeys(mainPageData.LeaveDate);
            returnDateField.Clear();
            returnDateField.SendKeys(mainPageData.ReturnDate);
            return this;
        }

        public void AddAdultPassenger(int countOfPassenger)
        {
            for (int i = 0; i < countOfPassenger-1; i++) 
            {
                addAdultPassengerButton.Click();
            }
        }

        public FlightSelectPage ClickSearchButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("home-flight-search-airasia-button-inner-button-select-flight-heatmap")));
            searchButton.Click();
            return new FlightSelectPage(driver);
        }

        public HotelSearchPage ClickHotelSelectionButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("product-tile-hotels")));
            hotelSelectionButton.Click();
            return new HotelSearchPage(driver);
        }
    }
}
