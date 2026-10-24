using Employee_Self_Service_Capstone.DTOs.Request.Kpi;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Kpi;

public class CreateKpiItemRequestValidator : AbstractValidator<CreateKpiItemRequestDto>
{
    public CreateKpiItemRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Item title is required.")
            .MaximumLength(200).WithMessage("Item title cannot exceed 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Item description is required.");

        RuleFor(x => x.Target)
            .GreaterThan(0).WithMessage("Target must be strictly greater than 0."); // KPI-01 Criterion 3

        RuleFor(x => x.Unit)
            .NotEmpty().WithMessage("Measurement unit is required.")
            .MaximumLength(50).WithMessage("Unit cannot exceed 50 characters.");

        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage("Weight must be greater than 0.")
            .LessThanOrEqualTo(100).WithMessage("Weight cannot exceed 100.");
    }

    
}