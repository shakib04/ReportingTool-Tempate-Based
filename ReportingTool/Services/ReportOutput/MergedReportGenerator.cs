using System;
using System.Collections.Generic;
using System.Text;

using ReportingTool.Models;

namespace ReportingTool.Services.ReportOutput;

public class MergedReportGenerator : IReportOutputStrategy
{
    private readonly WordService _wordService;

    public MergedReportGenerator(
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

        string outputFilePath = Path.Combine(
            outputFolderPath,
            "All_Reports.docx"
        );

        _wordService.GenerateMergedReport(
            templateFilePath,
            outputFilePath,
            reports
        );

        return reports.Count;
    }
}
