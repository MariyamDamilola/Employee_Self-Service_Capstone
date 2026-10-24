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

    public async Task<Payslip?> GetByIdAsync(int payslipId)
    {
        return await _context.Payslips
            .Include(p => p.Employee)
            .Include(p => p.AllowanceItems)
            .Include(p => p.DeductionItems)
            .FirstOrDefaultAsync(p => p.Id == payslipId);
    }

    public async Task<Payslip?> GetByEmployeeAndPeriodAsync(
        int employeeId,
        int payrollMonth,
        int payrollYear)
    {
        return await _context.Payslips
            .Include(p => p.AllowanceItems)
            .Include(p => p.DeductionItems)
            .FirstOrDefaultAsync(p =>
                p.EmployeeId == employeeId &&
                p.PayrollMonth == payrollMonth &&
                p.PayrollYear == payrollYear);
    }

    public async Task AddAsync(Payslip payslip)
    {
        await _context.Payslips.AddAsync(payslip);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    } 
}