using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;


namespace PageObject
{
    [Obsolete]
    class PassengerDetailsPage
    {
        IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='submitBtn']")]
        IWebElement ContinueButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='form-travellerdetails']/div[3]/div/div/div")]
        public IWebElement NoPassengerDetailsError { get; private set; }

        public PassengerDetailsPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        public PassengerDetailsPage EnterPassengerDetails()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='submitBtn']")));
            ContinueButton.Click();
            return this;
        }
    }
}
