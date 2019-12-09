using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class MainPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "home-origin-autocomplete-heatmap")]
        private IWebElement departurePlaceField;

        [FindsBy(How = How.Id, Using = "home-destination-autocomplete-heatmap")]
        private IWebElement arrivalPlaceField;
        
        [FindsBy(How = How.Id, Using = "home-depart-date-heatmap")]
        public IWebElement leaveDateField;

        [FindsBy(How = How.Id, Using = "home-return-date-heatmap")]
        private IWebElement returnDateField;

        [FindsBy(How = How.Id, Using = "home-return-date-heatmap")]
        private IWebElement oneWayButton;

        [FindsBy(How = How.Id, Using = "home-airasia-numeric-selector-div-toggle-dropdown-heatmap")]
        private IWebElement passengerNumberListButton;

        [FindsBy(How = How.Id, Using = "home-airasia-numeric-selector-a-home-enabled-increase-main.adult-heatmap")]
        public IWebElement addAdultPassengerButton;

        [FindsBy(How = How.Id, Using = "home-airasia-numeric-selector-a-home-disabled-increase-main.adult-heatmap")]
        public IWebElement addAdultPassengerButtonDisabled;

        [FindsBy(How = How.Id, Using = "home-flight-search-airasia-button-inner-button-select-flight-heatmap")]
        private IWebElement searchButton;

        [FindsBy(How = How.Id, Using = "product-tile-hotels")]
        private IWebElement hotelSelectionButton;

        [FindsBy(How = How.Id, Using = "product-tile-bags_meals_seats")]
        private IWebElement bagsMealsSeatsButton;

        [FindsBy(How = How.XPath, Using = "//a[text()='Flight status']")]
        private IWebElement flightStatusButton;
        

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public MainPage InputRouteData(string departurePlace, string arrivalPlace, string leaveDate, string returnDate)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("home-origin-autocomplete-heatmap")));
            departurePlaceField.Clear();
            departurePlaceField.SendKeys(departurePlace);
            arrivalPlaceField.SendKeys(arrivalPlace);
            leaveDateField.Clear();
            leaveDateField.SendKeys(leaveDate);
            returnDateField.Clear();
            returnDateField.SendKeys(returnDate);
            return this;
        }

        public MainPage AddAdultPassenger(int countOfPassenger)
        {
            for (int i = 0; i < countOfPassenger-1; i++) 
            {
                addAdultPassengerButton.Click();
            }
            return this;
        }

        public FlightSelectPage ClickSearchButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("home-flight-search-airasia-button-inner-button-select-flight-heatmap")));
            searchButton.Click();
            return new FlightSelectPage(driver);
        }

        public SearchHotelPage ClickHotelSelectionButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("product-tile-hotels")));
            hotelSelectionButton.Click();
            return new SearchHotelPage(driver);
        }

        public SearchBookingPage ClickBagsMealsSeatsButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("product-tile-bags_meals_seats")));
            bagsMealsSeatsButton.Click();
            return new SearchBookingPage(driver);
        }

        public MainPage ClickPassengerNumberListButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("home-airasia-numeric-selector-div-toggle-dropdown-heatmap")));
            passengerNumberListButton.Click();
            return this;
        }

        public FlightStatusPage ClickFlighStatusButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[text()='Flight status']")));
            flightStatusButton.Click();
            return new FlightStatusPage(driver);
        }
    }
}
