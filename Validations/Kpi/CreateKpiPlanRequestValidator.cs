using Employee_Self_Service_Capstone.DTOs.Request.Kpi;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Kpi;

public class CreateKpiPlanRequestValidator   : AbstractValidator<CreateKpiPlanRequestDto>
{
    public CreateKpiPlanRequestValidator()
    {
        RuleFor(x => x.EmployeeId)
            .GreaterThan(0).WithMessage("Valid employee ID is required.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("KPI plan title is required.")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

        RuleFor(x => x.ReviewPeriod)
            .NotEmpty().WithMessage("Review period identifier is required.")
            .MaximumLength(50).WithMessage("Review period cannot exceed 50 characters.");

        RuleFor(x => x.PeriodEndDate)
            .GreaterThan(x => x.PeriodStartDate)
            .WithMessage("Period end date must be after period start date.");

        RuleFor(x => x.SubmissionDeadline)
            .GreaterThanOrEqualTo(x => x.PeriodEndDate)
            .WithMessage("Submission deadline must be on or after the period end date."); // KPI-01 Criterion 1

        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("KPI plan must contain at least one item.")
            .Must(items => items != null && items.Count > 0)
            .WithMessage("KPI plan must contain at least one item.");

        RuleForEach(x => x.Items).SetValidator(new CreateKpiItemRequestValidator());
    
    }

}