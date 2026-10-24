using Employee_Self_Service_Capstone.Data;
using Employee_Self_Service_Capstone.Domain.Entities;
using Employee_Self_Service_Capstone.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Repository.Implementations;

public class GradeRepository : IGradeRepository
{
    private readonly AppDbContext _context;

    public GradeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Grade?> GetByIdAsync(int gradeId)
    {
        return await _context.Grades
            .FirstOrDefaultAsync(g => g.Id == gradeId);
    }

    public async Task<Grade?> GetByNameAsync(string name)
    {
        return await _context.Grades
            .FirstOrDefaultAsync(g => g.Name == name);
    }

    public async Task<bool> ExistsByNameAsync(string name)
    {
        return await _context.Grades
            .AnyAsync(g => g.Name == name);
    }
    
    public async Task<bool> ExistsByCodeAsync(string code)
    {
        return await _context.Grades
            .AnyAsync(g => g.Code == code);
    }

    public async Task AddAsync(Grade grade)
    {
        await _context.Grades.AddAsync(grade);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}