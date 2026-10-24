using Employee_Self_Service_Capstone.DTOs.Request.Training;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Training;

public class CreateTrainingRequestValidator : AbstractValidator<CreateTrainingRequestDto>
{
    public CreateTrainingRequestValidator()
    {
       RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Training title is required.")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

        RuleFor(x => x.Provider)
            .NotEmpty().WithMessage("Training provider is required.")
            .MaximumLength(150).WithMessage("Provider cannot exceed 150 characters.");

        RuleFor(x => x.CountryCode)
            .NotEmpty().WithMessage("Destination country code is required.")
            .Length(2, 3).WithMessage("Country code must be a 2 or 3 letter ISO code.");

        RuleFor(x => x.City)
            .NotEmpty().WithMessage("Destination city is required.")
            .MaximumLength(100).WithMessage("City cannot exceed 100 characters.");

        RuleFor(x => x.BusinessJustification)
            .NotEmpty().WithMessage("Business justification is required.");

        RuleFor(x => x.TrainingStartDate)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Training start date must be in the future.");

        RuleFor(x => x.TrainingEndDate)
            .GreaterThanOrEqualTo(x => x.TrainingStartDate)
            .WithMessage("Training end date must be on or after the start date.");

        RuleFor(x => x.DepartureDate)
            .LessThanOrEqualTo(x => x.TrainingStartDate)
            .WithMessage("Departure date must be on or before the training start date.");

        RuleFor(x => x.ReturnDate)
            .GreaterThanOrEqualTo(x => x.TrainingEndDate)
            .WithMessage("Return date must be on or after the training end date.")
            .GreaterThanOrEqualTo(x => x.DepartureDate)
            .WithMessage("Return date must be on or after the departure date.");

        RuleFor(x => x.CourseFee)
            .GreaterThanOrEqualTo(0).WithMessage("Course fee cannot be negative.");

        RuleFor(x => x.CourseFeeCurrency)
            .NotEmpty().WithMessage("Course fee currency is required.")
            .Length(3).WithMessage("Currency code must be 3 letters (e.g., USD, NGN, GBP).");

        RuleFor(x => x.FlightEstimate)
            .GreaterThanOrEqualTo(0).WithMessage("Flight estimate cannot be negative.");

        RuleFor(x => x.FlightCurrency)
            .NotEmpty().WithMessage("Flight currency is required.")
            .Length(3).WithMessage("Currency code must be 3 letters.");
    }

    
}