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
        Dictionary<string, string> data)
    {
        File.Copy(
            templatePath,
            outputPath,
            true
        );

        using var document =
            WordprocessingDocument.Open(
                outputPath,
                true
            );

        var body =
            document.MainDocumentPart!
                .Document
                .Body!;

        foreach (var item in data)
        {
            string placeholder =
                $"{{{{{item.Key}}}}}";

            ReplaceText(
                body,
                placeholder,
                item.Value
            );
        }

        document.MainDocumentPart!
            .Document
            .Save();
    }

    private void ReplaceText(
        OpenXmlElement element,
        string placeholder,
        string value)
    {
        foreach (
            var text
            in element.Descendants<Text>())
        {
            if (text.Text.Contains(placeholder))
            {
                text.Text =
                    text.Text.Replace(
                        placeholder,
                        value ?? ""
                    );
            }
        }
    }

    public void GenerateMergedReport(
        string templatePath,
        string outputPath,
        List<Dictionary<string, string>> reports)
    {
        if (reports.Count == 0)
        {
            throw new InvalidOperationException(
                "No reports available to merge."
            );
        }

        // প্রথম employee দিয়ে output document তৈরি
        GenerateReport(
            templatePath,
            outputPath,
            reports[0]
        );

        // Output document open
        using var destinationDocument =
            WordprocessingDocument.Open(
                outputPath,
                true
            );

        var destinationBody =
            destinationDocument
                .MainDocumentPart!
                .Document
                .Body!;

        // দ্বিতীয় employee থেকে শুরু
        for (int i = 1; i < reports.Count; i++)
        {
            // Temporary document path
            string tempFilePath = Path.Combine(
                Path.GetTempPath(),
                $"report_{Guid.NewGuid()}.docx"
            );

            try
            {
                // Temporary DOCX তৈরি
                GenerateReport(
                    templatePath,
                    tempFilePath,
                    reports[i]
                );

                using var sourceDocument =
                    WordprocessingDocument.Open(
                        tempFilePath,
                        false
                    );

                var sourceBody =
                    sourceDocument
                        .MainDocumentPart!
                        .Document
                        .Body!;

                // নতুন report-এর আগে Page Break
                destinationBody.AppendChild(
                    new Paragraph(
                        new Run(
                            new Break
                            {
                                Type =
                                    BreakValues.Page
                            }
                        )
                    )
                );

                // Source body-এর elements clone করে append
                foreach (
                    var element
                    in sourceBody.Elements())
                {
                    if (element is SectionProperties)
                    {
                        continue;
                    }

                    destinationBody.Append(
                        element.CloneNode(true)
                    );
                }
            }
            finally
            {
                if (File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }
            }
        }

        destinationDocument
            .MainDocumentPart!
            .Document
            .Save();
    }
}