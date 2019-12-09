using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class AddOnsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "addons-bottom-booking-summary-airasia-button-inner-button-booking-summary-heatmap")]
        private IWebElement continueButton;

        public AddOnsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public GuestDetailsPage ClickContinueButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("addons-bottom-booking-summary-airasia-button-inner-button-booking-summary-heatmap")));
            continueButton.Click();
            return new GuestDetailsPage(driver);
        }
    }
}
