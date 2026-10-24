namespace Employee_Self_Service_Capstone.DTOs.Response;

public class VacancyResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string OpportunityType { get; set; } = string.Empty;
    public string DepartmentName { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string EligibilityText { get; set; } = string.Empty;

    public DateTime ClosingDateUtc { get; set; }
    public bool IsClosed { get; set; }
    public bool IsPublished { get; set; }

    public List<int> AllowedDepartmentIds { get; set; } = new();
    public List<int> AllowedGradeIds { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}