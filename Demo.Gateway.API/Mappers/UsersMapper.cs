using Demo.Gateway.API.Dtos.User;
using UsersAPI = Demo.Users.API;

namespace Demo.Gateway.API.Mappers
{
    public class UsersMapper : IUsersMapper
    {
        public UsersAPI.Models.User MapUser(UserCreateArgs args)
        {
            if (args == null) { throw new ArgumentNullException(nameof(args)); }

            var user = new UsersAPI.Models.User
            {
                Name = args.FirstName,
                SureName = args.LastName,
                Company = args.Company
            };

            return user;
        }

        public UsersAPI.Models.User MapUser(UserUpdateArgs args)
        {
            if (args == null) { throw new ArgumentNullException(nameof(args)); }

            var user = new UsersAPI.Models.User
            {
                Name = args.FirstName,
                SureName = args.LastName,
                Company = args.Company
            };

            return user;
        }

        public UserResponse MapUser(UsersAPI.Dtos.UserResponse userResponse)
        {
            if (userResponse == null) { throw new ArgumentNullException(nameof(userResponse)); }

            var user = new UserResponse
            {
                FirstName = userResponse.FirstName,
                LastName = userResponse.LastName,
                Company = userResponse.CompanyName,
                Contact = userResponse.Contact
            };

            return user;
        }
    }
}
