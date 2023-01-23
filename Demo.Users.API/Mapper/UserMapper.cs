using Demo.Users.API.Dtos;
using Demo.Users.API.Models;

namespace Demo.Users.API.Mapper
{
    public class UserMapper : IUserMapper
    {
        public UserResponse MapUser(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            var userResponse = new UserResponse
            {
                Id = user.Id,
                FirstName = user.Name,
                LastName = user.SureName,
                CompanyName = user.Company,
                Contact = user.Contact
            };

            return userResponse;
        }

        public User MapUserRequest(UserRequest userRequest)
        {
            if (userRequest == null) throw new ArgumentNullException(nameof(userRequest));

            var user = new User
            {
                Name = userRequest.FirstName,
                SureName = userRequest.LastName,
                Company = userRequest.CompanyName,
            };

            return user;
        }
    }
}
