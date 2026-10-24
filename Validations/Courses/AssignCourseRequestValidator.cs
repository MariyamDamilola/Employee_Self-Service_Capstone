using Employee_Self_Service_Capstone.DTOs.Request.Courses;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Courses;

public class AssignCourseRequestValidator : AbstractValidator<AssignCourseRequestDto>
{
    public AssignCourseRequestValidator()
    {
        RuleFor(x => x.CourseId)
            .GreaterThan(0).WithMessage("Valid course ID is required.");

        RuleFor(x => x.EmployeeIds)
            .NotEmpty().WithMessage("At least one employee must be selected.")
            .Must(ids => ids != null && ids.Count > 0)
            .WithMessage("At least one employee must be selected.");

        RuleFor(x => x.DueDate)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Due date must be in the future.");
    }

    
}