namespace Employee_Self_Service_Capstone.DTOs.Response;

public class TrainingRequestResponseDto
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; } = string.Empty;
    public string EmployeeNumber { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;
    public string Provider { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;

    public DateTime TrainingStartDate { get; set; }
    public DateTime TrainingEndDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public DateTime ReturnDate { get; set; }

    public string BusinessJustification { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;

    public decimal CourseFee { get; set; }
    public string CourseFeeCurrency { get; set; } = string.Empty;
    public decimal FlightEstimate { get; set; }
    public string FlightCurrency { get; set; } = string.Empty;

    public int? AssignedReviewerId { get; set; }
    public string? AssignedReviewerName { get; set; }

    public DateTime CreatedAt { get; set; }

    public TrainingAllowanceResponseDto? CurrentAllowance { get; set; }
    public List<TrainingApprovalHistoryResponseDto> ApprovalHistory { get; set; } = new();
    public List<TrainingEvidenceResponseDto> EvidenceFiles { get; set; } = new();
}