using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class Vacancy
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string OpportunityType { get; set; } = "InternalVacancy";
    public string DepartmentName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string EligibilityText { get; set; } = string.Empty;
    public DateTime ClosingDateUtc { get; set; }
    public VacancyApplicationStatus Status { get; set; }
    public int CreatedById { get; set; }
    public Employee CreatedBy { get; set; } = null!;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? PublishedAtUtc { get; set; }
    public ICollection<VacancyAllowedDepartment> AllowedDepartments { get; set; } = new List<VacancyAllowedDepartment>();
    public ICollection<VacancyAllowedGrade> AllowedGrades { get; set; } = new List<VacancyAllowedGrade>();

    public ICollection<VacancyApplication> Applications { get; set; } = new List<VacancyApplication>();
}