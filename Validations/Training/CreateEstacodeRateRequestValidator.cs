using Employee_Self_Service_Capstone.DTOs.Request.Training;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Training;

public class CreateEstacodeRateRequestValidator  : AbstractValidator<CreateEstacodeRateRequestDto>
{
    public CreateEstacodeRateRequestValidator()
    {
        RuleFor(x => x.CountryCode)
            .NotEmpty().WithMessage("Country code is required.")
            .Length(2, 3).WithMessage("Country code must be a 2 or 3 letter ISO code.");

        RuleFor(x => x.GradeId)
            .GreaterThan(0).WithMessage("Valid grade ID is required.");

        RuleFor(x => x.DailyRateUsd)
            .GreaterThan(0).WithMessage("Daily rate must be strictly greater than 0.");
    
    }

}