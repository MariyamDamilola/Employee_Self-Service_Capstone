using Employee_Self_Service_Capstone.Data;
using Employee_Self_Service_Capstone.Domain.Entities;
using Employee_Self_Service_Capstone.Domain.Enum;
using Employee_Self_Service_Capstone.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Repository.Implementations;

public class KpiRepository : IKpiPlanRepository
{
    private readonly AppDbContext _context;

    public KpiRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<KpiPlan?> GetByIdAsync(int id)
    {
        return await _context.KpiPlans
            .FirstOrDefaultAsync(k => k.Id == id);
    }

    public async Task<KpiPlan?> GetPlanWithItemsAsync(int planId)
    {
        return await _context.KpiPlans
            .Include(k => k.Employee)
            .Include(k => k.AssignedReviewer)
            .Include(k => k.Items)
            .FirstOrDefaultAsync(k => k.Id == planId);
    }

    public async Task<IEnumerable<KpiPlan>> GetEmployeePlansAsync(int employeeId)
    {
        return await _context.KpiPlans
            .Include(k => k.Items)
            .Where(k => k.EmployeeId == employeeId)
            .OrderByDescending(k => k.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<KpiPlan>> GetPendingReviewsByManagerAsync(int managerId)
    {
        return await _context.KpiPlans
            .Include(k => k.Employee)
            .Include(k => k.Items)
            .Where(k => k.AssignedReviewerId == managerId && k.Status == KpiPlanStatus.Submitted)
            .OrderByDescending(k => k.SubmittedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> HasActivePlanForPeriodAsync(int employeeId, string reviewPeriod, int? excludePlanId = null)
    {
        return await _context.KpiPlans
            .AnyAsync(k =>
                k.EmployeeId == employeeId &&
                k.ReviewPeriod.ToLower() == reviewPeriod.Trim().ToLower() &&
                (!excludePlanId.HasValue || k.Id != excludePlanId.Value));
    }

    public async Task AddAsync(KpiPlan plan)
    {
        await _context.KpiPlans.AddAsync(plan);
    }

    public Task UpdateAsync(KpiPlan plan)
    {
        _context.KpiPlans.Update(plan);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}