using DocumentFormat.OpenXml.Wordprocessing;
using ReportingTool.Enums;
using ReportingTool.Forms;
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
        LoadDefaultSettings();
    }

    private void btnSelectExcel_Click(object sender, EventArgs e)
    {
        using OpenFileDialog dialog = new();

        dialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            excelFilePath = dialog.FileName;
            txtExcelPath.Text = excelFilePath;

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
            txtTemplatePath.Text = templateFilePath;

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
            txtOutputPath.Text = outputFolderPath;

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

            var settingsService = new SettingsService();
            var settings = settingsService.Load();

            int generatedCount =
                generatorService.GenerateReports(
                    excelFilePath!,
                    templateFilePath!,
                    outputFolderPath!,
                    settings.OutputMode
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

    private void btnSettings_Click(
    object sender,
    EventArgs e)
    {
        using var settingsForm = new SettingsForm();

        if (settingsForm.ShowDialog() == DialogResult.OK)
        {
            LoadDefaultSettings();
        }
    }

    private void LoadDefaultSettings()
    {
        var settingsService = new SettingsService();

        var settings = settingsService.Load();

        if (!string.IsNullOrWhiteSpace(settings.DefaultTemplatePath))
        {
            templateFilePath = settings.DefaultTemplatePath;
            txtTemplatePath.Text = templateFilePath;
        }

        if (!string.IsNullOrWhiteSpace(settings.DefaultOutputFolder))
        {
            outputFolderPath = settings.DefaultOutputFolder;
            txtOutputPath.Text = outputFolderPath;
        }

        if (settings.OutputMode == OutputMode.Merged)
        {
            rdoMerged.Checked = true;
        }
        else
        {
            rdoSeparate.Checked = true;
        }
    }
}
