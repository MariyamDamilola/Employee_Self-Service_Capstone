using Employee_Self_Service_Capstone.Domain.Entities;

namespace Employee_Self_Service_Capstone.Repository.Interfaces;

public interface IVacancyRepository
{
    Task<InternalOpportunity?> GetByIdAsync(int id);

    Task<InternalOpportunity?> GetVacancyWithApplicationsAsync(int vacancyId);

    Task<IReadOnlyList<InternalOpportunity>> GetActiveVacanciesAsync(DateTime nowUtc);

    Task<VacancyApplication?> GetApplicationAsync(int vacancyId, int employeeId);

    Task<IReadOnlyList<VacancyApplication>> GetApplicationsByEmployeeAsync(int employeeId);

    Task<bool> HasAppliedAsync(int vacancyId, int employeeId);

    Task AddVacancyAsync(InternalOpportunity vacancy);

    Task AddApplicationAsync(VacancyApplication application);

    Task UpdateVacancyAsync(InternalOpportunity vacancy);

    Task UpdateApplicationAsync(VacancyApplication application);

    Task<bool> SaveChangesAsync();
}