
namespace PageObject
{
    public class MainPageData
    {
        private string DeparturePlace { get; }
        private string ArrivalPlace { get; }
        private string LeaveDate { get; }
        private string ReturnDate { get; }

        public MainPageData (string departurePlace, string arrivalPlace, string leaveDate, string returnDate)
        {
            DeparturePlace = departurePlace;
            ArrivalPlace = arrivalPlace;
            LeaveDate = leaveDate;
            ReturnDate = returnDate;
        }        
    }
}
