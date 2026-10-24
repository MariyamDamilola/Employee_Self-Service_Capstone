using Employee_Self_Service_Capstone.DTOs.Request.Training;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Training;

public class WithdrawTrainingRequestValidator  : AbstractValidator<WithdrawTrainingRequestDto>
{
    public WithdrawTrainingRequestValidator()
    {
        RuleFor(x => x.Reason)
            .NotEmpty().WithMessage("A reason is mandatory when withdrawing a training request.")
            .MaximumLength(500).WithMessage("Reason cannot exceed 500 characters.");
    }

}