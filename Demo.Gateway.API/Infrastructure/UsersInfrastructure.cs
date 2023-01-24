using Internal = Demo.Gateway.API.Dtos.User;
using Demo.Gateway.API.Mappers;
using UsersApi = Demo.Users.API;
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
            _usersApiUrl = configuration.GetValue<string>("Services:UsersApiUrl");
        }

        public async Task<Internal.UserResponse> CreateAsync(Internal.UserCreateArgs args)
        {
            var user = _usersMapper.MapUser(args);

            using var httpRequest = new HttpRequestMessage(HttpMethod.Post, $"{_usersApiUrl}/api/users");
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            using var httpResponse = await _httpClient.SendAsync(httpRequest);
            var response = await httpResponse.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<UsersApi.Dtos.UserResponse>(response);

            var internalResponse = _usersMapper.MapUser(userResponse);

            return internalResponse;
        }

        public async Task<Internal.UserResponse> GetUserAsync(Guid id)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{_usersApiUrl}/api/users/{id}");
            using var httpResponse = await _httpClient.SendAsync(httpRequest);
            var response = await httpResponse.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<UsersApi.Dtos.UserResponse>(response);

            var internalResponse = _usersMapper.MapUser(userResponse);

            return internalResponse;
        }

        public async Task<IEnumerable<Internal.UserResponse>> GetUsersAsync()
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Get, $"{_usersApiUrl}/api/users");
            using var httpResponse = await _httpClient.SendAsync(httpRequest);
            var response = await httpResponse.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<List<UsersApi.Dtos.UserResponse>>(response);

            var internalResponses = _usersMapper.MapUsers(userResponse);

            return internalResponses;
        }

        public async Task<Internal.UserResponse> RemoveAsync(Guid id)
        {
            using var httpRequest = new HttpRequestMessage(HttpMethod.Delete, $"{_usersApiUrl}/api/users/{id}");
            using var httpResponse = await _httpClient.SendAsync(httpRequest);
            var response = await httpResponse.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<UsersApi.Dtos.UserResponse>(response);

            var internalResponse = _usersMapper.MapUser(userResponse);

            return internalResponse;
        }

        public async Task<Internal.UserResponse> UpdateAsync(Internal.UserUpdateArgs args)
        {
            var user = _usersMapper.MapUser(args);

            using var httpRequest = new HttpRequestMessage(HttpMethod.Put, $"{_usersApiUrl}/api/users");
            httpRequest.Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            using var httpResponse = await _httpClient.SendAsync(httpRequest);
            var response = await httpResponse.Content.ReadAsStringAsync();
            var userResponse = JsonConvert.DeserializeObject<UsersApi.Dtos.UserResponse>(response);

            var internalResponse = _usersMapper.MapUser(userResponse);
            return internalResponse;
        }
    }
}
