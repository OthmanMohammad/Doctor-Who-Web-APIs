using FluentValidation;
using DoctorWho.web.DTOs;

namespace DoctorWho.Web.Validators
{
    public class AuthorDtoValidator : AbstractValidator<AuthorDto>
    {
        public AuthorDtoValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Author name is required.");
        }
    }
}
