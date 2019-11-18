using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObject
{
    [Obsolete]
    class MainPage
    {
        IWebDriver driver;

        [FindsBy(How=How.XPath, Using= "//INPUT[@id='depart-from']")]
        IWebElement DeparturePlaceField { get; set; }

        [FindsBy(How = How.XPath, Using = "//INPUT[@id='depart-to']")]
        IWebElement ArrivalPlaceField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='field-search-journey-type-oneway']")]
        IWebElement OneWayOptionButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@id='leaveDate']")]
        IWebElement LeaveDateField { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@type='submit']")]
        IWebElement SearchButton { get; set; }

        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public MainPage InputRouteDataAndSearch(string departurePlace, string arrivalPlace, string leaveDate)
        {
            DeparturePlaceField.Click();
            DeparturePlaceField.Clear();
            DeparturePlaceField.SendKeys(departurePlace);
            ArrivalPlaceField.Click();
            ArrivalPlaceField.SendKeys(arrivalPlace);
            OneWayOptionButton.Click();
            LeaveDateField.Click();
            LeaveDateField.SendKeys(leaveDate);
            SearchButton.Click();
            return this;
        }
    }
}
