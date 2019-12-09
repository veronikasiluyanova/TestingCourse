
using AirAsiaAutomation.Services;

namespace AirAsiaAutomation.Models
{
    public class GuestDetailsPageData
    {
        public string GivenName { get; }
        public string Surname { get; }
        public string Email { get; }
        public string MobilePhone { get; }

        public GuestDetailsPageData()
        {
            GivenName = GuestDetailsPageDataReader.GetData("GivenName");
            Surname = GuestDetailsPageDataReader.GetData("Surname");
            Email = GuestDetailsPageDataReader.GetData("Email");
            MobilePhone = GuestDetailsPageDataReader.GetData("MobilePhone");
        }
    }
}
