namespace Employee_Self_Service_Capstone.DTOs.Request.Notifications;

public class EnqueueEmailRequestDto
{
    public string RecipientEmail { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string? DeduplicationKey { get; set; }
}