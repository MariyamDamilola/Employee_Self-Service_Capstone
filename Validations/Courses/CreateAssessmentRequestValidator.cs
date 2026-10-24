using Employee_Self_Service_Capstone.DTOs.Request.Courses;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Courses;

public class CreateAssessmentRequestValidator : AbstractValidator<CreateAssessmentRequestDto>
{
    public CreateAssessmentRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Assessment title is required.")
            .MaximumLength(200).WithMessage("Assessment title cannot exceed 200 characters.");

        RuleFor(x => x.Questions)
            .NotEmpty().WithMessage("Assessment must have at least one question.")
            .Must(q => q != null && q.Count >= 1)
            .WithMessage("Assessment must contain at least 1 question.");

        RuleForEach(x => x.Questions).SetValidator(new CreateAssessmentQuestionRequestValidator());
    
    }
}
