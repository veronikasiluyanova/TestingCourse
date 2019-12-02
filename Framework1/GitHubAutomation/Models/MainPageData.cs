
namespace AirAsiaAutomation.Models
{
    public class MainPageData
    {
        public MainPageData (string departurePlace, string arrivalPlace, string leaveDate, string returnDate)
        {
            DeparturePlace = departurePlace;
            ArrivalPlace = arrivalPlace;
            LeaveDate = leaveDate;
            ReturnDate = returnDate;
        }

        public string DeparturePlace { get; set; }
        public string ArrivalPlace { get; set; }
        public string LeaveDate { get; set; }
        public string ReturnDate { get; set; }
    }
}
