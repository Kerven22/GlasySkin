using FluentValidation;
using Shared.LogInDto;

namespace Services.UserService
{
    public class LogInDtoValidatior : AbstractValidator<LogInDto>
    {
        public LogInDtoValidatior()
        {
            RuleFor(p => p.Password).NotEmpty().WithErrorCode("Password Empty!"); 
            RuleFor(l=>l.Login).NotEmpty().WithErrorCode("Login Empty!");

        }
    }
}
