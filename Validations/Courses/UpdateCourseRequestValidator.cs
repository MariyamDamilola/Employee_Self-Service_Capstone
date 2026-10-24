using Employee_Self_Service_Capstone.DTOs.Request.Courses;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Courses;

public class UpdateCourseRequestValidator : AbstractValidator<UpdateCourseRequestDto>
{
    public UpdateCourseRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Course title is required.")
            .MaximumLength(200).WithMessage("Course title cannot exceed 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Course description is required.");

        RuleFor(x => x.Category)
            .NotEmpty().WithMessage("Category is required.")
            .MaximumLength(100).WithMessage("Category cannot exceed 100 characters.");

        RuleFor(x => x.PassMark)
            .InclusiveBetween(1, 100).WithMessage("Pass mark must be between 1 and 100.");
    }

    
}