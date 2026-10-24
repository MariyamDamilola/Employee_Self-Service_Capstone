using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.DTOs.Request.Notifications;

public class TriggerRemindersRequestDto
{
    public ReminderType? ReminderType { get; set; }
}