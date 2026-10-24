using Employee_Self_Service_Capstone.DTOs.Request.Employees;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Employees;

public class AssignRolesRequestValidator : AbstractValidator<AssignRolesRequestDto>
{
    public AssignRolesRequestValidator()
    {
        RuleFor(x => x.RoleIds)
            .NotEmpty().WithMessage("At least one role ID must be provided.")
            .Must(roles => roles != null && roles.Count > 0)
            .WithMessage("At least one role must be assigned.");

        RuleForEach(x => x.RoleIds)
            .GreaterThan(0).WithMessage("Role ID must be a positive integer.");
    }
    
}