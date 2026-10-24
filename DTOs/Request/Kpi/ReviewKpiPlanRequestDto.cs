using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.DTOs.Request.Kpi;

public class ReviewKpiPlanRequestDto
{
    public KpiReviewStatus Status { get; set; }
    public string? Comments { get; set; }
    public List<KpiItemReviewDecisionDto> ItemReviews { get; set; } = new();

}