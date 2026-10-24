using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class TrainingRequest
{
   public int Id { get; set; }
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; } = null!;
    
    public int AssignedReviewerId { get; set; }
    public virtual Employee AssignedReviewer { get; set; } = null!;

    public string Title { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    public DateTime TrainingStartDate { get; set; }
    public DateTime TrainingEndDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public string BusinessJustification { get; set; } = string.Empty;
    
    public decimal CourseFee { get; set; }
    public string CourseFeeCurrency { get; set; } = string.Empty;
    public decimal FlightEstimate { get; set; }
    public string FlightCurrency { get; set; } = string.Empty;
    public TrainingRequestStatus Status { get; set; } = TrainingRequestStatus.Draft;
    public string? CloseOrWithdrawReason { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }
    public ICollection<TrainingAllowance> Allowances { get; set; } = new List<TrainingAllowance>();
    public ICollection<TrainingApprovalHistory> ApprovalHistories { get; set; } = new List<TrainingApprovalHistory>();
    public ICollection<TrainingEvidence> EvidenceFiles { get; set; } = new List<TrainingEvidence>();
    public ICollection<TrainingRequestComment> Comments { get; set; } = new List<TrainingRequestComment>();
    public ICollection<TrainingRequestAssignmentHistory> AssignmentHistories { get; set; } = new List<TrainingRequestAssignmentHistory>();
}