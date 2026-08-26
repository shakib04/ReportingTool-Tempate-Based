using ReportingTool.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
        List<Dictionary<string, string>> reports,
        string templateFilePath,
        string outputFolderPath)
    {
        Directory.CreateDirectory(outputFolderPath);

        int generatedCount = 0;

        foreach (var report in reports)
        {
            string fileName =
                 $"Report_{generatedCount + 1}.docx";

            string outputFilePath = Path.Combine(
                    outputFolderPath,
                    fileName
                );

            _wordService.GenerateReport(
                templateFilePath,
                outputFilePath,
                report
            );

            generatedCount++;
        }

        return generatedCount;
    }
}
