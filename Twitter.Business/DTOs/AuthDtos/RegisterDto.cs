using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Twitter.Business.DTOs.AuthDtos
{
    public class RegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // front will check ConfirmPassword himself

        public DateTime BirthDay { get; set; }

        public class RegisterDtoValidator : AbstractValidator<RegisterDto>
        {
            public RegisterDtoValidator()
            {
                RuleFor(x => x.Name).NotEmpty()
                    .MinimumLength(2)
                    .MaximumLength(32);
                RuleFor(x => x.Surname).NotEmpty()
                    .MinimumLength(5)
                    .MaximumLength(35);
                RuleFor(x => x.Username).NotEmpty()
                    .NotNull()
                    .MinimumLength(5)
                    .MaximumLength(35);
                RuleFor(x => x.Password).NotEmpty()
                    .NotNull()
                    .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d){6,}$")
                    .WithMessage("Password must be 6 chars long & contain at least 1 Capital letter");
                RuleFor(x => x.Email).NotEmpty()
                    .NotNull()
                    .EmailAddress();
                RuleFor(x => x.BirthDay).NotEmpty()
                    .Must(birthday => birthday <= DateTime.UtcNow)
                    .WithMessage("Enter a correct birthday");
            }
        }

    }
}
