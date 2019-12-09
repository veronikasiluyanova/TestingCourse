using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace AirAsiaAutomation.Pages
{
    public class GuestDetailsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "/html/body/app-root/div/main/airasia-passenger/content/section/div/guest-details/div/h1")]
        public IWebElement header;

        [FindsBy(How = How.Id, Using = "adult-0-given-name-heatmap-autocomplete-heatmap")]
        private IWebElement givenNameField;

        [FindsBy(How = How.Id, Using = "adult-0-sur-name-heatmap")]
        private IWebElement surnameField;

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement emailField;

        [FindsBy(How = How.Id, Using = "contact-mobile-number")]
        private IWebElement mobilePhoneField;

        [FindsBy(How = How.XPath, Using = "//airasia-input-validation/div")]
        public IWebElement incorrectNameError;

        public GuestDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }

        public GuestDetailsPage InputGuestData(string givenName, string surname, string email)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementIsVisible(By.Id("adult-0-given-name-heatmap-autocomplete-heatmap")));
            givenNameField.SendKeys(givenName);
            surnameField.SendKeys(surname);
            emailField.SendKeys(email);
            return this;
        }
    }
}
