namespace Employee_Self_Service_Capstone.Helper;


public static class MailUtils
{
    private const string BrandColor = "#1E40AF";      // Deep corporate blue
    private const string BrandColorDark = "#0F172A";  // Dark slate for title bar
    private const string BrandName = "Enterprise ESS";
    private const string PortalTagline = "Workplace &middot; Mobility &middot; Self-Service";
    private const string SupportEmail = "hr-support@company.com";

    // ============================================================
    // 0. CORE EMAIL SHELL BUILDER
    // ============================================================

    public static string GetEmailWrapper(string preheader, string title, string content)
    {
        var year = DateTime.UtcNow.Year;

        return $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='utf-8' />
    <meta name='viewport' content='width=device-width, initial-scale=1.0' />
    <title>{title}</title>
</head>
<body style='margin:0; padding:0; background-color:#f8fafc; font-family:Arial, Helvetica, sans-serif;'>

    <!-- Hidden Preheader -->
    <div style='display:none; max-height:0; overflow:hidden; opacity:0; color:transparent;'>
        {preheader}
    </div>

    <table role='presentation' width='100%' cellpadding='0' cellspacing='0' style='background-color:#f8fafc; padding:35px 0;'>
        <tr>
            <td align='center'>
                <table role='presentation' width='600' cellpadding='0' cellspacing='0'
                       style='width:600px; max-width:600px; background-color:#ffffff; border-radius:10px;
                              overflow:hidden; box-shadow:0 4px 14px rgba(0,0,0,0.06);'>

                    <!-- Top Accent -->
                    <tr>
                        <td style='background-color:{BrandColor}; height:6px; line-height:6px; font-size:0;'>&nbsp;</td>
                    </tr>

                    <!-- Header -->
                    <tr>
                        <td style='padding:28px 40px 22px; text-align:center; border-bottom:1px solid #f1f5f9;'>
                            <div style='font-size:26px; font-weight:800; color:{BrandColor}; letter-spacing:0.5px;'>
                                {BrandName}
                            </div>
                            <div style='font-size:11px; letter-spacing:1.5px; text-transform:uppercase; color:#94a3b8; margin-top:5px;'>
                                {PortalTagline}
                            </div>
                        </td>
                    </tr>

                    <!-- Title Banner -->
                    <tr>
                        <td style='background-color:{BrandColorDark}; padding:16px 40px;'>
                            <span style='color:#ffffff; font-size:15px; font-weight:600; letter-spacing:0.3px;'>
                                {title}
                            </span>
                        </td>
                    </tr>

                    <!-- Body Content -->
                    <tr>
                        <td style='padding:36px 40px; color:#334155; font-size:15px; line-height:1.65;'>
                            {content}
                        </td>
                    </tr>

                    <!-- Support Note -->
                    <tr>
                        <td style='padding:0 40px 24px; text-align:center;'>
                            <div style='border-top:1px solid #f1f5f9; padding-top:20px; font-size:13px; color:#64748b;'>
                                Need assistance? Reach out to Human Resources at 
                                <a href='mailto:{SupportEmail}' style='color:{BrandColor}; text-decoration:none; font-weight:600;'>
                                    {SupportEmail}
                                </a>
                            </div>
                        </td>
                    </tr>

                    <!-- Footer -->
                    <tr>
                        <td style='background-color:#f8fafc; padding:20px 40px; text-align:center; border-top:1px solid #f1f5f9;'>
                            <div style='font-size:12px; color:#94a3b8; line-height:1.5;'>
                                &copy; {year} {BrandName}. Internal Employee Portal Notification.<br/>
                                Please do not reply directly to this automated email.
                            </div>
                        </td>
                    </tr>

                    <!-- Bottom Accent -->
                    <tr>
                        <td style='background-color:{BrandColor}; height:5px; line-height:5px; font-size:0;'>&nbsp;</td>
                    </tr>

                </table>
            </td>
        </tr>
    </table>
</body>
</html>";
    }

    private static string DetailRow(string label, string value, bool shaded)
    {
        var bg = shaded ? "#f8fafc" : "#ffffff";
        return $@"
<tr>
    <td style='padding:11px 16px; background-color:{bg}; border-bottom:1px solid #e2e8f0; font-size:13px; color:#64748b; font-weight:600; width:40%;'>
        {label}
    </td>
    <td style='padding:11px 16px; background-color:{bg}; border-bottom:1px solid #e2e8f0; font-size:14px; color:#1e293b;'>
        {value}
    </td>
</tr>";
    }

