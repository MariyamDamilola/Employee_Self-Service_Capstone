using Employee_Self_Service_Capstone.Data;
using Employee_Self_Service_Capstone.Domain.Entities;
using Employee_Self_Service_Capstone.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Repository.Implementations;

public class PayslipRepository : IPayslipRepository
{
   private readonly AppDbContext _context;

    public PayslipRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Payslip?> GetByIdAsync(int id)
    {
        return await _context.Payslips
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Payslip?> GetPayslipWithDetailsAsync(int id)
    {
        return await _context.Payslips
            .Include(p => p.Employee)
            .Include(p => p.Versions)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Payslip?> GetEmployeePayslipByPeriodAsync(int employeeId, int month, int year)
    {
        return await _context.Payslips
            .Include(p => p.Employee)
            .Include(p => p.Versions)
            .FirstOrDefaultAsync(p =>
                p.EmployeeId == employeeId &&
                p.Month == month &&
                p.Year == year);
    }

    public async Task<IEnumerable<Payslip>> GetEmployeePayslipsAsync(int employeeId, int? year = null)
    {
        var query = _context.Payslips
            .Include(p => p.Versions)
            .Where(p => p.EmployeeId == employeeId);

        if (year.HasValue)
        {
            query = query.Where(p => p.Year == year.Value);
        }

        return await query
            .OrderByDescending(p => p.Year)
            .ThenByDescending(p => p.Month)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> PayslipExistsForPeriodAsync(int employeeId, int month, int year)
    {
        return await _context.Payslips
            .AnyAsync(p =>
                p.EmployeeId == employeeId &&
                p.Month == month &&
                p.Year == year);
    }

    public async Task AddAsync(Payslip payslip)
    {
        await _context.Payslips.AddAsync(payslip);
    }

    public Task UpdateAsync(Payslip payslip)
    {
        _context.Payslips.Update(payslip);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}