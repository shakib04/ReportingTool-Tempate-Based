using ReportingTool.Enums;
using ReportingTool.Models;
using ReportingTool.Services.ReportOutput;

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
        string outputFolderPath,
        OutputMode outputMode)
    {
        List<Dictionary<string, string>> reports =
            _excelService.ReadExcel(excelFilePath);

        if (reports.Count == 0)
        {
            throw new InvalidOperationException(
                "No data found in Excel."
            );
        }

        IReportOutputStrategy strategy =
            CreateStrategy(outputMode);

        return strategy.Generate(
            reports,
            templateFilePath,
            outputFolderPath
        );
    }

    private IReportOutputStrategy CreateStrategy(
        OutputMode outputMode)
    {
        return outputMode switch
        {
            OutputMode.Separate =>
                new SeparateReportGenerator(
                    _wordService),

            OutputMode.Merged =>
                new MergedReportGenerator(
                    _wordService),

            _ => throw new ArgumentOutOfRangeException(
                nameof(outputMode),
                outputMode,
                "Unsupported output mode."
            )
        };
    }
}