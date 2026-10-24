using Employee_Self_Service_Capstone.Domain.Entities;

namespace Employee_Self_Service_Capstone.Repository.Interfaces;

public interface IKpiPlanRepository
{
    Task<KpiPlan?> GetByIdAsync(int id);

    Task<KpiPlan?> GetPlanWithItemsAsync(int planId);

    Task<IReadOnlyList<KpiPlan>> GetEmployeePlansAsync(int employeeId);

    Task<IReadOnlyList<KpiPlan>> GetPendingReviewsByManagerAsync(int managerId);

    Task<bool> HasActivePlanForPeriodAsync(int employeeId, string reviewPeriod, int? excludePlanId = null);

    Task AddAsync(KpiPlan plan);

    Task UpdateAsync(KpiPlan plan);

    Task<bool> SaveChangesAsync();
}