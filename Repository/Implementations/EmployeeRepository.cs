using Employee_Self_Service_Capstone.Data;
using Employee_Self_Service_Capstone.Domain.Entities;
using Employee_Self_Service_Capstone.Domain.Enum;
using Employee_Self_Service_Capstone.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Repository.Implementations;

public class EmployeeRepository : IEmployeeRepository
{
   private readonly AppDbContext _context;

    public EmployeeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Employee?> GetByIdAsync(int employeeId)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == employeeId);
    }

    public async Task<Employee?> GetByEmailAsync(string email)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.Email.ToLower() == email.Trim().ToLower());
    }

    public async Task<Employee?> GetByResetTokenAsync(string token)
    {
        return await _context.Employees
            .FirstOrDefaultAsync(e => e.PasswordResetToken == token &&
                                      (!e.PasswordResetTokenExpiry.HasValue || e.PasswordResetTokenExpiry > DateTime.UtcNow));
    }

    public async Task<Employee?> GetBySecurityTokenAsync(string token, AccountSecurityTokenPurpose purpose)
    {
        return await _context.Employees
            .Include(e => e.SecurityTokens)
            .FirstOrDefaultAsync(e => e.SecurityTokens.Any(t => t.TokenHash == token && t.Purpose == purpose));
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Employees
            .AnyAsync(e => e.Email.ToLower() == email.Trim().ToLower());
    }

    public async Task<bool> EmployeeNumberExistsAsync(string employeeNumber)
    {
        return await _context.Employees
            .AnyAsync(e => e.EmployeeNumber.ToLower() == employeeNumber.Trim().ToLower());
    }

    public async Task<Employee?> GetProfileWithDetailsAsync(int employeeId)
    {
        return await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Grade)
            .Include(e => e.ReportingManager)
            .Include(e => e.Account)
            .Include(e => e.EmployeeRoles)
            .FirstOrDefaultAsync(e => e.Id == employeeId);
    }

    public async Task<IReadOnlyList<Employee>> GetDirectReportsAsync(int managerId)
    {
        return await _context.Employees
            .Where(e => e.ReportingManagerId == managerId && e.IsActive)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Employee>> GetByDepartmentAsync(int departmentId)
    {
        return await _context.Employees
            .Where(e => e.DepartmentId == departmentId && e.IsActive)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(Employee employee)
    {
        await _context.Employees.AddAsync(employee);
    }

    public Task UpdateAsync(Employee employee)
    {
        _context.Employees.Update(employee);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}