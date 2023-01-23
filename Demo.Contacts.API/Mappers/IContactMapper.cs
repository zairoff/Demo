using Demo.Contacts.API.Dtos;
using Demo.Contacts.API.Models;

namespace Demo.Contacts.API.Mappers
{
    public interface IContactMapper
    {
        Contact MapContact(ContactUpdate contactUpdate);
        ContactResponse MapContact(Contact contact);
    }
}
