using Employee_Self_Service_Capstone.DTOs.Request.Vacancies;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Vacancies;

public class SubmitVacancyApplicationRequestValidator : AbstractValidator<SubmitVacancyApplicationRequestDto>
{
    public SubmitVacancyApplicationRequestValidator()
    {
        RuleFor(x => x.VacancyId)
            .GreaterThan(0).WithMessage("A valid vacancy ID is required.");

        RuleFor(x => x.SupportingStatement)
            .NotEmpty().WithMessage("Supporting statement is mandatory.")
            .MaximumLength(4000).WithMessage("Supporting statement cannot exceed 4000 characters.");
    }

}