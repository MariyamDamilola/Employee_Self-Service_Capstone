using Employee_Self_Service_Capstone.Data;
using Employee_Self_Service_Capstone.Domain.Entities;
using Employee_Self_Service_Capstone.Domain.Enum;
using Employee_Self_Service_Capstone.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Repository.Implementations;

public class LmsRepository : ILmsRepository
{
    private readonly AppDbContext _context;

    public LmsRepository(AppDbContext context)
    {
        _context = context;
    }

   public async Task<Course?> GetCourseByIdAsync(int courseId)
    {
        return await _context.Courses
            .FirstOrDefaultAsync(c => c.Id == courseId);
    }

    public async Task<Course?> GetCourseWithModulesAndQuizAsync(int courseId)
    {
        return await _context.Courses
            .Include(c => c.Lessons)
            .Include(c => c.Assessment)
            .FirstOrDefaultAsync(c => c.Id == courseId);
    }

    public async Task<IEnumerable<Course>> GetAllActiveCoursesAsync()
    {
        return await _context.Courses
            .Where(c => c.IsPublished)
            .OrderBy(c => c.Title)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<CourseAssignment?> GetEnrollmentAsync(int courseId, int employeeId)
    {
        return await _context.CourseAssignments
            .Include(ca => ca.Course)
            .FirstOrDefaultAsync(ca => ca.CourseId == courseId && ca.EmployeeId == employeeId);
    }

    public async Task<IEnumerable<CourseAssignment>> GetEmployeeEnrollmentsAsync(int employeeId)
    {
        return await _context.CourseAssignments
            .Include(ca => ca.Course)
            .Where(ca => ca.EmployeeId == employeeId)
            .OrderByDescending(ca => ca.CreatedAt)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<CourseAssignment>> GetOverdueEnrollmentsAsync(DateTime thresholdUtc)
    {
        return await _context.CourseAssignments
            .Include(ca => ca.Course)
            .Include(ca => ca.Employee)
            .Where(ca => ca.Status != CourseAssignmentStatus.Completed && ca.DueDate < thresholdUtc)
            .OrderBy(ca => ca.DueDate)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddCourseAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
    }

    public async Task AddEnrollmentAsync(CourseAssignment assignment)
    {
        await _context.CourseAssignments.AddAsync(assignment);
    }

    public Task UpdateEnrollmentAsync(CourseAssignment assignment)
    {
        _context.CourseAssignments.Update(assignment);
        return Task.CompletedTask;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}