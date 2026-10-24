using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class TrainingApprovalHistory
{
    public int Id { get; set; }
    public int TrainingRequestId { get; set; }
    public TrainingRequest TrainingRequest { get; set; }
    public int ReviewerId { get; set; }
    public Employee Reviewer { get; set; }
    public string? RoleAtAction { get; set; }
    public ApprovalAction Action { get; set; }
    public string? Comment { get; set; }
    public DateTime ActionDate { get; set; } = DateTime.UtcNow;
}