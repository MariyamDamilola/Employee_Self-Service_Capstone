using Employee_Self_Service_Capstone.DTOs.Request.Courses;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Courses;

public class CreateLessonRequestValidator : AbstractValidator<CreateLessonRequestDto>
{
    public CreateLessonRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Lesson title is required.")
            .MaximumLength(200).WithMessage("Lesson title cannot exceed 200 characters.");

        RuleFor(x => x.Content)
            .NotEmpty().WithMessage("Lesson content or media URL is required.");

        RuleFor(x => x.OrderIndex)
            .GreaterThanOrEqualTo(1).WithMessage("Order index must be at least 1.");
    }
}
