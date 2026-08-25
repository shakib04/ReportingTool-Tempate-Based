using System;
using System.Collections.Generic;
using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;


namespace ReportingTool.Services
{
    public class WordService
    {
        public void GenerateReport(
            string templatePath,
            string outputPath,
            Dictionary<string, string> data)
        {
            File.Copy(templatePath, outputPath, true);

            using var document =
                WordprocessingDocument.Open(outputPath, true);

            var body = document.MainDocumentPart!.Document.Body!;

            foreach (var paragraph in body.Elements<Paragraph>())
            {
                ReplaceTextInParagraph(paragraph, data);
            }

            document.MainDocumentPart.Document.Save();
        }

        private void ReplaceTextInParagraph(
            Paragraph paragraph,
            Dictionary<string, string> data)
        {
            var fullText = paragraph.InnerText;

            foreach (var item in data)
            {
                var placeholder = "{{" + item.Key + "}}";

                fullText = fullText.Replace(
                    placeholder,
                    item.Value ?? string.Empty
                );
            }

            if (fullText != paragraph.InnerText)
            {
                var firstRun = paragraph.Elements<Run>().FirstOrDefault();

                if (firstRun != null)
                {
                    firstRun.RemoveAllChildren<Text>();
                    firstRun.AppendChild(
                        new Text(fullText)
                    );

                    foreach (var run in paragraph.Elements<Run>().Skip(1).ToList())
                    {
                        run.Remove();
                    }
                }
            }
        }
    }
}
