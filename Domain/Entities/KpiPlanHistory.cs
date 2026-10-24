using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class KpiPlanHistory
{
    public int Id { get; set; }
    public int KpiPlanId { get; set; }
    public KpiPlan KpiPlan { get; set; } = null!;
    public int ActionById { get; set; }
    public Employee ActionBy { get; set; } = null!;
    public KpiPlanHistoryAction Action { get; set; }
    public string? Comments { get; set; }
    public DateTime? PreviousDeadline { get; set; }
    public DateTime? NewDeadline { get; set; }

    public DateTime ActionDate { get; set; } = DateTime.UtcNow;
}