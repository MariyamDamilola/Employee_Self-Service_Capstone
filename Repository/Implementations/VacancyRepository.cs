using Employee_Self_Service_Capstone.Data;
using Employee_Self_Service_Capstone.Domain.Entities;
using Employee_Self_Service_Capstone.Domain.Enum;
using Employee_Self_Service_Capstone.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Repository.Implementations;

public class VacancyRepository : IVacancyRepository
{
    
   private readonly AppDbContext _context;

    public VacancyRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<InternalOpportunity?> GetByIdAsync(int id)
    {
        return await _context.InternalOpportunities
            .Include(o => o.Department)
            .Include(o => o.PostedBy)
            .Include(o => o.AllowedDepartments)
                .ThenInclude(ad => ad.Department)
            .Include(o => o.AllowedGrades)
                .ThenInclude(ag => ag.Grade)
            .FirstOrDefaultAsync(o => o.Id == id);
    }

    public async Task<InternalOpportunity?> GetVacancyWithApplicationsAsync(int vacancyId)
    {
        return await _context.InternalOpportunities
            .Include(o => o.Department)
            .Include(o => o.PostedBy)
            .Include(o => o.AllowedDepartments)
            .Include(o => o.AllowedGrades)
            .Include(o => o.Applications)
                .ThenInclude(a => a.Applicant)
            .FirstOrDefaultAsync(o => o.Id == vacancyId);
    }

    public async Task<IEnumerable<InternalOpportunity>> GetActiveVacanciesAsync(DateTime nowUtc)
    {
        return await _context.InternalOpportunities
            .Include(o => o.Department)
            .Include(o => o.AllowedDepartments)
            .Include(o => o.AllowedGrades)
            .Where(o => o.Status == OpportunityStatus.Published &&
                        o.ClosingDate >= nowUtc)
            .OrderBy(o => o.ClosingDate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<VacancyApplication?> GetApplicationAsync(int vacancyId, int employeeId)
    {
        return await _context.VacancyApplications
            .Include(a => a.InternalOpportunity)
            .Include(a => a.Applicant)
            .Include(a => a.ReviewedBy)
            .FirstOrDefaultAsync(a => a.InternalOpportunityId == vacancyId &&
                                      a.ApplicantEmployeeId == employeeId);
    }

    public async Task<IEnumerable<VacancyApplication>> GetApplicationsByEmployeeAsync(int employeeId)
    {
        return await _context.VacancyApplications
            .Include(a => a.InternalOpportunity)
                .ThenInclude(o => o.Department)
            .Where(a => a.ApplicantEmployeeId == employeeId)
            .OrderByDescending(a => a.AppliedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<bool> HasAppliedAsync(int vacancyId, int employeeId)
    {
        return await _context.VacancyApplications
            .AnyAsync(a => a.InternalOpportunityId == vacancyId &&
                           a.ApplicantEmployeeId == employeeId);
    }

    public async Task AddVacancyAsync(InternalOpportunity vacancy)
    {
        await _context.InternalOpportunities.AddAsync(vacancy);
    }

    public async Task AddApplicationAsync(VacancyApplication application)
    {
        await _context.VacancyApplications.AddAsync(application);
    }

    public Task UpdateVacancyAsync(InternalOpportunity vacancy)
    {
        _context.InternalOpportunities.Update(vacancy);
        return Task.CompletedTask;
    }

    public Task UpdateApplicationAsync(VacancyApplication application)
    {
        _context.VacancyApplications.Update(application);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
}