using Employee_Self_Service_Capstone.DTOs.Request.Payslips;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Payslips;

public class PayslipItemRequestValidator : AbstractValidator<PayslipItemRequestDto>
{
    public PayslipItemRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Item name is required.")
            .MaximumLength(150).WithMessage("Item name cannot exceed 150 characters.");

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Amount cannot be negative.");
    }

    
}