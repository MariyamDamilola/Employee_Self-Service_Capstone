namespace Employee_Self_Service_Capstone.DTOs.Request.Kpi;

public class ReopenKpiPlanRequestDto
{
    public string Reason { get; set; } = string.Empty;
    public DateTime NewSubmissionDeadline { get; set; }
}