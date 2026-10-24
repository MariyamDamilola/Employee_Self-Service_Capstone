using Employee_Self_Service_Capstone.DTOs.Request.Employees;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Employees;

public class AdminUpdateEmployeeRequestValidator : AbstractValidator<AdminUpdateEmployeeRequestDto>
{
    public AdminUpdateEmployeeRequestValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Full name is required.")
            .MaximumLength(150).WithMessage("Full name cannot exceed 150 characters.");

        RuleFor(x => x.PhoneNumber)
            .MaximumLength(30).WithMessage("Phone number cannot exceed 30 characters.")
            .Matches(@"^[+0-9\s-]*$").When(x => !string.IsNullOrEmpty(x.PhoneNumber))
            .WithMessage("Phone number format is invalid.");

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0).WithMessage("Valid department is required.");

        RuleFor(x => x.GradeId)
            .GreaterThan(0).WithMessage("Valid grade is required.");

        RuleFor(x => x.ReportingManagerId)
            .GreaterThan(0).When(x => x.ReportingManagerId.HasValue)
            .WithMessage("Reporting manager ID must be a valid positive integer.");

        RuleFor(x => x.RoleIds)
            .NotEmpty().WithMessage("At least one role must be assigned.");
    }

}