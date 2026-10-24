namespace Employee_Self_Service_Capstone.DTOs.Response;

public class KpiItemResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Target { get; set; }
    public string Unit { get; set; } = string.Empty;
    public decimal Weight { get; set; }
    public decimal? ActualValue { get; set; }
    public decimal? AchievementPercentage { get; set; }
    public decimal? WeightedScore { get; set; }
    public string? EvidenceComments { get; set; }
    public string ReviewStatus { get; set; } = string.Empty;
}