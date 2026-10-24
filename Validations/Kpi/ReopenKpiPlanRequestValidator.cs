using Employee_Self_Service_Capstone.DTOs.Request.Kpi;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Kpi;

public class ReopenKpiPlanRequestValidator : AbstractValidator<ReopenKpiPlanRequestDto>
{
    public ReopenKpiPlanRequestValidator()
    {
        RuleFor(x => x.Reason)
            .NotEmpty().WithMessage("A reason is mandatory when reopening a KPI plan.")
            .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters.");

        RuleFor(x => x.NewSubmissionDeadline)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("New submission deadline must be strictly in the future.");
    }

}