using Employee_Self_Service_Capstone.Domain.Enum;
using Employee_Self_Service_Capstone.DTOs.Request.Kpi;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Kpi;

public class ReviewKpiPlanRequestValidator : AbstractValidator<ReviewKpiPlanRequestDto>
{
    public ReviewKpiPlanRequestValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Valid review decision is required.");

        RuleFor(x => x.Comments)
            .NotEmpty().When(x => x.Status == KpiReviewStatus.Returned)
            .WithMessage("Comments are mandatory when returning a KPI plan for revision."); // KPI-03 Criterion 2

        RuleForEach(x => x.ItemReviews).ChildRules(item =>
        {
            item.RuleFor(i => i.KpiItemId).GreaterThan(0).WithMessage("Valid item ID is required.");
            item.RuleFor(i => i.Status).IsInEnum().WithMessage("Valid item review status is required.");
        });
    }

    
}