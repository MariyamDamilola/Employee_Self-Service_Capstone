using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.DTOs.Request.Kpi;

public class KpiItemReviewDecisionDto
{
    public int KpiItemId { get; set; }
    public KpiItemReviewStatus Status { get; set; }
    public string? Comments { get; set; }
}