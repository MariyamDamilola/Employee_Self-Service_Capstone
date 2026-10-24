using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class KpiReview
{
    public int Id { get; set; }
    public int KpiPlanId { get; set; }
    public KpiPlan KpiPlan { get; set; } = null!;
    public int ReviewerId { get; set; }
    public Employee Reviewer { get; set; } = null!;
    public string Comments { get; set; } = string.Empty;

    public KpiReviewStatus Status { get; set; } 
    public DateTime ReviewedAt { get; set; } = DateTime.UtcNow;
}