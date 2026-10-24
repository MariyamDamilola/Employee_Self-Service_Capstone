using Employee_Self_Service_Capstone.DTOs.Request.Notifications;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Notification;

public class MarkNotificationReadRequestValidator : AbstractValidator<MarkNotificationReadRequestDto>
{
    public MarkNotificationReadRequestValidator()
    {
        RuleFor(x => x.NotificationIds)
            .NotEmpty().WithMessage("At least one notification ID must be provided.")
            .Must(ids => ids != null && ids.Count > 0)
            .WithMessage("At least one notification ID must be provided.");

        RuleForEach(x => x.NotificationIds)
            .GreaterThan(0).WithMessage("Notification ID must be a positive integer.");
    
    }
   
}