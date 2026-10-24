using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class TrainingRequestAssignmentHistory
{
    public int Id { get; set; }
    public int TrainingRequestId { get; set; }
    public TrainingRequest TrainingRequest { get; set; } = null!;
    public int PreviousManagerId { get; set; }
    public Employee PreviousManager { get; set; } = null!;
    public int NewManagerId { get; set; }
    public Employee NewManager { get; set; } = null!;

    public int ReassignedById { get; set; }
    public Employee ReassignedBy { get; set; } = null!;

    public TrainingRequestAssignmentAction Action { get; set; }
    public string Reason { get; set; } = string.Empty;

    public DateTime ReassignedAt { get; set; } = DateTime.UtcNow;
}