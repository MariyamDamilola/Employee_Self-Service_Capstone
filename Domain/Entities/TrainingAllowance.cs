namespace Employee_Self_Service_Capstone.Domain.Entities;

public class TrainingAllowance
{
    public int Id { get; set; }
    public int TrainingRequestId { get; set; }
    public virtual TrainingRequest TrainingRequest { get; set; } = null!;
    public int Version { get; set; } = 1;
    public string GradeNameSnapshot { get; set; } = string.Empty;
    public decimal DailyRate { get; set; }
    public string Currency { get; set; } = "USD";
    public int EligibleDays { get; set; }
    public decimal Amount { get; set; }
    public bool IsOverride { get; set; } = false;
    public string? OverrideReason { get; set; }

    public int CreatedByUserId { get; set; }
    public virtual Employee CreatedByUser { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}