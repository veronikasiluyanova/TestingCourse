using AirAsiaAutomation.Models;

namespace AirAsiaAutomation.Services
{
    public static class MainPageDataCreator
    {
        public static MainPageData SetAllProperties()
        {
            return new MainPageData(TestDataReader.GetData("DeparturePlace"), TestDataReader.GetData("ArrivalPlace"),
                TestDataReader.GetData("LeaveDate"), TestDataReader.GetData("ReturnDate"));
        }
    }
}
