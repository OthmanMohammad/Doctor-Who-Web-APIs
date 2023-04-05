using FluentValidation;
using DoctorWho.web.DTOs;

namespace DoctorWho.Web.Validators
{
    public class CompanionDtoValidator : AbstractValidator<CompanionDto>
    {
        public CompanionDtoValidator()
        {
            RuleFor(x => x.CompanionName).NotEmpty().WithMessage("Companion name is required.");
            RuleFor(x => x.WhoPlayed).NotEmpty().WithMessage("Actor name is required.");
        }
    }
}
