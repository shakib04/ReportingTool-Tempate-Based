using ReportingTool.Services;
using ReportingTool.Models;

namespace ReportingTool
{
    public partial class Form1 : Form
    {
        private string? excelFilePath;
        private string? templateFilePath;
        private string? outputFolderPath;

        public Form1()
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
                    $"Excel selected: {Path.GetFileName(excelFilePath)}";
            }
        }

        private void btnSelectTemplate_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new();

            dialog.Filter = "Word Files (*.docx)|*.docx";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                templateFilePath = dialog.FileName;

                lblStatus.Text =
                    $"Template selected: {Path.GetFileName(templateFilePath)}";
            }
        }

        private void btnSelectOutput_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog dialog = new();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                outputFolderPath = dialog.SelectedPath;

                lblStatus.Text =
                    $"Output folder: {outputFolderPath}";
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(excelFilePath))
            {
                MessageBox.Show("Please select an Excel file.");
                return;
            }

            if (string.IsNullOrWhiteSpace(templateFilePath))
            {
                MessageBox.Show("Please select a Word template.");
                return;
            }

            if (string.IsNullOrWhiteSpace(outputFolderPath))
            {
                MessageBox.Show("Please select an output folder.");
                return;
            }

            lblStatus.Text = "Ready to generate reports...";

            MessageBox.Show(
                "All files selected successfully!\n\nNext step: Excel → Word generation."
            );
        }
    }

    namespace ReportingTool.Models
    {
        public class Employee
        {
            public string Name { get; set; } = string.Empty;
            public string Designation { get; set; } = string.Empty;
            public string EmployeeId { get; set; } = string.Empty;
            public string RetirementDate { get; set; } = string.Empty;
        }
    }
}
