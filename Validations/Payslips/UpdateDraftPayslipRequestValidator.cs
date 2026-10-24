using Employee_Self_Service_Capstone.DTOs.Request.Payslips;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Payslips;

public class UpdateDraftPayslipRequestValidator : AbstractValidator<UpdateDraftPayslipRequestDto>
{
    public UpdateDraftPayslipRequestValidator()
    {
        RuleFor(x => x.BasicSalary)
            .GreaterThan(0).WithMessage("Basic salary must be greater than 0.");

        RuleForEach(x => x.Allowances).SetValidator(new PayslipItemRequestValidator());
        RuleForEach(x => x.Deductions).SetValidator(new PayslipItemRequestValidator());

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