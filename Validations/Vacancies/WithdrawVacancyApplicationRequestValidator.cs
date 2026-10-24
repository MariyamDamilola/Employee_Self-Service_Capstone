using Employee_Self_Service_Capstone.DTOs.Request.Vacancies;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Vacancies;

public class WithdrawVacancyApplicationRequestValidator : AbstractValidator<WithdrawVacancyApplicationRequestDto>
{
    public WithdrawVacancyApplicationRequestValidator()
    {
        RuleFor(x => x.Reason)
            .NotEmpty().WithMessage("A reason is mandatory when withdrawing an application.")
            .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters.");
    }
    
}