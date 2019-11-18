using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObject
{
    [Obsolete]
    class FlightBookingPage
    {
        private IWebDriver _driver;

        [FindsBy(How=How.XPath, Using = "//BUTTON[@class='btn btn-primary']")]
        public IWebElement ContinueButton { get; set; }

        [FindsBy(How=How.XPath, Using = "//*[@id='viewpoint-LONGHAUL-1']/div[3]/fieldset/div[1]/div/div/div/div/div[1]/label/div[1]/div[2]/input")]
        IWebElement SelectedFlight { get; set; }

        public FlightBookingPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            _driver = driver;
        }

        public FlightBookingPage SelectFlight()
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='viewpoint-LONGHAUL-1']/div[3]/fieldset/div[1]/div/div/div/div/div[1]/label/div[1]/div[2]/input")));
            SelectedFlight.Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//BUTTON[@class='btn btn-primary']")));
            ContinueButton.Click();
            return this;
        }
    }
}
