using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ReportingTool.Models;

namespace ReportingTool.Services;

public class WordService
{
    public void GenerateReport(
        string templatePath,
        string outputPath,
        ReportData data)
    {
        File.Copy(templatePath, outputPath, true);

        using var document =
            WordprocessingDocument.Open(outputPath, true);

        var body = document.MainDocumentPart!.Document.Body!;

        ReplaceText(body, "{{Name}}", data.Name);

        ReplaceText(
            body,
            "{{Designation}}",
            data.Designation);

        ReplaceText(
            body,
            "{{EmployeeId}}",
            data.EmployeeId);

        ReplaceText(
            body,
            "{{RetirementDate}}",
            data.RetirementDate);

        document.MainDocumentPart.Document.Save();
    }

    private void ReplaceText(
        OpenXmlElement element,
        string placeholder,
        string value)
    {
        foreach (var text in element.Descendants<Text>())
        {
            if (text.Text.Contains(placeholder))
            {
                text.Text =
                    text.Text.Replace(placeholder, value);
            }
        }
    }
}