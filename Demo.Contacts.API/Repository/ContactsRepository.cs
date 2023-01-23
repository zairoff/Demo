using Demo.Contacts.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Demo.Contacts.API.Repository
{
    public class ContactsRepository : IContactsRepository
    {
        protected readonly ContactsDbContext _context;

        public ContactsRepository(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Contact entity)
        {
            await _context.Contacts.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(Contact entity)
        {
            _context.Contacts.Remove(entity);
        }

        public async Task<IEnumerable<Contact>> FindAsync(Expression<Func<Contact, bool>> expression)
        {
            return await _context.Contacts.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetAsync(Guid id)
        {
            return await _context.Contacts.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public void Update(Contact entity)
        {
            _context.Contacts.Update(entity);
            _context.SaveChanges();
        }
    }
}
