using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class FlightStatusPage
    {
        IWebDriver driver;

        [FindsBy(How = How.Id, Using = "flightNumber")]
        private IWebElement flightNumberField;

        [FindsBy(How = How.Id, Using = "/html/body/app-root/div/aa-flight-search/div/div[1]/div[1]/aa-search-tabs/aa-tabs/div/section/aa-tab[1]/div/aa-flight-number-search/div/button")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//p[@class='p-cls-Error']")]
        public IWebElement incorrectFormatOfNumberError;

        public FlightStatusPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public FlightStatusPage InputFlightNumber(string number)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("flightNumber")));
            flightNumberField.SendKeys(number);
            return this;
        }

        public FlightStatusPage ClickSearchButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("/html/body/app-root/div/aa-flight-search/div/div[1]/div[1]/aa-search-tabs/aa-tabs/div/section/aa-tab[1]/div/aa-flight-number-search/div/button")));
            searchButton.Click();
            return this;
        }
    }
}
