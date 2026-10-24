namespace Employee_Self_Service_Capstone.DTOs.Response;

public class TrainingAllowanceResponseDto
{
    public int Id { get; set; }
    public int Version { get; set; }
    public string GradeNameSnapshot { get; set; } = string.Empty;
    public decimal DailyRate { get; set; }
    public int EligibleDays { get; set; }
    public decimal Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public bool IsOverride { get; set; }
    public string? OverrideReason { get; set; }
    public DateTime CreatedAt { get; set; }
}