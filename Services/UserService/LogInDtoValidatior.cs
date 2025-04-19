using FluentValidation;
using Shared.LogInDto;

namespace Services.UserService
{
    public class LogInDtoValidatior : AbstractValidator<LogInDto>
    {
        public LogInDtoValidatior()
        {
            RuleFor(p => p.Password).Cascade(CascadeMode.Stop).NotEmpty().WithErrorCode("Password Empty!"); 
            RuleFor(l=>l.Login).Cascade(CascadeMode.Stop).NotEmpty().WithErrorCode("Login Empty!");

        }
    }
}
