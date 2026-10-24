using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class EmailReminderLog
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    public ReminderType ReminderType { get; set; }
    public string ReferenceId { get; set; } = string.Empty;
    public string DeduplicationKey { get; set; } = string.Empty;
    public DateTime ReminderDate { get; set; } = DateTime.UtcNow;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}