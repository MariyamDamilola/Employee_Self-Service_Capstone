using Employee_Self_Service_Capstone.DTOs.Request.Courses;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Courses;

public class CreateAssessmentOptionRequestValidator : AbstractValidator<CreateAssessmentOptionRequestDto>
{
    public CreateAssessmentOptionRequestValidator()
    {
        RuleFor(x => x.OptionText)
            .NotEmpty().WithMessage("Option text is required.")
            .MaximumLength(500).WithMessage("Option text cannot exceed 500 characters.");
    }
}
