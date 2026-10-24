using Employee_Self_Service_Capstone.Domain.Enum;
using Employee_Self_Service_Capstone.DTOs.Request.Training;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Training;

public class ReviewTrainingRequestValidator : AbstractValidator<ReviewTrainingRequestDto>
{
    public ReviewTrainingRequestValidator()
    {
        RuleFor(x => x.Action)
            .IsInEnum().WithMessage("Valid approval action is required.");

        RuleFor(x => x.Comments)
            .NotEmpty().When(x => x.Action == ApprovalAction.Rejected || x.Action == ApprovalAction.ReturnedToHR)
            .WithMessage("Comments are mandatory when rejecting or returning a training request to HR.");
    }

    
}