using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class InternalOpportunity
{
    public int Id { get; set; }
    public string ReferenceNumber { get; set; } = string.Empty; 
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Requirements { get; set; } = string.Empty;
    public string EligibilityText { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string JobType { get; set; } = "Full-Time";

    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;

    public int PostedById { get; set; }
    public Employee PostedBy { get; set; } = null!;

    public DateTime ClosingDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PublishedAt { get; set; }
    public OpportunityStatus Status { get; set; } = OpportunityStatus.Draft;

    // Eligibility rules: which depts & grades can see/apply
    public ICollection<OpportunityAllowedDepartment> AllowedDepartments { get; set; } = new List<OpportunityAllowedDepartment>();
    public ICollection<OpportunityAllowedGrade> AllowedGrades { get; set; } = new List<OpportunityAllowedGrade>();

    // Employee applications for this opening
    public ICollection<VacancyApplication> Applications { get; set; } = new List<VacancyApplication>();
}