    private static string DetailsTable(string rows)
    {
        return $@"
<table role='presentation' width='100%' cellpadding='0' cellspacing='0'
       style='margin:20px 0 24px; border:1px solid #e2e8f0; border-radius:8px; overflow:hidden;'>
    {rows}
</table>";
    }

    private static string ActionButtonBlock(string buttonText, string actionUrl)
    {
        return $@"
<table role='presentation' width='100%' cellpadding='0' cellspacing='0' style='margin:25px 0;'>
    <tr>
        <td align='center'>
            <a href='{actionUrl}' target='_blank'
               style='background-color:{BrandColor}; color:#ffffff; padding:14px 28px; border-radius:6px;
                      text-decoration:none; font-size:15px; font-weight:700; display:inline-block;'>
                {buttonText}
            </a>
        </td>
    </tr>
</table>";
    }

    // ============================================================
    // 1. AUTHENTICATION & IDENTITY (AUTH-01, AUTH-02)
    // ============================================================

    public static string GetAccountSetupEmailHtml(string fullName, string employeeNumber, string setupUrl)
    {
        var title = "Account Setup Required";
        var preheader = $"Set up your password for Employee Self-Service profile {employeeNumber}.";

        var details = string.Concat(
            DetailRow("Employee Name", fullName, false),
            DetailRow("Staff Number", employeeNumber, true),
            DetailRow("Account State", "<strong style='color:#d97706;'>PENDING ACTIVATION</strong>", false),
            DetailRow("Link Validity", "24 Hours", true)
        );

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#0f172a; margin-bottom:10px;'>
    Welcome to the Team, {fullName}!
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Your corporate Employee Self-Service account has been created. Please complete your registration by setting a secure account password.
</p>

{DetailsTable(details)}

{ActionButtonBlock("Activate & Set Password", setupUrl)}

<p style='font-size:13px; color:#64748b;'>
    If you did not expect this invitation or believe it was sent in error, please alert your HR representative immediately.
</p>";

        return GetEmailWrapper(preheader, title, content);
    }

    public static string GetPasswordResetEmailHtml(string fullName, string resetUrl)
    {
        var title = "Password Reset Request";
        var preheader = "Instructions to reset your Employee Self-Service password.";

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#0f172a; margin-bottom:10px;'>
    Password Reset Request
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Hello {fullName}, we received a request to reset your login credentials. Click the button below to specify your new password:
</p>

{ActionButtonBlock("Reset My Password", resetUrl)}

<div style='background-color:#fffbeb; border-left:4px solid #f59e0b; padding:12px 16px; margin:20px 0; color:#92400e; font-size:13px;'>
    This link expires in <strong>1 hour</strong>. If you did not initiate this request, no action is needed; your existing password remains safe.
</div>";

        return GetEmailWrapper(preheader, title, content);
    }

    public static string GetPasswordChangedEmailHtml(string fullName, string employeeNumber)
    {
        var title = "Security Alert · Password Updated";
        var preheader = "Your account password was updated successfully.";

        var details = string.Concat(
            DetailRow("Staff Number", employeeNumber, false),
            DetailRow("Action", "Password Changed", true),
            DetailRow("Updated At", $"{DateTime.UtcNow:f} UTC", false)
        );

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#0f172a; margin-bottom:10px;'>
    Password Successfully Changed
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Hello {fullName}, this is a confirmation that your Employee Self-Service password was changed successfully.
</p>

{DetailsTable(details)}

<div style='background-color:#fef2f2; border-left:4px solid #ef4444; padding:12px 16px; color:#991b1b; font-size:13px;'>
    If you did not perform this update, please contact the IT Security helpdesk immediately.
</div>";

        return GetEmailWrapper(preheader, title, content);
    }

    // ============================================================
    // 2. TRAINING & ESTACODE (TRN-01 to TRN-07)
    // ============================================================

    public static string GetTrainingPendingReviewEmailHtml(
        string reviewerName,
        string applicantName,
        string courseTitle,
        int requestId,
        string reviewUrl)
    {
        var title = "Pending Approval · Training & Estacode";
        var preheader = $"{applicantName} submitted a training request requiring your review.";

        var details = string.Concat(
            DetailRow("Request ID", $"#{requestId}", false),
            DetailRow("Employee", applicantName, true),
            DetailRow("Course Title", courseTitle, false),
            DetailRow("Submission Date", $"{DateTime.UtcNow:d} UTC", true)
        );

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#0f172a; margin-bottom:10px;'>
    New Training Request for Review
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Hello {reviewerName}, an external training application has been submitted and assigned to you for line manager approval.
</p>

{DetailsTable(details)}

{ActionButtonBlock("Review Training Request", reviewUrl)}";

        return GetEmailWrapper(preheader, title, content);
    }

