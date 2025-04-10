﻿using FluentValidation;
using Shared.ValidatorCommands;

namespace Services.UserService
{
    internal class RegisterUserCommandValidator:AbstractValidator<RegisgerUserDto>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(l => l.Login).NotEmpty().WithErrorCode("Login not be empty!");

            RuleFor(e => e.Email).NotEmpty().WithErrorCode("Email not be empty!");

            RuleFor(pn => pn.PhoneNumber).NotEmpty().WithErrorCode("Phone number not be empty!");

            RuleFor(p => p.Password).NotEmpty().WithErrorCode("Passowrd is empty!");
        }
    }
}
