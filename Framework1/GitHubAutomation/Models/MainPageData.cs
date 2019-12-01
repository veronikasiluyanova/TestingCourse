using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObject
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

        public string DeparturePlace { get; }
        public string ArrivalPlace { get; }
        public string LeaveDate { get; }
        public string ReturnDate { get; }
    }
}
