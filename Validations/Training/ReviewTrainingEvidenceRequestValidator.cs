using Employee_Self_Service_Capstone.Domain.Enum;
using Employee_Self_Service_Capstone.DTOs.Request.Training;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Training;

public class ReviewTrainingEvidenceRequestValidator : AbstractValidator<ReviewTrainingEvidenceRequestDto>
{
    public ReviewTrainingEvidenceRequestValidator()
    {
        RuleFor(x => x.Status)
            .IsInEnum().WithMessage("Valid completion status is required.");

        RuleFor(x => x.ReviewComment)
            .NotEmpty().When(x => x.Status == TrainingCompletionStatus.Returned)
            .WithMessage("A comment is mandatory when returning completion evidence to the employee.");
    }

}