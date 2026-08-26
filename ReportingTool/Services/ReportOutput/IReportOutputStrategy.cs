using ReportingTool.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportingTool.Services.ReportOutput
{
    internal interface IReportOutputStrategy
    {
        int Generate(
        List<ReportData> reports,
        string templateFilePath,
        string outputFolderPath);
    }
}
