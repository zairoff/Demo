using Demo.Users.API.Dtos;
using Demo.Users.API.Models;

namespace Demo.Users.API.Mapper
{
    public interface IUserMapper
    {
        User MapUserRequest(UserRequest userRequest);

        UserResponse MapUser(User user);
    }
}
