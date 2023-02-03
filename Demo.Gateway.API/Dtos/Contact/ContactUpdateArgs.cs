using Demo.Contacts.API.Models;

namespace Demo.Gateway.API.Dtos.Contact
{
    public class ContactUpdateArgs
    {
        public ContactType ContactType { get; set; }

        public string Contact { get; set; }
    }
}