    public static string GetTrainingStatusChangedEmailHtml(
        string employeeName,
        string courseTitle,
        int requestId,
        string status,
        string? reviewerComments)
    {
        var title = $"Training Request #{requestId} · {status}";
        var preheader = $"Status update on your training request: {status}.";

        var statusColor = status.ToUpper() switch
        {
            "APPROVED" => "#16a34a",
            "REJECTED" => "#dc2626",
            "RETURNEDTOHR" => "#d97706",
            _ => "#2563eb"
        };

        var details = string.Concat(
            DetailRow("Request ID", $"#{requestId}", false),
            DetailRow("Course Title", courseTitle, true),
            DetailRow("New Status", $"<strong style='color:{statusColor};'>{status}</strong>", false),
            DetailRow("Decision Date", $"{DateTime.UtcNow:f} UTC", true)
        );

        var feedbackBlock = string.IsNullOrWhiteSpace(reviewerComments)
            ? string.Empty
            : $@"
<div style='background-color:#f8fafc; border:1px solid #e2e8f0; border-radius:6px; padding:14px; margin-top:16px;'>
    <div style='font-size:12px; font-weight:700; color:#64748b; text-transform:uppercase; margin-bottom:4px;'>Reviewer Feedback</div>
    <div style='font-size:14px; color:#1e293b; font-style:italic;'>""{reviewerComments}""</div>
</div>";

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#0f172a; margin-bottom:10px;'>
    Training Application Update
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Hello {employeeName}, your training application status has been updated.
</p>

{DetailsTable(details)}
{feedbackBlock}";

        return GetEmailWrapper(preheader, title, content);
    }

    // ============================================================
    // 3. LEARNING MANAGEMENT SYSTEM (LMS-02, LMS-03)
    // ============================================================

    public static string GetCourseAssignedEmailHtml(
        string employeeName,
        string courseTitle,
        DateTime dueDateUtc,
        string courseUrl)
    {
        var title = "New Course Enrolment";
        var preheader = $"You have been assigned to course '{courseTitle}'.";

        var details = string.Concat(
            DetailRow("Course Title", courseTitle, false),
            DetailRow("Due Date", $"{dueDateUtc:yyyy-MM-dd HH:mm} UTC", true),
            DetailRow("Assigned Date", $"{DateTime.UtcNow:d} UTC", false)
        );

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#0f172a; margin-bottom:10px;'>
    New Learning Assignment
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Hello {employeeName}, a new course has been assigned to your profile. Please review the lessons and pass the final quiz before the designated deadline.
</p>

{DetailsTable(details)}

{ActionButtonBlock("Start Course Now", courseUrl)}";

        return GetEmailWrapper(preheader, title, content);
    }

    public static string GetCourseOverdueReminderEmailHtml(
        string employeeName,
        string courseTitle,
        DateTime dueDateUtc,
        string courseUrl)
    {
        var title = "Urgent · Course Assignment Overdue";
        var preheader = $"Reminder: Assigned course '{courseTitle}' is now overdue.";

        var details = string.Concat(
            DetailRow("Course Title", courseTitle, false),
            DetailRow("Original Due Date", $"{dueDateUtc:yyyy-MM-dd} UTC", true),
            DetailRow("Current Status", "<strong style='color:#dc2626;'>OVERDUE</strong>", false)
        );

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#b91c1c; margin-bottom:10px;'>
    Action Required: Course Overdue
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Hello {employeeName}, the deadline for completing your required coursework has passed. Please prioritize completing this course immediately.
</p>

{DetailsTable(details)}

{ActionButtonBlock("Complete Coursework", courseUrl)}";

        return GetEmailWrapper(preheader, title, content);
    }

    // ============================================================
    // 4. PERFORMANCE & KPIS (KPI-01 to KPI-03)
    // ============================================================

    public static string GetKpiPlanFinalizedEmailHtml(
        string employeeName,
        string planTitle,
        string reviewPeriod,
        decimal overallScore)
    {
        var title = "KPI Performance Plan Finalized";
        var preheader = $"Your KPI evaluation for {reviewPeriod} has been scored and approved.";

        var details = string.Concat(
            DetailRow("Review Period", reviewPeriod, false),
            DetailRow("Plan Title", planTitle, true),
            DetailRow("Overall Score", $"<strong style='font-size:16px; color:#16a34a;'>{overallScore:F2}%</strong>", false),
            DetailRow("Status", "<strong style='color:#16a34a;'>FINALIZED</strong>", true)
        );

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#0f172a; margin-bottom:10px;'>
    KPI Appraisal Complete
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Hello {employeeName}, your performance plan review has been concluded and locked by your line manager.
</p>

{DetailsTable(details)}

<p style='font-size:14px; color:#64748b;'>
    You can log into the portal to review specific item scores, weights, and reviewer feedback notes.
</p>";

        return GetEmailWrapper(preheader, title, content);
    }

