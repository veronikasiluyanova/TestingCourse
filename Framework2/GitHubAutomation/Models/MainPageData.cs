
using AirAsiaAutomation.Services;

namespace AirAsiaAutomation.Models
{
    public class MainPageData
    {
        public string DeparturePlace { get; }
        public string ArrivalPlace { get; }
        public string LeaveDate { get; }
        public string ReturnDate { get; }

        public MainPageData ()
        {
            DeparturePlace = MainPageDataReader.GetData("DeparturePlace");
            ArrivalPlace = MainPageDataReader.GetData("ArrivalPlace");
            LeaveDate = MainPageDataReader.GetData("LeaveDate");
            ReturnDate = MainPageDataReader.GetData("ReturnDate");
        }        
    }
}
