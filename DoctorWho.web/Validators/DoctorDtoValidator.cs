using FluentValidation;
using DoctorWho.web.DTOs;

namespace DoctorWho.Web.Validators
{
    public class DoctorDtoValidator : AbstractValidator<DoctorDto>
    {
        public DoctorDtoValidator()
        {
            RuleFor(x => x.DoctorNumber).NotEmpty().WithMessage("Doctor number is required.");
            RuleFor(x => x.DoctorName).NotEmpty().WithMessage("Doctor name is required.");
            RuleFor(x => x.LastEpisodeDate)
                .GreaterThanOrEqualTo(x => x.FirstEpisodeDate)
                .When(x => x.FirstEpisodeDate.HasValue && x.LastEpisodeDate.HasValue)
                .WithMessage("Last episode date must be greater than or equal to the first episode date.");
            RuleFor(x => x.LastEpisodeDate)
                .Null()
                .When(x => !x.FirstEpisodeDate.HasValue)
                .WithMessage("Last episode date should be empty when the first episode date is empty.");
        }
    }
}
