﻿using FluentValidation;
using Shared.CreateDtos;

namespace Services.UserService
{
    public class RegisterUserCommandValidator : AbstractValidator<UserDto>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(l => l.Login).Cascade(CascadeMode.Stop).NotEmpty().WithErrorCode("Login not be empty!");

            RuleFor(e => e.Email).Cascade(CascadeMode.Stop).NotEmpty().WithErrorCode("Email not be empty!");

            RuleFor(pn => pn.PhoneNumber).Cascade(CascadeMode.Stop).NotEmpty().WithErrorCode("Phone number not be empty!");

            RuleFor(p => p.Password).Cascade(CascadeMode.Stop).NotEmpty().WithErrorCode("Passowrd is empty!")
                .MinimumLength(8).WithErrorCode("Length should not be less than eight characters!");
        }
    }
}
