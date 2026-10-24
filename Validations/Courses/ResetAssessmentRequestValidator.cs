using Employee_Self_Service_Capstone.DTOs.Request.Courses;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Courses;

public class ResetAssessmentRequestValidator  : AbstractValidator<ResetAssessmentRequestDto>
{
    public ResetAssessmentRequestValidator()
    {
        RuleFor(x => x.Reason)
            .NotEmpty().WithMessage("A reason is required to reset an exhausted assignment.")
            .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters.");
    
    }

    
}