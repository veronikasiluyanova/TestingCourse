using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class FlightSelectPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "select-bottom-booking-summary-airasia-button-inner-button-booking-summary-heatmap")]
        private IWebElement continueButton;

        public FlightSelectPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public AddOnsPage ClickContinueButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("select-bottom-booking-summary-airasia-button-inner-button-booking-summary-heatmap")));
            continueButton.Click();
            return new AddOnsPage(driver);
        }
    }
}
