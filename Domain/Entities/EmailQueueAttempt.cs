using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class EmailQueueAttempt
{
    public int Id { get; set; }
    public int EmailQueueId { get; set; }
    public EmailQueue EmailQueue { get; set; } = null!;
    public int AttemptNumber { get; set; }
    public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;
    public bool IsSuccess { get; set; }
    public string? ErrorMessage { get; set; }
}