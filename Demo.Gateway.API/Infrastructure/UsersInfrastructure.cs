using Demo.Gateway.API.Dtos.User;
using Demo.Gateway.API.Mappers;
using Newtonsoft.Json;
using System.Text;

namespace Demo.Gateway.API.Infrastructure
{
    public class UsersInfrastructure : IUsersInfrastructure
    {
        private readonly HttpClient _httpClient;
        private readonly IUsersMapper _usersMapper;
        private readonly string _usersApiUrl;

        public UsersInfrastructure(HttpClient httpClient, IUsersMapper usersMapper, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _usersMapper = usersMapper;
            _usersApiUrl = configuration.GetValue<string>("");
        }

        public async Task CreateAsync(UserCreateArgs args)
        {
            var user = _usersMapper.MapUser(args);

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{_usersApiUrl}/api/users");
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            using var httpResponse = await _httpClient.SendAsync(httpRequest);
            httpResponse.EnsureSuccessStatusCode();
        }

        public Task<UserResponse> GetUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponse>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UserUpdateArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
