using AutoFixture;
using Demo.Users.API.Dtos;
using Demo.Users.API.Mapper;
using Demo.Users.API.Models;
using FluentAssertions;
using NSubstitute.ExceptionExtensions;

namespace Demo.Users.API.UnitTests.Mapper
{
    public class UserMapperShould
    {
        private readonly UserMapper _userMapper;
        private readonly Fixture _fixture;

        public UserMapperShould()
        {
            _userMapper= new UserMapper();
            _fixture= new Fixture();
        }

        [Fact]
        public void MapUser_User_Returns_UserResponse()
        {
            var user = _fixture.Create<User>();

            var result = _userMapper.MapUser(user);

            result.Should().NotBeNull();
            result.FirstName.Should().BeEquivalentTo(user.Name);
            result.CompanyName.Should().BeEquivalentTo(user.Company);
        }

        [Fact]
        public void MapUser_UserIsNull_Throws()
        {
            User user = null;

            _userMapper.Invoking(m => m.MapUser(user))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void MapUser_UserCreate_Returns_User()
        {
            var userCreate = _fixture.Create<UserCreate>();

            var result = _userMapper.MapUser(userCreate);

            result.Should().NotBeNull();
            result.Name.Should().BeEquivalentTo(userCreate.FirstName);
            result.Company.Should().BeEquivalentTo(userCreate.CompanyName);
        }

        [Fact]
        public void MapUser_UserCreateIsNull_Throws()
        {
            UserCreate userCreate = null;

            _userMapper.Invoking(m => m.MapUser(userCreate))
                .Should()
                .Throw<ArgumentNullException>();
        }

        [Fact]
        public void MapUser_UserUpdate_Returns_User()
        {
            var userUpdate = _fixture.Create<UserUpdate>();

            var result = _userMapper.MapUser(userUpdate);

            result.Should().NotBeNull();
            result.Name.Should().BeEquivalentTo(userUpdate.FirstName);
            result.Company.Should().BeEquivalentTo(userUpdate.CompanyName);
        }

        [Fact]
        public void MapUser_UserUpdateIsNull_Throws()
        {
            UserUpdate userUpdate = null;

            _userMapper.Invoking(m => m.MapUser(userUpdate))
                .Should()
                .Throw<ArgumentNullException>();
        }
    }
}
