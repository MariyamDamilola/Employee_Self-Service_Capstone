using Employee_Self_Service_Capstone.DTOs.Request.Training;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Training;

public class CalculateAllowanceRequestValidator : AbstractValidator<CalculateAllowanceRequestDto>
{
    public CalculateAllowanceRequestValidator()
    {
        When(x => x.IsOverride, () =>
        {
            RuleFor(x => x.OverrideReason)
                .NotEmpty().WithMessage("An override reason is required when manually setting allowance values.")
                .MaximumLength(500).WithMessage("Override reason cannot exceed 500 characters.");

            RuleFor(x => x.OverrideDailyRate)
                .GreaterThan(0).When(x => x.OverrideDailyRate.HasValue)
                .WithMessage("Overridden daily rate must be greater than 0.");

            RuleFor(x => x.OverrideEligibleDays)
                .GreaterThan(0).When(x => x.OverrideEligibleDays.HasValue)
                .WithMessage("Overridden eligible days must be at least 1.");
        });
    }

}