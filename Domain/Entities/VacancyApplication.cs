using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class VacancyApplication
{
    public int Id { get; set; }

    public int InternalOpportunityId { get; set; }
    public InternalOpportunity InternalOpportunity { get; set; } = null!;

    public int ApplicantEmployeeId { get; set; }
    public Employee Applicant { get; set; } = null!;

    public string CoverLetterOrPitch { get; set; } = string.Empty;
    public string? ResumeFilePath { get; set; }

    public VacancyApplicationStatus Status { get; set; } = VacancyApplicationStatus.Submitted;

    public int? ReviewedById { get; set; }
    public Employee? ReviewedBy { get; set; }
    public string? ReviewerFeedback { get; set; }

    public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
}