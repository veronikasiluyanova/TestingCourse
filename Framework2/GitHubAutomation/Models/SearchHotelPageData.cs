
using AirAsiaAutomation.Services;

namespace AirAsiaAutomation.Models
{
    public class SearchHotelPageData
    {
        public string Destination { get; }
        public string CheckInDate { get; }
        public string CheckOutDate { get; }

        public SearchHotelPageData()
        {
            Destination = SearchHotelPageDataReader.GetData("Destination");
            CheckInDate = SearchHotelPageDataReader.GetData("CheckInDate");
            CheckOutDate = SearchHotelPageDataReader.GetData("CheckOutDate");
        }
    }
}