    // ============================================================
    // 5. PAYSLIPS (PAY-01, PAY-02)
    // ============================================================

    public static string GetPayslipPublishedEmailHtml(
        string employeeName,
        int month,
        int year,
        decimal netPay,
        string currency,
        string downloadUrl)
    {
        var monthName = new DateTime(year, month, 1).ToString("MMMM");
        var title = $"Payslip Ready · {monthName} {year}";
        var preheader = $"Your payslip for {monthName} {year} is ready for download.";

        var details = string.Concat(
            DetailRow("Payroll Month", $"{monthName} {year}", false),
            DetailRow("Currency", currency, true),
            DetailRow("Net Pay", $"<strong style='color:#0f172a; font-size:16px;'>{currency} {netPay:N2}</strong>", false),
            DetailRow("Published On", $"{DateTime.UtcNow:d} UTC", true)
        );

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#0f172a; margin-bottom:10px;'>
    Monthly Payslip Available
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Hello {employeeName}, your payroll breakdown for <strong>{monthName} {year}</strong> has been generated and approved.
</p>

{DetailsTable(details)}

{ActionButtonBlock("View & Download Payslip", downloadUrl)}";

        return GetEmailWrapper(preheader, title, content);
    }

    // ============================================================
    // 6. INTERNAL OPPORTUNITIES & VACANCIES (VAC-01, VAC-02)
    // ============================================================

    public static string GetOpportunityPostedEmailHtml(
        string employeeName,
        string vacancyTitle,
        string department,
        DateTime closingDateUtc,
        string detailsUrl)
    {
        var title = $"New Opportunity · {vacancyTitle}";
        var preheader = $"A new internal opening is available in {department}.";

        var details = string.Concat(
            DetailRow("Position Title", vacancyTitle, false),
            DetailRow("Department", department, true),
            DetailRow("Closing Deadline", $"{closingDateUtc:yyyy-MM-dd HH:mm} UTC", false)
        );

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#0f172a; margin-bottom:10px;'>
    Internal Career Opportunity
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Hello {employeeName}, a new internal vacancy matching your department or grade eligibility has been posted.
</p>

{DetailsTable(details)}

{ActionButtonBlock("View Position & Apply", detailsUrl)}";

        return GetEmailWrapper(preheader, title, content);
    }

    public static string GetVacancyApplicationStatusEmailHtml(
        string candidateName,
        string vacancyTitle,
        string status,
        string? feedbackNotes)
    {
        var title = $"Application Update · {vacancyTitle}";
        var preheader = $"Update on your internal application for {vacancyTitle}.";

        var statusColor = status.ToUpper() switch
        {
            "SHORTLISTED" => "#2563eb",
            "SELECTED" => "#16a34a",
            "REJECTED" => "#dc2626",
            _ => "#64748b"
        };

        var details = string.Concat(
            DetailRow("Vacancy Title", vacancyTitle, false),
            DetailRow("Current Status", $"<strong style='color:{statusColor};'>{status}</strong>", true),
            DetailRow("Last Updated", $"{DateTime.UtcNow:f} UTC", false)
        );

        var feedbackBlock = string.IsNullOrWhiteSpace(feedbackNotes)
            ? string.Empty
            : $@"
<div style='background-color:#f8fafc; border:1px solid #e2e8f0; border-radius:6px; padding:14px; margin-top:16px;'>
    <div style='font-size:12px; font-weight:700; color:#64748b; text-transform:uppercase; margin-bottom:4px;'>Committee Notes</div>
    <div style='font-size:14px; color:#1e293b; font-style:italic;'>""{feedbackNotes}""</div>
</div>";

        var content = $@"
<div style='font-size:20px; font-weight:700; color:#0f172a; margin-bottom:10px;'>
    Internal Application Status
</div>
<p style='color:#475569; margin:0 0 16px;'>
    Hello {candidateName}, your application for <strong>{vacancyTitle}</strong> has been updated.
</p>

{DetailsTable(details)}
{feedbackBlock}";

        return GetEmailWrapper(preheader, title, content);
    }
}