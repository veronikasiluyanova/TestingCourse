
namespace AirAsiaAutomation.Models
{
    public class SearchHotelPageData
    {
        public SearchHotelPageData(string destination, string checkInDate, string checkOutDate)
        {
            Destination = destination;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
        }

        public string Destination { get; }
        public string CheckInDate { get; }
        public string CheckOutDate { get; }
    }
}
