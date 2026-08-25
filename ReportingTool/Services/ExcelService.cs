using System;
using System.Collections.Generic;
using System.Text;
using ClosedXML.Excel;
using ReportingTool.Models;

namespace ReportingTool.Services
{
    public class ExcelService
    {
        public List<ReportData> ReadExcel(string filePath)
        {
            var reports = new List<ReportData>();

            using var workbook = new XLWorkbook(filePath);

            var worksheet = workbook.Worksheet(1);

            var rows = worksheet
                .RangeUsed()
                .RowsUsed()
                .Skip(1);

            foreach (var row in rows)
            {
                reports.Add(new ReportData
                {
                    Name = row.Cell(1).GetString(),
                    Designation = row.Cell(2).GetString(),
                    EmployeeId = row.Cell(3).GetString(),
                    RetirementDate = row.Cell(4).GetString()
                });
            }

            return reports;
        }
    }
}
