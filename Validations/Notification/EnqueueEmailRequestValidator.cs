using Employee_Self_Service_Capstone.DTOs.Request.Notifications;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Notification;

public class EnqueueEmailRequestValidator : AbstractValidator<EnqueueEmailRequestDto>
{
    public EnqueueEmailRequestValidator()
    {
        RuleFor(x => x.RecipientEmail)
            .NotEmpty().WithMessage("Recipient email is required.")
            .EmailAddress().WithMessage("A valid recipient email is required.")
            .MaximumLength(150).WithMessage("Recipient email cannot exceed 150 characters.");

        RuleFor(x => x.Subject)
            .NotEmpty().WithMessage("Subject is required.")
            .MaximumLength(250).WithMessage("Subject cannot exceed 250 characters.");

        RuleFor(x => x.Body)
            .NotEmpty().WithMessage("Body cannot be empty.");

        RuleFor(x => x.DeduplicationKey)
            .MaximumLength(200).When(x => !string.IsNullOrEmpty(x.DeduplicationKey))
            .WithMessage("Deduplication key cannot exceed 200 characters.");
    }

}