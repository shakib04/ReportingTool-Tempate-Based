using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using ReportingTool.Models;
using System.Text.RegularExpressions;

namespace ReportingTool.Services;

public class WordService
{
    private static readonly Regex PlaceholderRegex =
        new(
            @"\{\{([^{}]+)\}\}",
            RegexOptions.Compiled
        );

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

        ReplacePlaceholders(
            document.MainDocumentPart!
                .Document
                .Body!,
            data
        );

        document.MainDocumentPart!
            .Document
            .Save();
    }

    private void ReplacePlaceholders(
        OpenXmlElement element,
        Dictionary<string, string> data)
    {
        foreach (var text in element.Descendants<Text>())
        {
            if (string.IsNullOrEmpty(text.Text))
            {
                continue;
            }

            text.Text =
                PlaceholderRegex.Replace(
                    text.Text,
                    match =>
                    {
                        string key =
                            match.Groups[1]
                                .Value
                                .Trim();

                        return data.TryGetValue(
                            key,
                            out var value)
                            ? value ?? ""
                            : match.Value;
                    }
                );
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