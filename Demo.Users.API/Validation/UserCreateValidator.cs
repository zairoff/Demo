using Demo.Users.API.Dtos;
using FluentValidation;

namespace Demo.Users.API.Validation
{
    public class UserCreateValidator : AbstractValidator<UserCreate>
    {
        public UserCreateValidator()
        {
            this.RuleFor(req => req.FirstName)
                .NotNull()
                .NotEmpty();

            this.RuleFor(req => req.LastName)
                .NotNull()
                .NotEmpty();

            this.RuleFor(req => req.CompanyName)
                .NotNull()
                .NotEmpty();
        }
    }
}
