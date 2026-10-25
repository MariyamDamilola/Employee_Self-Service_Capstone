using Employee_Self_Service_Capstone.Data;
using Employee_Self_Service_Capstone.Domain.Entities;
using Employee_Self_Service_Capstone.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Repository.Implementations;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly AppDbContext _context;

    public DepartmentRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Department?> GetByIdAsync(int departmentId)
    {
        return await _context.Departments
            .FirstOrDefaultAsync(d => d.Id == departmentId);
    }

    public async Task<Department?> GetByCodeAsync(string code)
    {
        return await _context.Departments
            .FirstOrDefaultAsync(d => d.Code == code);
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _context.Departments
            .OrderBy(d => d.Name)
            .AsNoTracking()
            .ToListAsync();
    }
    
    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Departments
            .AnyAsync(d => d.Name == name);
    }

    public async Task<bool> ExistsByCodeAsync(string code)
    {
        return await _context.Departments
            .AnyAsync(d => d.Code.ToLower() == code.Trim().ToLower());
    }

    public async Task AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}