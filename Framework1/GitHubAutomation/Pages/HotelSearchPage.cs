using AirAsiaAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    [Obsolete]
    public class HotelSearchPage
    {
        IWebDriver driver;
    
        [FindsBy(How = How.XPath, Using = "//a[@data-lob='hotelOnly']")]
        private IWebElement hotelOnlyButton;

        [FindsBy(How = How.Id, Using = "H-destination")]
        private IWebElement destinationField;

        [FindsBy(How = How.Id, Using = "H-fromDate")]
        private IWebElement checkInDateField;

        [FindsBy(How = How.Id, Using = "H-toDate")]
        private IWebElement checkOutDateField;

        [FindsBy(How = How.Id, Using = "H-searchButtonExt1")]
        private IWebElement hotelSearchButton;

        [FindsBy(How = How.XPath, Using = "//a[@class='error-link']")]
        public IWebElement incorrectDateError;
        

        public HotelSearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public HotelSearchPage InputBookingData(SearchHotelPageData searchHotelPageData)
        {
            hotelOnlyButton.Click();
            destinationField.Clear();
            destinationField.SendKeys(searchHotelPageData.Destination);
            checkInDateField.SendKeys(searchHotelPageData.CheckInDate);
            checkOutDateField.SendKeys(searchHotelPageData.CheckOutDate);
            return this;
        }

        public HotelSearchPage ClickHotelSearchButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("H-searchButtonExt1")));
            hotelSearchButton.Click();
            return this;
        }
    }
}
