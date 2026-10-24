namespace Employee_Self_Service_Capstone.Domain.Entities;

public class VacancyAllowedDepartment
{
    public int Id { get; set; }

    public int VacancyId { get; set; }
    public Vacancy Vacancy { get; set; } = null!;

    public int DepartmentId { get; set; }
    public Department Department { get; set; } = null!;
}