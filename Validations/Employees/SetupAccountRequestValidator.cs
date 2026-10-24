using Employee_Self_Service_Capstone.DTOs.Request.Employees;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Employees;

public class SetupAccountRequestValidator : AbstractValidator<SetupAccountRequestDto>
{
    public SetupAccountRequestValidator()
    {
        RuleFor(x => x.Token)
            .NotEmpty().WithMessage("Account setup token is required.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one number.")
            .Matches(@"[\!\?\*\@\#\$\%\^\&\+\=]").WithMessage("Password must contain at least one special character.");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Passwords do not match.");
    }

}