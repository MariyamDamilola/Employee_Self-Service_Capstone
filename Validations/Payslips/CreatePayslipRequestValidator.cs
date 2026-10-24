using Employee_Self_Service_Capstone.DTOs.Request.Payslips;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Payslips;

public class CreatePayslipRequestValidator : AbstractValidator<CreatePayslipRequestDto>
{
    public CreatePayslipRequestValidator()
    {
        RuleFor(x => x.EmployeeId)
            .GreaterThan(0).WithMessage("Valid employee ID is required.");

        RuleFor(x => x.Month)
            .InclusiveBetween(1, 12).WithMessage("Month must be between 1 and 12.");

        RuleFor(x => x.Year)
            .InclusiveBetween(2000, DateTime.UtcNow.Year + 1)
            .WithMessage("Year is invalid.");

        RuleFor(x => x.BasicSalary)
            .GreaterThan(0).WithMessage("Basic salary must be greater than 0.");

        RuleForEach(x => x.Allowances).SetValidator(new PayslipItemRequestValidator());
        RuleForEach(x => x.Deductions).SetValidator(new PayslipItemRequestValidator());

        // PAY-01 Criterion 3: Deductions exceeding gross must return 400
        RuleFor(x => x)
            .Must(x =>
            {
                var totalAllowances = x.Allowances?.Sum(a => a.Amount) ?? 0m;
                var totalDeductions = x.Deductions?.Sum(d => d.Amount) ?? 0m;
                var gross = x.BasicSalary + totalAllowances;
                return totalDeductions <= gross;
            })
            .WithMessage("Total deductions cannot exceed gross pay.");
    }
    
}