using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObject
{
    [Obsolete]
    public class SearchBookingPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "ControlGroupRetrieveBookingExpediaAKView_BookingRetrieveInputExpediaAKView_CONFIRMATIONNUMBER1")]
        private IWebElement bookingNumberField;

        [FindsBy(How = How.Id, Using = "ControlGroupRetrieveBookingExpediaAKView_BookingRetrieveInputExpediaAKView_PAXLASTNAME1")]
        private IWebElement familyNameSurnameField;

        [FindsBy(How = How.Id, Using = "ControlGroupRetrieveBookingExpediaAKView_BookingRetrieveInputExpediaAKView_ButtonRetrieve")]
        public IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='errorSectionContent']/p")]
        public IWebElement unableToLocateBookingError;

        public SearchBookingPage (IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("ControlGroupRetrieveBookingExpediaAKView_BookingRetrieveInputExpediaAKView_CONFIRMATIONNUMBER1")));
        }
        
    }
}
