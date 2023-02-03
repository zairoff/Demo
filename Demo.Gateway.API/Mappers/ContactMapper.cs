using Demo.Gateway.API.Dtos.Contact;
using ContactsAPI = Demo.Contacts.API;

namespace Demo.Gateway.API.Mappers
{
    public class ContactMapper : IContactMapper
    {
        public ContactsAPI.Dtos.ContactUpdate MapContact(ContactUpdateArgs args)
        {
            if (args == null) throw new ArgumentNullException(nameof(args));

            var contact = new ContactsAPI.Dtos.ContactUpdate
            {
                Contact = args.Contact,
                ContactType = args.ContactType
            };

            return contact;
        }

        public ContactResponse MapContact(ContactsAPI.Dtos.ContactResponse contactResponse)
        {
            if (contactResponse == null) throw new ArgumentNullException(nameof(contactResponse));

            var contact = new ContactResponse
            {
                Contact = contactResponse.Contact,
                User = contactResponse.User,
                Type = contactResponse.Type
            };

            return contact;
        }
    }
}
