using Employee_Self_Service_Capstone.DTOs.Request.Vacancies;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Vacancies;

public class UpdateVacancyDraftRequestValidator : AbstractValidator<UpdateVacancyDraftRequestDto>
{
    public UpdateVacancyDraftRequestValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Vacancy title is required.")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");

        RuleFor(x => x.OpportunityType)
            .NotEmpty().WithMessage("Opportunity type is required.")
            .Must(type => type == "InternalVacancy" || type == "DevelopmentOpportunity")
            .WithMessage("Opportunity type must be either 'InternalVacancy' or 'DevelopmentOpportunity'.");

        RuleFor(x => x.DepartmentName)
            .NotEmpty().WithMessage("Department name is required.")
            .MaximumLength(150).WithMessage("Department name cannot exceed 150 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.");

        RuleFor(x => x.EligibilityText)
            .NotEmpty().WithMessage("Eligibility criteria description is required.");

        RuleFor(x => x.ClosingDateUtc)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Closing date must be strictly in the future.");

        RuleForEach(x => x.AllowedDepartmentIds)
            .GreaterThan(0).WithMessage("Department ID must be a positive integer.");

        RuleForEach(x => x.AllowedGradeIds)
            .GreaterThan(0).WithMessage("Grade ID must be a positive integer.");
    }

}