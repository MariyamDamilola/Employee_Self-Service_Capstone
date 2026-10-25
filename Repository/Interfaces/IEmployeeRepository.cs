using Employee_Self_Service_Capstone.Domain.Entities;
using Employee_Self_Service_Capstone.Domain.Enum;

namespace Employee_Self_Service_Capstone.Repository.Interfaces;

public interface IEmployeeRepository
{
    Task<Employee?> GetByIdAsync(int employeeId);

    Task<Employee?> GetByEmailAsync(string email);

    Task<Employee?> GetByResetTokenAsync(string token);

    Task<Employee?> GetBySecurityTokenAsync(string token, AccountSecurityTokenPurpose purpose);
    Task<bool> EmailExistsAsync(string email);

    Task<bool> EmployeeNumberExistsAsync(string employeeNumber);

    Task<Employee?> GetProfileWithDetailsAsync(int employeeId);

    Task<IReadOnlyList<Employee>> GetDirectReportsAsync(int managerId);

    Task<IReadOnlyList<Employee>> GetByDepartmentAsync(int departmentId);

    Task AddAsync(Employee employee);

    Task UpdateAsync(Employee employee);

    Task<bool> SaveChangesAsync();
}