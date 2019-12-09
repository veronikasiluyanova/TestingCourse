using AirAsiaAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class SearchHotelPage
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
        

        public SearchHotelPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public SearchHotelPage InputBookingData(string destination, string checkInDate, string checkOutDate)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@data-lob='hotelOnly']")));
            hotelOnlyButton.Click();
            destinationField.Clear();
            destinationField.SendKeys(destination);
            checkInDateField.SendKeys(checkInDate);
            checkOutDateField.SendKeys(checkOutDate);
            return this;
        }

        public SearchHotelPage ClickHotelSearchButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("H-searchButtonExt1")));
            hotelSearchButton.Click();
            return this;
        }
    }
}
