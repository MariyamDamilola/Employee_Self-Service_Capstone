namespace Employee_Self_Service_Capstone.Domain.Entities;

public class VacancyAllowedGrade
{
    public int Id { get; set; }

    public int VacancyId { get; set; }
    public Vacancy Vacancy { get; set; } = null!;

    public int GradeId { get; set; }
    public Grade Grade { get; set; } = null!;

}