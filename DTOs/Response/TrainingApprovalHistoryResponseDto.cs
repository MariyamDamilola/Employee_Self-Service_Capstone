namespace Employee_Self_Service_Capstone.DTOs.Response;

public class TrainingApprovalHistoryResponseDto
{
    public int Id { get; set; }
    public string ReviewerName { get; set; } = string.Empty;
    public string RoleAtAction { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string? Comments { get; set; }
    public DateTime CreatedAt { get; set; }
}