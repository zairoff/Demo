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

        public UserResponse? MapUser(UsersAPI.Dtos.UserResponse userResponse)
        {
            var user = MapUserInternally(userResponse);
            return user;
        }

        public IReadOnlyCollection<UserResponse>? MapUsers(List<UsersAPI.Dtos.UserResponse> userResponses)
        {
            if (userResponses == null || !userResponses.Any()) { return null; }

            var internalUserResponses = new List<UserResponse>(userResponses.Count);
            foreach(var userResponse in userResponses)
            {
                var internalUserResponse = MapUserInternally(userResponse);
                if (internalUserResponse != null)
                {
                    internalUserResponses.Add(internalUserResponse);
                }
            }
            return internalUserResponses;
        }

        private static UserResponse? MapUserInternally(UsersAPI.Dtos.UserResponse userResponse)
        {
            if (userResponse == null) { return null; }

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
