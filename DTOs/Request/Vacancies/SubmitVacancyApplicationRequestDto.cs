namespace Employee_Self_Service_Capstone.DTOs.Request.Vacancies;

public class SubmitVacancyApplicationRequestDto
{
    public int VacancyId { get; set; }
    public string SupportingStatement { get; set; } = string.Empty;
}