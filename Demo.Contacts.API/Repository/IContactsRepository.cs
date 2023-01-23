using Demo.Contacts.API.Models;
using System.Linq.Expressions;

namespace Demo.Contacts.API.Repository
{
    public interface IContactsRepository
    {
        Task AddAsync(Contact entity);
        void Delete(Contact entity);
        void Update(Contact entity);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetAsync(Guid id);
        Task<IEnumerable<Contact>> FindAsync(Expression<Func<Contact, bool>> expression);
    }
}
