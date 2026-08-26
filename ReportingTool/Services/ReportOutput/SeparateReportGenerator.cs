using System;
using System.Collections.Generic;
using System.Text;

using ReportingTool.Models;

namespace ReportingTool.Services.ReportOutput;

public class SeparateReportGenerator : IReportOutputStrategy
{
    private readonly WordService _wordService;

    public SeparateReportGenerator(
        WordService wordService)
    {
        _wordService = wordService;
    }

    public int Generate(
        List<ReportData> reports,
        string templateFilePath,
        string outputFolderPath)
    {
        Directory.CreateDirectory(outputFolderPath);

        int generatedCount = 0;

        foreach (ReportData employee in reports)
        {
            string fileName =
                $"Report_{employee.EmployeeId}.docx";

            string outputFilePath = Path.Combine(
                outputFolderPath,
                fileName
            );

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
