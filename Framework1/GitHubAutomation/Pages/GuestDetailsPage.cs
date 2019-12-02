using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AirAsiaAutomation.Pages
{
    public class GuestDetailsPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.Id, Using = "/html/body/app-root/div/main/airasia-passenger/content/section/div/guest-details/div/h1")]
        public IWebElement header;
        
        public GuestDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(this.driver, this);
        }
    }
}
