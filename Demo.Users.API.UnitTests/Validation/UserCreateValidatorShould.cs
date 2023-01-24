using AutoFixture;
using Demo.Users.API.Dtos;
using Demo.Users.API.Validation;
using FluentAssertions;

namespace Demo.Users.API.UnitTests.Validation
{
    public class UserCreateValidatorShould
    {
        private readonly Fixture _fixture;
        private readonly UserCreateValidator _userCreateValidator;

        public UserCreateValidatorShould()
        {
            _fixture= new Fixture();
            _userCreateValidator= new UserCreateValidator();
        }

        [Fact]
        public void PassValidation()
        {
            var request = _fixture.Create<UserCreate>();

            var result = _userCreateValidator.Validate(request);

            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void NotValidRequest()
        {
            var request = _fixture.Build<UserCreate>()
                .Without(x => x.FirstName)
                .Create();

            var result = _userCreateValidator.Validate(request);

            result.IsValid.Should().BeFalse();
        }
    }
}
