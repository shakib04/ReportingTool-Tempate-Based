using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;

namespace ReportingTool.Services;

public class ReplaceTextService
{
    private static readonly Regex PlaceholderRegex =
    new(
        @"\{\{([^{}]+)\}\}",
        RegexOptions.Compiled
    );

    public void ReplacePlaceholders(
OpenXmlElement element,
Dictionary<string, string> data)
    {
        foreach (var paragraph in element.Descendants<Paragraph>())
        {
            ReplaceInParagraph(
                paragraph,
                data
            );
        }
    }

    private void ReplaceInParagraph(
    Paragraph paragraph,
    Dictionary<string, string> data)
    {
        var textElements = paragraph
            .Descendants<Text>()
            .ToList();

        if (textElements.Count == 0)
        {
            return;
        }

        string fullText = string.Concat(
            textElements.Select(x => x.Text)
        );

        var matches = PlaceholderRegex
            .Matches(fullText)
            .Cast<Match>()
            .Reverse()
            .ToList();

        foreach (var match in matches)
        {
            string key = match.Groups[1]
                .Value
                .Trim();

            if (!data.TryGetValue(
                    key,
                    out var value))
            {
                continue;
            }

            ReplaceTextRange(
                textElements,
                match.Index,
                match.Length,
                value ?? ""
            );
        }
    }

    private void ReplaceTextRange(
    List<Text> textElements,
    int startIndex,
    int length,
    string replacement)
    {
        int endIndex = startIndex + length;

        int currentPosition = 0;

        bool replacementInserted = false;

        foreach (var textElement in textElements)
        {
            string text = textElement.Text;

            int elementStart = currentPosition;
            int elementEnd = currentPosition + text.Length;

            currentPosition = elementEnd;

            // এই Text element placeholder-এর বাইরে
            if (elementEnd <= startIndex ||
                elementStart >= endIndex)
            {
                continue;
            }

            int localStart = Math.Max(
                startIndex - elementStart,
                0
            );

            int localEnd = Math.Min(
                endIndex - elementStart,
                text.Length
            );

            string before = text[..localStart];

            string after = text[localEnd..];

            if (!replacementInserted)
            {
                textElement.Text =
                    before + replacement + after;

                replacementInserted = true;
            }
            else
            {
                textElement.Text =
                    before + after;
            }
        }
    }
}
