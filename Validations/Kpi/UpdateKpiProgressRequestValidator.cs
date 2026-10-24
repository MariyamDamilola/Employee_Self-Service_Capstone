using Employee_Self_Service_Capstone.DTOs.Request.Kpi;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Kpi;

public class UpdateKpiProgressRequestValidator : AbstractValidator<UpdateKpiProgressRequestDto>
{
    public UpdateKpiProgressRequestValidator()
    {
        RuleFor(x => x.Items)
            .NotEmpty().WithMessage("Progress items cannot be empty.")
            .Must(items => items != null && items.Select(i => i.KpiItemId).Distinct().Count() == items.Count)
            .WithMessage("Duplicate KPI items are not allowed in the same progress update.");

        RuleForEach(x => x.Items).ChildRules(item =>
        {
            item.RuleFor(i => i.KpiItemId)
                .GreaterThan(0).WithMessage("Valid KPI item ID is required.");

            item.RuleFor(i => i.ActualValue)
                .GreaterThanOrEqualTo(0).WithMessage("Actual value cannot be negative."); // KPI-02 Criterion 2

            item.RuleFor(i => i.EvidenceComments)
                .MaximumLength(1000).WithMessage("Comments cannot exceed 1000 characters.");
        });
    }

}