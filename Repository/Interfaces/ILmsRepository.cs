using Employee_Self_Service_Capstone.Domain.Entities;

namespace Employee_Self_Service_Capstone.Repository.Interfaces;

public interface ILmsRepository
{
    Task<Course?> GetCourseByIdAsync(int courseId);

    Task<Course?> GetCourseWithModulesAndQuizAsync(int courseId);

    Task<IReadOnlyList<Course>> GetAllActiveCoursesAsync();

    Task<CourseAssignment?> GetEnrollmentAsync(int courseId, int employeeId);

    Task<IReadOnlyList<CourseAssignment>> GetEmployeeEnrollmentsAsync(int employeeId);

    Task<IReadOnlyList<CourseAssignment>> GetOverdueEnrollmentsAsync(DateTime thresholdUtc);

    Task AddCourseAsync(Course course);

    Task AddEnrollmentAsync(CourseAssignment assignment);

    Task UpdateEnrollmentAsync(CourseAssignment assignment);

    Task<bool> SaveChangesAsync();
}