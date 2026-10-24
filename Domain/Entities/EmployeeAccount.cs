using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class EmployeeAccount
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string PasswordHash { get; set; }
    public int FailedLoginAttempts { get; set; } = 0;
    public DateTime? LockoutEndUtc { get; set; }
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? LastLoginAtUtc { get; set; }
}