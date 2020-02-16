using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataingApp.API.Dtos;
using FluentValidation;

namespace DataingApp.API.Validation
{
    public class UserForRegisterValidator : AbstractValidator<UserForRegisterDto>
    {
        public UserForRegisterValidator()
        {
            RuleFor(x => x.Password)
                .MinimumLength(4)
                .WithMessage("PArola prea mica");


            RuleFor(x => x.UserName)
                .NotEmpty()
                .MinimumLength(5).WithMessage("min5")
                .MaximumLength(10).WithMessage("max10");

        }
    }
}
