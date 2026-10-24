using Employee_Self_Service_Capstone.DTOs.Request.Departments;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Departments;

public class UpdateDepartmentRequestValidator : AbstractValidator<UpdateDepartmentRequestDto>
{
    public UpdateDepartmentRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Department name is required.")
            .MaximumLength(150).WithMessage("Department name cannot exceed 150 characters.");

        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Department code is required.")
            .MaximumLength(50).WithMessage("Department code cannot exceed 50 characters.")
            .Matches("^[A-Za-z0-9_-]+$")
            .WithMessage("Department code must be alphanumeric and may include hyphens or underscores.");
    }

}