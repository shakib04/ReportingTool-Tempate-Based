using ClosedXML.Excel;

namespace ReportingTool.Services;

public class ExcelService
{
    public List<Dictionary<string, string>> ReadExcel(
        string filePath)
    {
        var reports =
            new List<Dictionary<string, string>>();

        using var workbook =
            new XLWorkbook(filePath);

        var worksheet = workbook.Worksheet(1);

        var usedRange = worksheet.RangeUsed();

        if (usedRange == null)
        {
            return reports;
        }

        var headerRow = usedRange.FirstRow();

        var headers = new Dictionary<int, string>();

        foreach (var cell in headerRow.Cells())
        {
            string header = cell.GetString().Trim();

            if (!string.IsNullOrWhiteSpace(header))
            {
                headers[cell.Address.ColumnNumber] = header;
            }
        }

        foreach (var row in usedRange.RowsUsed().Skip(1))
        {
            var report =
                new Dictionary<string, string>(
                    StringComparer.OrdinalIgnoreCase);

            foreach (var header in headers)
            {
                string value = row
                    .Cell(header.Key)
                    .GetFormattedString();

                report[header.Value] = value;
            }

            reports.Add(report);
        }

        return reports;
    }
}