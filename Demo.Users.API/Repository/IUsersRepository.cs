using Demo.Users.API.Models;
using System.Linq.Expressions;

namespace Demo.Users.API.Repository
{
    public interface IUsersRepository
    {
        Task AddAsync(User entity);
        void Delete(User entity);
        void Update(User entity);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> FindAsync(Expression<Func<User, bool>> expression);
    }
}
