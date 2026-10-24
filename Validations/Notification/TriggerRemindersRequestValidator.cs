using Employee_Self_Service_Capstone.DTOs.Request.Notifications;
using FluentValidation;

namespace Employee_Self_Service_Capstone.Validations.Notification;

public class TriggerRemindersRequestValidator : AbstractValidator<TriggerRemindersRequestDto>
{
    public TriggerRemindersRequestValidator()
    {
        RuleFor(x => x.ReminderType)
            .IsInEnum().When(x => x.ReminderType.HasValue)
            .WithMessage("Invalid reminder type specified.");
    }

}