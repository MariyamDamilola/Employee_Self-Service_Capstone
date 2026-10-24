using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.DTOs.Request.Vacancies;

public class ReviewVacancyApplicationRequestDto
{
    public VacancyApplicationReviewDecision Decision { get; set; }
    public string? Comments { get; set; }
}