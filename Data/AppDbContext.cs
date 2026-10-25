using Employee_Self_Service_Capstone.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee_Self_Service_Capstone.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    
    // ==========================================
    // Module 1: Identity & Security
    // ==========================================
    public DbSet<Department> Departments { get; set; }

    public DbSet<Grade> Grades { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeAccount> EmployeeAccounts { get; set; }
    public DbSet<AccountSecurityToken> AccountSecurityTokens { get; set; }

    // ==========================================
    // Module 2: Training & Estacode
    // ==========================================
    public DbSet<EstacodeRate> EstacodeRates { get; set; }
    public DbSet<TrainingRequest> TrainingRequests { get; set; }
    public DbSet<TrainingAllowance> TrainingAllowances { get; set; }
    public DbSet<TrainingApprovalHistory> TrainingApprovalHistories { get; set; }
    public DbSet<TrainingEvidence> TrainingEvidences { get; set; }
    public DbSet<TrainingRequestAssignmentHistory> TrainingRequestAssignmentHistories { get; set; }
    public DbSet<TrainingRequestComment> TrainingRequestComments { get; set; }

    // ==========================================
    // Module 3: Learning Management System (LMS)
    // ==========================================
    public DbSet<Course> Courses { get; set; }
    public DbSet<CourseLesson> CourseLessons { get; set; }
    public DbSet<CourseAssessment> CourseAssessments { get; set; }
    public DbSet<AssessmentQuestion> AssessmentQuestions { get; set; }
    public DbSet<AssessmentOption> AssessmentOptions { get; set; }
    public DbSet<CourseAssignment> CourseAssignments { get; set; }
    public DbSet<LessonProgress> LessonProgresses { get; set; }
    public DbSet<AssessmentAttempt> AssessmentAttempts { get; set; }
    public DbSet<AssessmentAnswer> AssessmentAnswers { get; set; }
    public DbSet<AssessmentResetHistory> AssessmentResetHistories { get; set; }

    // ==========================================
    // Module 4: Performance & KPI Management
    // ==========================================
    public DbSet<KpiPlan> KpiPlans { get; set; }
    public DbSet<KpiItem> KpiItems { get; set; }
    public DbSet<KpiReview> KpiReviews { get; set; }
    public DbSet<KpiItemReview> KpiItemReviews { get; set; }
    public DbSet<KpiPlanHistory> KpiPlanHistories { get; set; }

    // ==========================================
    // Module 5: Payslips
    // ==========================================
    public DbSet<Payslip> Payslips { get; set; }
    public DbSet<PayslipVersion> PayslipVersions { get; set; }
    public DbSet<PayslipVersionAllowanceItem> PayslipVersionAllowanceItems { get; set; }
    public DbSet<PayslipVersionDeductionItem> PayslipVersionDeductionItems { get; set; }

    // ==========================================
    // Module 6: Internal Opportunities
    // ==========================================
    public DbSet<InternalOpportunity> InternalOpportunities { get; set; }
    public DbSet<VacancyApplication> VacancyApplications { get; set; }
    public DbSet<OpportunityAllowedDepartment> OpportunityAllowedDepartments { get; set; }
    public DbSet<OpportunityAllowedGrade> OpportunityAllowedGrades { get; set; }

    // ==========================================
    // Module 7: Notifications & Queue Workers
    // ==========================================
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<EmailQueue> EmailQueues { get; set; }
    public DbSet<EmailQueueAttempt> EmailQueueAttempts { get; set; }
    public DbSet<EmailReminderLog> EmailReminderLogs { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ==========================================
        // 1. Identity & Profiles (AUTH-01, AUTH-02, EMP-01)
        // ==========================================
        modelBuilder.Entity<Department>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.Code).IsUnique();
            b.Property(x => x.Code).HasMaxLength(50).IsRequired();
            b.Property(x => x.Name).HasMaxLength(150).IsRequired();
        });

        modelBuilder.Entity<Grade>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.Code).IsUnique();
            b.Property(x => x.Code).HasMaxLength(50).IsRequired();
            b.Property(x => x.Name).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Role>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.Name).IsUnique();
            b.Property(x => x.Name).HasMaxLength(50).IsRequired();
        });

        modelBuilder.Entity<Employee>(b =>
        {
         b.HasKey(x => x.Id);

         b.HasIndex(x => x.EmployeeNumber).IsUnique();
         b.HasIndex(x => x.Email).IsUnique();

         b.Property(x => x.EmployeeNumber)
          .HasMaxLength(50)
          .IsRequired();

         b.Property(x => x.FullName)
          .HasMaxLength(150)
          .IsRequired();

         b.Property(x => x.Email)
          .HasMaxLength(150)
          .IsRequired();

         b.Property(x => x.PhoneNumber)
          .HasMaxLength(30);

         b.Property(x => x.AccountSetupToken)
          .HasMaxLength(256);

         b.Property(x => x.PasswordResetToken)
          .HasMaxLength(256);

         // Department (1-to-many)
         b.HasOne(x => x.Department)
          .WithMany(d => d.Employees)
          .HasForeignKey(x => x.DepartmentId)
          .OnDelete(DeleteBehavior.Restrict);

         // Grade (1-to-many)
         b.HasOne(x => x.Grade)
          .WithMany(g => g.Employees)
          .HasForeignKey(x => x.GradeId)
          .OnDelete(DeleteBehavior.Restrict);

         // Self-referencing manager hierarchy (1-to-many)
         b.HasOne(x => x.ReportingManager)
          .WithMany(m => m.DirectReports)
          .HasForeignKey(x => x.ReportingManagerId)
          .IsRequired(false)
          .OnDelete(DeleteBehavior.Restrict);

         // 1-to-1 with EmployeeAccount
         b.HasOne(x => x.Account)
          .WithOne(a => a.Employee)
          .HasForeignKey<EmployeeAccount>(a => a.EmployeeId)
          .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<EmployeeRole>(b =>
        {
         b.HasKey(x => x.Id);
         b.HasIndex(x => new { x.EmployeeId, x.RoleId }).IsUnique();

         b.HasOne(x => x.Employee)
          .WithMany(e => e.EmployeeRoles)
          .HasForeignKey(x => x.EmployeeId)
          .OnDelete(DeleteBehavior.Cascade);

         b.HasOne(x => x.Role)
          .WithMany(r => r.EmployeeRoles)
          .HasForeignKey(x => x.RoleId)
          .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<AccountSecurityToken>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.TokenHash);
            b.Property(x => x.TokenHash).HasMaxLength(256).IsRequired();

            b.HasOne(x => x.Employee)
             .WithMany(e => e.SecurityTokens)
             .HasForeignKey(x => x.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // ==========================================
        // 2. Training & Estacode (TRN-01 - TRN-07)
        // ==========================================
        modelBuilder.Entity<EstacodeRate>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => new { x.CountryCode, x.GradeId }).IsUnique();
            b.Property(x => x.CountryCode).HasMaxLength(10).IsRequired();
            b.Property(x => x.DailyRateUsd).HasPrecision(18, 2);

            b.HasOne(x => x.Grade)
             .WithMany(g => g.EstacodeRates)
             .HasForeignKey(x => x.GradeId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TrainingRequest>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Title).HasMaxLength(200).IsRequired();
            b.Property(x => x.Provider).HasMaxLength(150).IsRequired();
            b.Property(x => x.CountryCode).HasMaxLength(10).IsRequired();
            b.Property(x => x.City).HasMaxLength(100).IsRequired();
            b.Property(x => x.CourseFee).HasPrecision(18, 2);
            b.Property(x => x.CourseFeeCurrency).HasMaxLength(10).IsRequired();
            b.Property(x => x.FlightEstimate).HasPrecision(18, 2);
            b.Property(x => x.FlightCurrency).HasMaxLength(10).IsRequired();

            b.HasOne(x => x.Employee)
             .WithMany(e => e.TrainingRequests)
             .HasForeignKey(x => x.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.AssignedReviewer)
             .WithMany(e => e.AssignedTrainingReviews)
             .HasForeignKey(x => x.AssignedReviewerId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TrainingAllowance>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => new { x.TrainingRequestId, x.Version }).IsUnique();
            b.Property(x => x.GradeNameSnapshot).HasMaxLength(100).IsRequired();
            b.Property(x => x.DailyRate).HasPrecision(18, 2);
            b.Property(x => x.Amount).HasPrecision(18, 2);
            b.Property(x => x.Currency).HasMaxLength(10).IsRequired();

            b.HasOne(x => x.TrainingRequest)
             .WithMany(t => t.Allowances)
             .HasForeignKey(x => x.TrainingRequestId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.CreatedByUser)
             .WithMany()
             .HasForeignKey(x => x.CreatedByUserId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TrainingApprovalHistory>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.RoleAtAction).HasMaxLength(50).IsRequired();

            b.HasOne(x => x.TrainingRequest)
             .WithMany(t => t.ApprovalHistories)
             .HasForeignKey(x => x.TrainingRequestId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.Reviewer)
             .WithMany()
             .HasForeignKey(x => x.ReviewerId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TrainingEvidence>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.FileName).HasMaxLength(255).IsRequired();
            b.Property(x => x.FilePath).HasMaxLength(500).IsRequired();
            b.Property(x => x.ContentType).HasMaxLength(100).IsRequired();

            b.HasOne(x => x.TrainingRequest)
             .WithMany(t => t.EvidenceFiles)
             .HasForeignKey(x => x.TrainingRequestId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.UploadedBy)
             .WithMany()
             .HasForeignKey(x => x.UploadedById)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TrainingRequestAssignmentHistory>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Reason).IsRequired();

            b.HasOne(x => x.TrainingRequest)
             .WithMany(t => t.AssignmentHistories)
             .HasForeignKey(x => x.TrainingRequestId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.PreviousManager)
             .WithMany()
             .HasForeignKey(x => x.PreviousManagerId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.NewManager)
             .WithMany()
             .HasForeignKey(x => x.NewManagerId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.ReassignedBy)
             .WithMany()
             .HasForeignKey(x => x.ReassignedById)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<TrainingRequestComment>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Comment).IsRequired();

            b.HasOne(x => x.TrainingRequest)
             .WithMany(t => t.Comments)
             .HasForeignKey(x => x.TrainingRequestId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.Employee)
             .WithMany()
             .HasForeignKey(x => x.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // ==========================================
        // 3. Learning Management System (LMS-01 - LMS-03)
        // ==========================================
        modelBuilder.Entity<Course>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Title).HasMaxLength(200).IsRequired();
            b.Property(x => x.Category).HasMaxLength(100).IsRequired();

            b.HasOne(x => x.CreatedBy)
             .WithMany()
             .HasForeignKey(x => x.CreatedById)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.Assessment)
             .WithOne(a => a.Course)
             .HasForeignKey<CourseAssessment>(a => a.CourseId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CourseLesson>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Title).HasMaxLength(200).IsRequired();

            b.HasOne(x => x.Course)
             .WithMany(c => c.Lessons)
             .HasForeignKey(x => x.CourseId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CourseAssessment>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Title).HasMaxLength(200).IsRequired();
        });

        modelBuilder.Entity<AssessmentQuestion>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.QuestionText).IsRequired();

            b.HasOne(x => x.CourseAssessment)
             .WithMany(a => a.Questions)
             .HasForeignKey(x => x.CourseAssessmentId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AssessmentOption>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.OptionText).IsRequired();

            b.HasOne(x => x.AssessmentQuestion)
             .WithMany(q => q.Options)
             .HasForeignKey(x => x.AssessmentQuestionId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<CourseAssignment>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => new { x.CourseId, x.EmployeeId }).IsUnique();
            b.Property(x => x.BestScore).HasPrecision(5, 2);

            b.HasOne(x => x.Course)
             .WithMany(c => c.Assignments)
             .HasForeignKey(x => x.CourseId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.Employee)
             .WithMany(e => e.CourseAssignments)
             .HasForeignKey(x => x.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<LessonProgress>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => new { x.CourseAssignmentId, x.CourseLessonId }).IsUnique();

            b.HasOne(x => x.CourseAssignment)
             .WithMany(a => a.LessonProgresses)
             .HasForeignKey(x => x.CourseAssignmentId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.CourseLesson)
             .WithMany(l => l.LessonProgresses)
             .HasForeignKey(x => x.CourseLessonId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AssessmentAttempt>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Score).HasPrecision(5, 2);

            b.HasOne(x => x.CourseAssignment)
             .WithMany(a => a.Attempts)
             .HasForeignKey(x => x.CourseAssignmentId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AssessmentAnswer>(b =>
        {
            b.HasKey(x => x.Id);

            b.HasOne(x => x.AssessmentAttempt)
             .WithMany(a => a.Answers)
             .HasForeignKey(x => x.AssessmentAttemptId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.AssessmentQuestion)
             .WithMany()
             .HasForeignKey(x => x.AssessmentQuestionId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.SelectedOption)
             .WithMany()
             .HasForeignKey(x => x.SelectedOptionId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AssessmentResetHistory>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Reason).IsRequired();

            b.HasOne(x => x.CourseAssignment)
             .WithMany(a => a.ResetHistories)
             .HasForeignKey(x => x.CourseAssignmentId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.ResetBy)
             .WithMany()
             .HasForeignKey(x => x.ResetById)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // ==========================================
        // 4. KPI Management (KPI-01 - KPI-03)
        // ==========================================
        modelBuilder.Entity<KpiPlan>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => new { x.EmployeeId, x.ReviewPeriod }).IsUnique();
            b.Property(x => x.ReviewPeriod).HasMaxLength(50).IsRequired();
            b.Property(x => x.Title).HasMaxLength(200).IsRequired();
            b.Property(x => x.OverallScore).HasPrecision(5, 2);

            b.HasOne(x => x.Employee)
             .WithMany(e => e.KpiPlans)
             .HasForeignKey(x => x.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.AssignedReviewer)
             .WithMany(e => e.AssignedKpiReviews)
             .HasForeignKey(x => x.AssignedReviewerId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.CreatedBy)
             .WithMany()
             .HasForeignKey(x => x.CreatedById)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<KpiItem>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Title).HasMaxLength(200).IsRequired();
            b.Property(x => x.Target).HasPrecision(18, 2);
            b.Property(x => x.ActualValue).HasPrecision(18, 2);
            b.Property(x => x.Weight).HasPrecision(5, 2);
            b.Property(x => x.AchievementPercentage).HasPrecision(5, 2);
            b.Property(x => x.WeightedScore).HasPrecision(5, 2);
            b.Property(x => x.Unit).HasMaxLength(50).IsRequired();

            b.HasOne(x => x.KpiPlan)
             .WithMany(p => p.Items)
             .HasForeignKey(x => x.KpiPlanId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<KpiReview>(b =>
        {
            b.HasKey(x => x.Id);

            b.HasOne(x => x.KpiPlan)
             .WithMany(p => p.Reviews)
             .HasForeignKey(x => x.KpiPlanId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.Reviewer)
             .WithMany()
             .HasForeignKey(x => x.ReviewerId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<KpiItemReview>(b =>
        {
            b.HasKey(x => x.Id);

            b.HasOne(x => x.KpiItem)
             .WithMany(i => i.ItemReviews)
             .HasForeignKey(x => x.KpiItemId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.Reviewer)
             .WithMany()
             .HasForeignKey(x => x.ReviewerId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<KpiPlanHistory>(b =>
        {
            b.HasKey(x => x.Id);

            b.HasOne(x => x.KpiPlan)
             .WithMany(p => p.Histories)
             .HasForeignKey(x => x.KpiPlanId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.ActionBy)
             .WithMany()
             .HasForeignKey(x => x.ActionById)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // ==========================================
        // 5. Payslips (PAY-01, PAY-02)
        // ==========================================
        modelBuilder.Entity<Payslip>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => new { x.EmployeeId, x.Month, x.Year }).IsUnique();

            b.HasOne(x => x.Employee)
             .WithMany(e => e.Payslips)
             .HasForeignKey(x => x.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PayslipVersion>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => new { x.PayslipId, x.VersionNumber }).IsUnique();
            b.Property(x => x.BasicSalary).HasPrecision(18, 2);
            b.Property(x => x.GrossPay).HasPrecision(18, 2);
            b.Property(x => x.TotalDeductions).HasPrecision(18, 2);
            b.Property(x => x.NetPay).HasPrecision(18, 2);
            b.Property(x => x.Currency).HasMaxLength(10).IsRequired();

            b.HasOne(x => x.Payslip)
             .WithMany(p => p.Versions)
             .HasForeignKey(x => x.PayslipId)
             .OnDelete(DeleteBehavior.Restrict);

            b.HasOne(x => x.CreatedBy)
             .WithMany()
             .HasForeignKey(x => x.CreatedById)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PayslipVersionAllowanceItem>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(150).IsRequired();
            b.Property(x => x.Amount).HasPrecision(18, 2);

            b.HasOne(x => x.PayslipVersion)
             .WithMany(v => v.Allowances)
             .HasForeignKey(x => x.PayslipVersionId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<PayslipVersionDeductionItem>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(150).IsRequired();
            b.Property(x => x.Amount).HasPrecision(18, 2);

            b.HasOne(x => x.PayslipVersion)
             .WithMany(v => v.Deductions)
             .HasForeignKey(x => x.PayslipVersionId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        // ==========================================
        // 6. Internal Opportunities (VAC-01, VAC-02)
        // ==========================================
     

       modelBuilder.Entity<InternalOpportunity>(b =>
       {
        b.HasKey(x => x.Id);
        
            b.HasIndex(x => x.ReferenceNumber).IsUnique();
        
            b.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(200);
        
            b.Property(x => x.ReferenceNumber)
                .IsRequired()
                .HasMaxLength(50);
        
            b.Property(x => x.Description)
                .IsRequired();
        
            b.Property(x => x.Requirements)
                .IsRequired();
        
            b.Property(x => x.EligibilityText)
                .HasMaxLength(1000);
        
            b.Property(x => x.Location)
                .HasMaxLength(150);
        
            b.Property(x => x.JobType)
                .HasMaxLength(50);
        
            b.Property(x => x.AllowedGrades)
                .HasMaxLength(50);
        
            b.Property(x => x.Status)
                .HasConversion<string>()
                .HasMaxLength(30)
                .IsRequired();
        
            // Foreign Key to Department
            b.HasOne(x => x.Department)
                .WithMany()
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        
            // Foreign Key to Employee (PostedBy)
            b.HasOne(x => x.PostedBy)
                .WithMany()
                .HasForeignKey(x => x.PostedById)
                .OnDelete(DeleteBehavior.Restrict);
        });
       


       modelBuilder.Entity<OpportunityAllowedDepartment>(b =>
{
    b.HasKey(x => x.Id);

    b.HasIndex(x => new { x.InternalOpportunityId, x.DepartmentId }).IsUnique();

    b.HasOne(x => x.InternalOpportunity)
        .WithMany(o => o.AllowedDepartments)
        .HasForeignKey(x => x.InternalOpportunityId)
        .OnDelete(DeleteBehavior.Cascade);

    b.HasOne(x => x.Department)
        .WithMany()
        .HasForeignKey(x => x.DepartmentId)
        .OnDelete(DeleteBehavior.Restrict);
});

modelBuilder.Entity<OpportunityAllowedGrade>(b =>
{
    b.HasKey(x => x.Id);

    b.HasIndex(x => new { x.InternalOpportunityId, x.GradeId }).IsUnique();

    b.HasOne(x => x.InternalOpportunity)
        .WithMany(o => o.AllowedGrades)
        .HasForeignKey(x => x.InternalOpportunityId)
        .OnDelete(DeleteBehavior.Cascade);

    b.HasOne(x => x.Grade)
        .WithMany()
        .HasForeignKey(x => x.GradeId)
        .OnDelete(DeleteBehavior.Restrict);
});

modelBuilder.Entity<VacancyApplication>(b =>
{
    b.HasKey(x => x.Id);

    // One application per employee per opportunity
    b.HasIndex(x => new { x.InternalOpportunityId, x.ApplicantEmployeeId })
        .IsUnique();

    b.Property(x => x.CoverLetterOrPitch)
        .IsRequired()
        .HasMaxLength(2000);

    b.Property(x => x.Status)
        .IsRequired()
        .HasMaxLength(50);

    b.Property(x => x.ResumeFilePath)
        .HasMaxLength(500);

    b.Property(x => x.ReviewerFeedback)
        .HasMaxLength(1000);

    b.HasOne(x => x.InternalOpportunity)
        .WithMany(o => o.Applications)
        .HasForeignKey(x => x.InternalOpportunityId)
        .OnDelete(DeleteBehavior.Restrict);

    b.HasOne(x => x.Applicant)
        .WithMany(e => e.VacancyApplications)
        .HasForeignKey(x => x.ApplicantEmployeeId)
        .OnDelete(DeleteBehavior.Restrict);

    b.HasOne(x => x.ReviewedBy)
        .WithMany()
        .HasForeignKey(x => x.ReviewedById)
        .IsRequired(false)
        .OnDelete(DeleteBehavior.Restrict);
});
      

        // ==========================================
        // 7. Notifications & Queue Workers (NOT-01, NOT-02)
        // ==========================================
        modelBuilder.Entity<Notification>(b =>
        {
         b.HasKey(x => x.Id);

         b.Property(x => x.Title)
          .IsRequired()
          .HasMaxLength(150);

         b.Property(x => x.Message)
          .IsRequired()
          .HasMaxLength(1000);

         b.Property(x => x.DeduplicationKey)
          .HasMaxLength(200);

         // Filter out NULLs so multiple notifications can have no key
         b.HasIndex(x => x.DeduplicationKey)
          .IsUnique();

         b.HasOne(x => x.Employee)
          .WithMany(e => e.Notifications)
          .HasForeignKey(x => x.EmployeeId)
          .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<EmailQueue>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.Status);
            b.HasIndex(x => x.NextAttemptTime);
            b.HasIndex(x => x.DeduplicationKey);

            b.Property(x => x.RecipientEmail).HasMaxLength(150).IsRequired();
            b.Property(x => x.Subject).HasMaxLength(250).IsRequired();
            b.Property(x => x.Body).IsRequired();
            b.Property(x => x.DeduplicationKey).HasMaxLength(200);
        });

        modelBuilder.Entity<EmailQueueAttempt>(b =>
        {
            b.HasKey(x => x.Id);

            b.HasOne(x => x.EmailQueue)
             .WithMany(q => q.Attempts)
             .HasForeignKey(x => x.EmailQueueId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<EmailReminderLog>(b =>
        {
            b.HasKey(x => x.Id);
            b.HasIndex(x => x.DeduplicationKey).IsUnique();
            b.Property(x => x.DeduplicationKey).HasMaxLength(200).IsRequired();

            b.HasOne(x => x.Employee)
             .WithMany()
             .HasForeignKey(x => x.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<AuditLog>(b =>
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.EntityName).HasMaxLength(100).IsRequired();
            b.Property(x => x.EntityId).HasMaxLength(100).IsRequired();

            b.HasOne(x => x.User)
             .WithMany()
             .HasForeignKey(x => x.UserId)
             .OnDelete(DeleteBehavior.Restrict);
        });
    }
}