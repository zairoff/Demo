using Demo.Contacts.API.Dtos;
using Demo.Contacts.API.Models;

namespace Demo.Contacts.API.Mappers
{
    public interface IContactsMapper
    {
        Contact MapContact(ContactUpdate contactUpdate, Contact contact);
        ContactResponse MapContact(Contact contact);
    }
}
