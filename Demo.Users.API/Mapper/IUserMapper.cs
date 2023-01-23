using Demo.Users.API.Dtos;
using Demo.Users.API.Models;

namespace Demo.Users.API.Mapper
{
    public interface IUserMapper
    {
        User MapUser(UserCreate userCreate);

        User MapUser(UserUpdate userUpdate);

        UserResponse MapUser(User user);
    }
}
