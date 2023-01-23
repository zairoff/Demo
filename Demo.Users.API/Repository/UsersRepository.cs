using Demo.Users.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Demo.Users.API.Repository
{
    public class UsersRepository : IUsersRepository
    {
        protected readonly UsersDbContext _context;

        public UsersRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(User entity)
        {
            _context.Users.Remove(entity);
        }

        public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> expression)
        {
            return await _context.Users.Where(expression).ToListAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _context.Users.Where(u => u.Id == id).FirstOrDefaultAsync();
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}
