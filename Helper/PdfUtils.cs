using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Employee_Self_Service_Capstone.Helper;

public class PdfUtils
{
  private const string BrandColor = "#1E3A8A";
    private const string BorderColor = "#E5E7EB";

    public static byte[] GeneratePayslipPdf(
        string employeeName,
        string employeeNumber,
        string payrollPeriod,
        decimal basicSalary,
        decimal allowances,
        decimal deductions,
        string currency = "NGN")
    {
        var grossSalary = basicSalary + allowances;
        var netSalary = grossSalary - deductions;

        if (netSalary < 0)
        {
            throw new Exception("Net salary cannot be negative.");
        }

        Action<IDocumentContainer> documentSetup = container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(36);
                page.DefaultTextStyle(style => style.FontSize(10));

                page.Header().Column(col =>
                {
                    col.Item().Text("EMPLOYEE PAYSLIP").FontSize(20).Bold().FontColor(BrandColor);
                    col.Item().Text($"Period: {payrollPeriod}").FontSize(11).SemiBold();
                });

                page.Content().PaddingVertical(20).Column(col =>
                {
                    col.Spacing(10);

                    col.Item().Background(Colors.Grey.Lighten4).Padding(10).Column(info =>
                    {
                        info.Item().Text($"Employee Name: {employeeName}").SemiBold();
                        info.Item().Text($"Staff Number: {employeeNumber}");
                    });

                    col.Item().PaddingTop(10).Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(3);
                            columns.RelativeColumn(2);
                        });

                        // Basic Salary
                        table.Cell().BorderBottom(1).BorderColor(BorderColor).Padding(6).Text("Basic Salary");
                        table.Cell().BorderBottom(1).BorderColor(BorderColor).Padding(6).AlignRight().Text($"{currency} {basicSalary:N2}");

                        // Allowances
                        table.Cell().BorderBottom(1).BorderColor(BorderColor).Padding(6).Text("Allowances");
                        table.Cell().BorderBottom(1).BorderColor(BorderColor).Padding(6).AlignRight().Text($"{currency} {allowances:N2}");

                        // Gross Pay
                        table.Cell().Background(Colors.Grey.Lighten3).Padding(6).Text("Gross Salary").Bold();
                        table.Cell().Background(Colors.Grey.Lighten3).Padding(6).AlignRight().Text($"{currency} {grossSalary:N2}").Bold();

                        // Deductions
                        table.Cell().BorderBottom(1).BorderColor(BorderColor).Padding(6).Text("Total Deductions");
                        table.Cell().BorderBottom(1).BorderColor(BorderColor).Padding(6).AlignRight().Text($"{currency} {deductions:N2}");

                        // Net Pay
                        table.Cell().Background(Colors.Blue.Lighten5).Padding(8).Text("Net Salary").Bold().FontSize(12);
                        table.Cell().Background(Colors.Blue.Lighten5).Padding(8).AlignRight().Text($"{currency} {netSalary:N2}").Bold().FontSize(12).FontColor(BrandColor);
                    });
                });

                page.Footer().AlignCenter().Text("Confidential - For employee use only").FontSize(9).FontColor(Colors.Grey.Darken1);
            });
        };

        return Document.Create(documentSetup).GeneratePdf();
    }
}