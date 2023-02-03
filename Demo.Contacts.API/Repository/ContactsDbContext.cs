using Demo.Contacts.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Contacts.API.Repository
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        public ContactsDbContext(DbContextOptions<ContactsDbContext> options)
            : base(options)
        {
        }
    }
}
