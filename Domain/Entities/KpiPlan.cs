using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class KpiPlan
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public int AssignedReviewerId { get; set; }
    public Employee AssignedReviewer { get; set; } = null!;
    public string Title { get; set; } = string.Empty;
    public string ReviewPeriod { get; set; } = string.Empty;

    public DateTime PeriodStartDate { get; set; }
    public DateTime PeriodEndDate { get; set; }

    public DateTime SubmissionDeadline { get; set; }

    public KpiPlanStatus Status { get; set; } = KpiPlanStatus.Draft;

    public decimal? OverallScore { get; set; }

    public int CreatedById { get; set; }
    public Employee CreatedBy { get; set; } = null!;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ActivatedAt { get; set; }
    public DateTime? SubmittedAt { get; set; }
    public DateTime? FinalizedAt { get; set; }
    
    public ICollection<KpiItem> Items { get; set; } = new List<KpiItem>();
    public ICollection<KpiPlanHistory> Histories { get; set; } = new List<KpiPlanHistory>();
    public ICollection<KpiReview> Reviews { get; set; } = new List<KpiReview>();

}