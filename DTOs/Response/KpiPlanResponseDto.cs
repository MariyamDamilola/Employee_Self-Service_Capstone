namespace Employee_Self_Service_Capstone.DTOs.Response;

public class KpiPlanResponseDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string ReviewPeriod { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty; // Draft, Active, Submitted, Returned, Finalized

    public DateTime PeriodStartDate { get; set; }
    public DateTime PeriodEndDate { get; set; }
    public DateTime SubmissionDeadline { get; set; }

    public int? AssignedReviewerId { get; set; }
    public string? AssignedReviewerName { get; set; }

    public decimal? OverallScore { get; set; }
    public List<KpiItemResponseDto> Items { get; set; } = new();
}