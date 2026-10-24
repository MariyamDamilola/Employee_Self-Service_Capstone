using Employee_Self_Service_Capstone.DTOs.Request.Courses;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Courses;

public class CreateAssessmentQuestionRequestValidator  : AbstractValidator<CreateAssessmentQuestionRequestDto>
{
    public CreateAssessmentQuestionRequestValidator()
    {
        RuleFor(x => x.QuestionText)
            .NotEmpty().WithMessage("Question text is required.");

        RuleFor(x => x.Options)
            .NotEmpty().WithMessage("At least two options are required.")
            .Must(options => options != null && options.Count >= 2)
            .WithMessage("Each question must have at least 2 options.")
            .Must(options => options != null && options.Count(o => o.IsCorrect) == 1)
            .WithMessage("Each question must have exactly one correct option."); // LMS-01 Criterion 2

        RuleForEach(x => x.Options).SetValidator(new CreateAssessmentOptionRequestValidator());
    }
}
