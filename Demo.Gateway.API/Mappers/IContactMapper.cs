using Demo.Gateway.API.Dtos.Contact;
using ContactsAPI = Demo.Contacts.API;

namespace Demo.Gateway.API.Mappers
{
    public interface IContactMapper
    {
        ContactsAPI.Dtos.ContactUpdate MapContact(ContactUpdateArgs args);

        ContactResponse MapContact(ContactsAPI.Dtos.ContactResponse contactResponse);
    }
}
