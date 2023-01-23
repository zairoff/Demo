using Demo.Contacts.API.Models;

namespace Demo.Contacts.API.Dtos
{
    public class ContactUpdate
    {
        public ContactType ContactType { get; set; }

        public string Contact { get; set; }
    }
}
