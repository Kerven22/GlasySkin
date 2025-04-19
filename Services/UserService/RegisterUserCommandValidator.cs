using FluentValidation;
using Shared.ValidatorCommands;

namespace Services.UserService
{
    public class RegisterUserCommandValidator:AbstractValidator<RegisterUserDto>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(l => l.Login).Cascade(CascadeMode.Stop).NotEmpty().WithErrorCode("Login not be empty!");

            RuleFor(e => e.Email).Cascade(CascadeMode.Stop).NotEmpty().WithErrorCode("Email not be empty!");

            RuleFor(pn => pn.PhoneNumber).Cascade(CascadeMode.Stop).NotEmpty().WithErrorCode("Phone number not be empty!");

            RuleFor(p => p.Password).Cascade(CascadeMode.Stop).NotEmpty().WithErrorCode("Passowrd is empty!");
        }
    }
}
