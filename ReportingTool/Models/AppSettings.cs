using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingTool.Models;

public class AppSettings
{
    public string DefaultTemplatePath { get; set; } = "";

    public string DefaultOutputFolder { get; set; } = "";

    // Separate অথবা Merged
    public string OutputMode { get; set; } = "Separate";
}
