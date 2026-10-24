namespace Employee_Self_Service_Capstone.DTOs.Request.Kpi;

public class UpdateKpiPlanDraftRequestDto
{
    public string Title { get; set; } = string.Empty;
    public DateTime PeriodStartDate { get; set; }
    public DateTime PeriodEndDate { get; set; }
    public DateTime SubmissionDeadline { get; set; }
    public List<CreateKpiItemRequestDto> Items { get; set; } = new();
}