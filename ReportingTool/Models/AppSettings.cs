using ReportingTool.Enums;

namespace ReportingTool.Models;

public class AppSettings
{
    public string DefaultTemplatePath { get; set; } = "";

    public string DefaultOutputFolder { get; set; } = "";

    // Separate অথবা Merged
    public OutputMode OutputMode { get; set; } = OutputMode.Merged;
}