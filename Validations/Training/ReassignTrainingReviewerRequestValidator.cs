using Employee_Self_Service_Capstone.DTOs.Request.Training;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Training;

public class ReassignTrainingReviewerRequestValidator : AbstractValidator<ReassignTrainingReviewerRequestDto>
{
    public ReassignTrainingReviewerRequestValidator()
    {
        RuleFor(x => x.NewManagerId)
            .GreaterThan(0).WithMessage("A valid target manager ID is required.");

        RuleFor(x => x.Reason)
            .NotEmpty().WithMessage("A reason is mandatory when reassigning a reviewer.")
            .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters.");
    }

}