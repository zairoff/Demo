using Demo.Gateway.API.Dtos.User;

namespace Demo.Gateway.API.Infrastructure
{
    public interface IUsersInfrastructure
    {
        Task CreateAsync(UserCreateArgs args);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(UserUpdateArgs args);
        Task<IEnumerable<UserResponse>> GetUsersAsync();
        Task<UserResponse> GetUserAsync(Guid id);
    }
}
