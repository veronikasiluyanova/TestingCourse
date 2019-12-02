using AirAsiaAutomation.Models;

namespace AirAsiaAutomation.Services
{
    public static class SearchHotelPageDataCreator
    {
        public static SearchHotelPageData SetAllProperties()
        {
            return new SearchHotelPageData(TestDataReader.GetData("Destination"), TestDataReader.GetData("CheckInDate"),
                TestDataReader.GetData("CheckOutDate"));
        }
    }
}
