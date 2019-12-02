using AirAsiaAutomation.Models;

namespace AirAsiaAutomation.Services
{
    public static class GuestDetailsPageDataCreator
    {
        public static GuestDetailsPageData SetAllProperties()
        {
            return new GuestDetailsPageData(TestDataReader.GetData("GivenName"), TestDataReader.GetData("Surname"),
                TestDataReader.GetData("Email"), TestDataReader.GetData("MobilePhone"));
        }
    }
}
