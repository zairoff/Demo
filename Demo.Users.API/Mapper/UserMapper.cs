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

        public User MapUser(UserCreate userCreate)
        {
            if (userCreate == null) throw new ArgumentNullException(nameof(userCreate));

            var user = new User
            {
                Name = userCreate.FirstName,
                SureName = userCreate.LastName,
                Company = userCreate.CompanyName,
            };

            return user;
        }

        public User MapUser(UserUpdate userUpdate)
        {
            if (userUpdate == null) throw new ArgumentNullException(nameof(userUpdate));

            var user = new User
            {
                Name = userUpdate.FirstName,
                SureName = userUpdate.LastName,
                Company = userUpdate.CompanyName,
            };

            return user;
        }
    }
}
