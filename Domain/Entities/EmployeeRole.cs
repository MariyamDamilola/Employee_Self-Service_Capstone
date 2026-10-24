namespace Employee_Self_Service_Capstone.Domain.Entities;

public class EmployeeRole
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
}