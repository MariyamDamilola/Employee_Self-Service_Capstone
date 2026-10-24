using Employee_Self_Service_Capstone.DTOs.Request.Kpi;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Kpi;

public class ActivateKpiPlanRequestValidator : AbstractValidator<ActivateKpiPlanRequestDto>
{
    public ActivateKpiPlanRequestValidator()
    {
        RuleFor(x => x.AssignedReviewerId)
            .GreaterThan(0).WithMessage("A valid assigned reviewer is required.");
    }


}