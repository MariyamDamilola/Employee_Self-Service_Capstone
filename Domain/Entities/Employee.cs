namespace Employee_Self_Service_Capstone.Domain.Entities;

public class Employee
{
    
    public int Id { get; set; }
    public string EmployeeNumber { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? AccountSetupToken { get; set; }
    public DateTime? AccountSetupTokenExpiresAt { get; set; }
    public string? PasswordResetToken { get; set; }
    public DateTime? PasswordResetTokenExpiry { get; set; }
    public int DepartmentId { get; set; }
    public int GradeId { get; set; }
    public int? ReportingManagerId { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public Department? Department { get; set; } 
    public Grade? Grade { get; set; } 
    public Employee? ReportingManager { get; set; }
    public ICollection<Employee> DirectReports { get; set; } = new List<Employee>();
    public EmployeeAccount? Account { get; set; }
    public ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();
    public ICollection<AccountSecurityToken> SecurityTokens { get; set; } = new List<AccountSecurityToken>();
    public ICollection<TrainingRequest> TrainingRequests { get; set; } = new List<TrainingRequest>();
    public ICollection<TrainingRequest> AssignedTrainingReviews { get; set; } = new List<TrainingRequest>();
    public ICollection<CourseAssignment> CourseAssignments { get; set; } = new List<CourseAssignment>();
    public ICollection<KpiPlan> KpiPlans { get; set; } = new List<KpiPlan>();
    public ICollection<KpiPlan> AssignedKpiReviews { get; set; } = new List<KpiPlan>();
    public ICollection<Payslip> Payslips { get; set; } = new List<Payslip>();
    public ICollection<VacancyApplication> VacancyApplications { get; set; } = new List<VacancyApplication>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
    
   
   
}
