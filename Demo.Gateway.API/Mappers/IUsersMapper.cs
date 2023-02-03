using Demo.Gateway.API.Dtos.User;
using UsersAPI = Demo.Users.API;

namespace Demo.Gateway.API.Mappers
{
    public interface IUsersMapper
    {
        UsersAPI.Models.User MapUser(UserCreateArgs args);

        UsersAPI.Models.User MapUser(UserUpdateArgs args);

        UserResponse? MapUser(UsersAPI.Dtos.UserResponse userResponse);

        IReadOnlyCollection<UserResponse>? MapUsers(List<UsersAPI.Dtos.UserResponse> userResponses);
    }
}
