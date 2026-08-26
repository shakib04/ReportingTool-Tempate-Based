using ReportingTool.Enums;
using ReportingTool.Models;
using ReportingTool.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ReportingTool.Forms
{
    public partial class SettingsForm : Form
    {
        private readonly SettingsService _settingsService;

        public SettingsForm()
        {
            InitializeComponent();

            _settingsService = new SettingsService();

            LoadSettings();
        }

        private void LoadSettings()
        {
            AppSettings settings =
                _settingsService.Load();

            txtTemplatePath.Text =
                settings.DefaultTemplatePath;

            txtOutputFolder.Text =
                settings.DefaultOutputFolder;

            if (settings.OutputMode == OutputMode.Merged)
            {
                rdoMerged.Checked = true;
            }
            else
            {
                rdoSeparate.Checked = true;
            }
        }

        private void btnBrowseTemplate_Click(
            object sender,
            EventArgs e)
        {
            using OpenFileDialog dialog = new();

            dialog.Filter =
                "Word Files (*.docx)|*.docx";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtTemplatePath.Text =
                    dialog.FileName;
            }
        }

        private void btnBrowseOutput_Click(
            object sender,
            EventArgs e)
        {
            using FolderBrowserDialog dialog = new();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                txtOutputFolder.Text =
                    dialog.SelectedPath;
            }
        }

        private void btnSaveSettings_Click(
            object sender,
            EventArgs e)
        {
            var settings = new AppSettings
            {
                DefaultTemplatePath =
                    txtTemplatePath.Text.Trim(),

                DefaultOutputFolder =
                    txtOutputFolder.Text.Trim(),

                OutputMode =
                    rdoMerged.Checked
                        ? OutputMode.Merged
                        : OutputMode.Separate
            };

            _settingsService.Save(settings);

            MessageBox.Show(
                "Settings saved successfully!",
                "Settings",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            Close();
        }
    }
}
