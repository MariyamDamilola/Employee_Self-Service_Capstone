using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class VacancyApplication
{
    public int Id { get; set; }
    public int VacancyId { get; set; }
    public Vacancy Vacancy { get; set; } = null!;
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;
    public int DepartmentIdSnapshot { get; set; }
    public int GradeIdSnapshot { get; set; }

    public string SupportingStatement { get; set; } = string.Empty;
    public string? CvFilePath { get; set; }
    public string? CvFileName { get; set; }
    public VacancyApplicationStatus Status { get; set; } = VacancyApplicationStatus.Submitted;

    public DateTime AppliedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? StatusUpdatedAtUtc { get; set; }

    public ICollection<VacancyApplicationReview> Reviews { get; set; } = new List<VacancyApplicationReview>();
}