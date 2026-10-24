namespace Employee_Self_Service_Capstone.DTOs.Request.Vacancies;

public class UpdateVacancyDraftRequestDto
{
    public string Title { get; set; } = string.Empty;
    public string OpportunityType { get; set; } = "InternalVacancy";
    public string DepartmentName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string EligibilityText { get; set; } = string.Empty;
    public DateTime ClosingDateUtc { get; set; }

    public List<int> AllowedDepartmentIds { get; set; } = new();
    public List<int> AllowedGradeIds { get; set; } = new();
}