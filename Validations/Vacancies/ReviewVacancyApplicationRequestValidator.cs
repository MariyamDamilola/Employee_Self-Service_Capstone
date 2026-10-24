using Employee_Self_Service_Capstone.Domain.Enum;
using Employee_Self_Service_Capstone.DTOs.Request.Vacancies;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Vacancies;

public class ReviewVacancyApplicationRequestValidator : AbstractValidator<ReviewVacancyApplicationRequestDto>
{
    public ReviewVacancyApplicationRequestValidator()
    {
        RuleFor(x => x.Decision)
            .IsInEnum().WithMessage("A valid review decision (Shortlist, Select, or Reject) is required.");

        RuleFor(x => x.Comments)
            .NotEmpty().When(x => x.Decision == VacancyApplicationReviewDecision.Reject)
            .WithMessage("A comment is mandatory when rejecting an application.");
    }

}