namespace Employee_Self_Service_Capstone.DTOs.Request.Training;

public class CalculateAllowanceRequestDto
{
    public bool IsOverride { get; set; }
    public decimal? OverrideDailyRate { get; set; }
    public int? OverrideEligibleDays { get; set; }
    public string? OverrideReason { get; set; }
}