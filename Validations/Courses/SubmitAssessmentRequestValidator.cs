using Employee_Self_Service_Capstone.DTOs.Request.Courses;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Courses;

public class SubmitAssessmentRequestValidator : AbstractValidator<SubmitAssessmentRequestDto>
{
    public SubmitAssessmentRequestValidator()
    {
        RuleFor(x => x.Answers)
            .NotEmpty().WithMessage("Assessment answers cannot be empty.")
            .Must(answers => answers != null && answers.Select(a => a.QuestionId).Distinct().Count() == answers.Count)
            .WithMessage("Each question can only be answered once in a submission."); // LMS-03 Criterion 4

        RuleForEach(x => x.Answers).ChildRules(answer =>
        {
            answer.RuleFor(a => a.QuestionId).GreaterThan(0).WithMessage("Valid Question ID is required.");
            answer.RuleFor(a => a.SelectedOptionId).GreaterThan(0).WithMessage("Valid Selected Option ID is required.");
        });
    }
}
