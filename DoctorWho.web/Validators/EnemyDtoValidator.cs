using FluentValidation;
using DoctorWho.web.DTOs;

namespace DoctorWho.Web.Validators
{
    public class EnemyDtoValidator : AbstractValidator<EnemyDto>
    {
        public EnemyDtoValidator()
        {
            RuleFor(x => x.EnemyName).NotEmpty().WithMessage("Enemy name is required.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required.");
        }
    }
}
