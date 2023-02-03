using Demo.Users.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Users.API.Repository
{
    public class UsersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
