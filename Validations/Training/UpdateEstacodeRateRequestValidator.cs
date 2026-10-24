using Employee_Self_Service_Capstone.DTOs.Request.Training;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Training;

public class UpdateEstacodeRateRequestValidator : AbstractValidator<UpdateEstacodeRateRequestDto>
{
    public UpdateEstacodeRateRequestValidator()
    {
        RuleFor(x => x.DailyRateUsd)
            .GreaterThan(0).WithMessage("Daily rate must be strictly greater than 0.");
    
    }

}