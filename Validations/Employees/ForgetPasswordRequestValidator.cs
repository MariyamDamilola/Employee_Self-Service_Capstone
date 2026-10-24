using Employee_Self_Service_Capstone.DTOs.Request.Employees;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Employees;

public class ForgetPasswordRequestValidator  : AbstractValidator<ForgotPasswordRequestDto>
{
    public ForgetPasswordRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Enter a valid email address.")
            .MaximumLength(256);
    }

    
}