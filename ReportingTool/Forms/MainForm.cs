using ReportingTool.Services;

namespace ReportingTool;

public partial class MainForm : Form
{
    private string? excelFilePath;
    private string? templateFilePath;
    private string? outputFolderPath;

    public MainForm()
    {
        InitializeComponent();
    }

    private void btnSelectExcel_Click(object sender, EventArgs e)
    {
        using OpenFileDialog dialog = new();

        dialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            excelFilePath = dialog.FileName;

            lblStatus.Text =
                $"Excel: {Path.GetFileName(excelFilePath)}";
        }
    }

    private void btnSelectTemplate_Click(
        object sender,
        EventArgs e)
    {
        using OpenFileDialog dialog = new();

        dialog.Filter = "Word Files (*.docx)|*.docx";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            templateFilePath = dialog.FileName;

            lblStatus.Text =
                $"Template: {Path.GetFileName(templateFilePath)}";
        }
    }

    private void btnSelectOutput_Click(
        object sender,
        EventArgs e)
    {
        using FolderBrowserDialog dialog = new();

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            outputFolderPath = dialog.SelectedPath;

            lblStatus.Text =
                $"Output folder selected.";
        }
    }

    private void btnGenerate_Click(
        object sender,
        EventArgs e)
    {
        if (!ValidateInputs())
        {
            return;
        }

        try
        {
            lblStatus.Text = "Generating reports...";

            var generatorService =
                new ReportGeneratorService(
                    new ExcelService(),
                    new WordService()
                );

            int generatedCount =
                generatorService.GenerateReports(
                    excelFilePath!,
                    templateFilePath!,
                    outputFolderPath!
                );

            lblStatus.Text =
                $"{generatedCount} reports generated!";

            MessageBox.Show(
                $"{generatedCount} reports generated successfully!",
                "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Error occurred.";

            MessageBox.Show(
                ex.Message,
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
    }

    private bool ValidateInputs()
    {
        if (string.IsNullOrWhiteSpace(excelFilePath))
        {
            MessageBox.Show("Please select an Excel file.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(templateFilePath))
        {
            MessageBox.Show("Please select a Word template.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(outputFolderPath))
        {
            MessageBox.Show("Please select an output folder.");
            return false;
        }

        return true;
    }
}
