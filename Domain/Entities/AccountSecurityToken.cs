using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Domain.Entities;

public class AccountSecurityToken
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    public string TokenHash { get; set; }
    public AccountSecurityTokenPurpose Purpose { get; set; }
    public bool IsUsed { get; set; } = false;
    public DateTime ExpiresAt { get; set; }
    public DateTime? UsedAt { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}