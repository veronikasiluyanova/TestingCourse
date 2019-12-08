
namespace AirAsiaAutomation.Models
{
    public class MainPageData
    {
        public string DeparturePlace { get; }
        public string ArrivalPlace { get; }
        public string LeaveDate { get; }
        public string ReturnDate { get; }

        public MainPageData (string departurePlace, string arrivalPlace, string leaveDate, string returnDate)
        {
            DeparturePlace = departurePlace;
            ArrivalPlace = arrivalPlace;
            LeaveDate = leaveDate;
            ReturnDate = returnDate;
        }

        
    }
}
