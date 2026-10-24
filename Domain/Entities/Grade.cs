namespace Employee_Self_Service_Capstone.Domain.Entities;

public class Grade
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public ICollection<EstacodeRate> EstacodeRates { get; set; } = new List<EstacodeRate>();

}