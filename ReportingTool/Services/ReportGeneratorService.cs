using System;
using System.Collections.Generic;
using System.Text;

using ReportingTool.Models;

namespace ReportingTool.Services;

public class ReportGeneratorService
{
    private readonly ExcelService _excelService;
    private readonly WordService _wordService;

    public ReportGeneratorService(
        ExcelService excelService,
        WordService wordService)
    {
        _excelService = excelService;
        _wordService = wordService;
    }

    public int GenerateReports(
        string excelFilePath,
        string templateFilePath,
        string outputFolderPath)
    {
        List<ReportData> reports =
            _excelService.ReadExcel(excelFilePath);

        if (reports.Count == 0)
        {
            throw new InvalidOperationException(
                "No data found in Excel."
            );
        }

        int generatedCount = 0;

        foreach (ReportData employee in reports)
        {
            string fileName =
                $"Report_{employee.EmployeeId}.docx";

            string outputFilePath =
                Path.Combine(outputFolderPath, fileName);

            _wordService.GenerateReport(
                templateFilePath,
                outputFilePath,
                employee
            );

            generatedCount++;
        }

        return generatedCount;
    }
}
