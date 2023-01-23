using Demo.Contacts.API.Dtos;
using Demo.Contacts.API.Models;

namespace Demo.Contacts.API.Mappers
{
    public class ContactsMapper : IContactsMapper
    {
        public Contact MapContact(ContactUpdate contactUpdate)
        {
            if (contactUpdate == null)
            {
                throw new ArgumentNullException(nameof(contactUpdate));
            }

            var contact = new Contact
            {
                Type = contactUpdate.ContactType,
                ContactInfo = contactUpdate.Contact
            };

            return contact;
        }

        public ContactResponse MapContact(Contact contact)
        {
            if (contact == null )
            {
                throw new ArgumentNullException(nameof(contact));
            }

            var contactResponse = new ContactResponse
            {
                Type = contact.Type.Value,
                Contact = contact.ContactInfo,
                User = contact.ContactOwner
            };

            return contactResponse;
        }
    }
}
