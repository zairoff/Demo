using Demo.Gateway.API.Dtos.User;

namespace Demo.Gateway.API.Infrastructure
{
    public interface IUsersInfrastructure
    {
        Task<UserResponse> CreateAsync(UserCreateArgs args);
        Task<UserResponse> RemoveAsync(Guid id);
        Task<UserResponse> UpdateAsync(UserUpdateArgs args);
        Task<IEnumerable<UserResponse>> GetUsersAsync();
        Task<UserResponse> GetUserAsync(Guid id);
    }
}
