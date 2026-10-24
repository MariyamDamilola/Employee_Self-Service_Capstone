using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class EmailQueue
{
    public int Id { get; set; }
    public string RecipientEmail { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public EmailQueueStatus Status { get; set; } = EmailQueueStatus.Pending;
    public int RetryCount { get; set; } = 0;
    public DateTime NextAttemptTime { get; set; } = DateTime.UtcNow;
    public DateTime? ClaimedAt { get; set; }
    public string? DeduplicationKey { get; set; }
    public string? LastError { get; set; }
    public DateTime? SentAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ICollection<EmailQueueAttempt> Attempts { get; set; } = new List<EmailQueueAttempt>();

}