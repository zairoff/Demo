using Demo.Contacts.API.Models;

namespace Demo.Contacts.API.Dtos
{
    public class ContactResponse
    {
        public ContactType Type { get; set; }

        public string Contact { get; set; }

        public string User { get; set; }
    }
}
