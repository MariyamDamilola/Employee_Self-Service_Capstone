Employee Self-Service Backend API
A clean, modular RESTful Web API built with ASP.NET Core and C#, providing an enterprise workforce platform for managing employee records, professional development, performance assessments, and compensation history.

Key Modules
Identity & Profiles (EMP / AUTH): Token-based account setup, JWT bearer authentication, role-based authorization (Admin, Manager, Employee), and reporting line visibility.

Training & Estacode (TRN): External training workflow, multi-tier approvals (Line Manager/HR), automated estacode allowance calculation, and completion certificate uploads.

Corporate LMS (LMS): Internal course catalog, self-paced enrollments, assessment tracking, and deadline enforcement.

Performance & KPIs (KPI): Weighted appraisal goal-setting, self-scoring, managerial evaluation, and cycle lock-in.

Payroll & Payslips (PAY): Monthly salary breakdown viewing with on-demand official PDF generation via QuestPDF.

Internal Vacancies (VAC): Job board for open internal opportunities and expression of interest (EOI) tracking.

Notification Service (NOT): In-app notification center paired with transactional HTML email dispatch.
