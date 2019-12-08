
namespace AirAsiaAutomation.Models
{
    public class GuestDetailsPageData
    {
        public string GivenName { get; }
        public string Surname { get; }
        public string Email { get; }
        public string MobilePhone { get; }

        public GuestDetailsPageData(string givenName, string surname, string email, string mobilePhone)
        {
            GivenName = givenName;
            Surname = surname;
            Email = email;
            MobilePhone = mobilePhone;
        }
    }
}
