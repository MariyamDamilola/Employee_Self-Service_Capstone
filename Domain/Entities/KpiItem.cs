namespace Employee_Self_Service_Capstone.Domain.Entities;

public class KpiItem
{
    public int Id { get; set; }
    public int KpiPlanId { get; set; }
    public KpiPlan KpiPlan { get; set; } = null!;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public decimal Target { get; set; }

    public decimal? ActualValue { get; set; }

    public string Unit { get; set; } = string.Empty;
    public decimal Weight { get; set; }

   
    public decimal? AchievementPercentage { get; set; }

    public decimal? WeightedScore { get; set; }
    
    public string? EvidenceComments { get; set; }
    public string? EvidenceFilePath { get; set; }
    public string? EvidenceFileName { get; set; }
    public string? EvidenceContentType { get; set; }

    public ICollection<KpiItemReview> ItemReviews { get; set; } = new List<KpiItemReview>();
}