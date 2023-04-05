using FluentValidation;
using DoctorWho.web.DTOs;

namespace DoctorWho.Web.Validators
{
    public class EpisodeDtoValidator : AbstractValidator<EpisodeDto>
    {
        public EpisodeDtoValidator()
        {
            RuleFor(x => x.SeriesNumber)
                .Must(x => x.HasValue && x.ToString().Length == 10)
                .WithMessage("Series number must be 10 characters long.");

            RuleFor(x => x.EpisodeNumber).GreaterThan(0).WithMessage("Episode number must be greater than 0.");
            RuleFor(x => x.AuthorId).NotEmpty().WithMessage("Author ID is required.");
            RuleFor(x => x.DoctorId).NotEmpty().WithMessage("Doctor ID is required.");
        }
    }
}
