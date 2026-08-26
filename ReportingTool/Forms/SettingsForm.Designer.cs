namespace ReportingTool.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtTemplatePath = new TextBox();
            btnBrowseTemplate = new Button();
            label2 = new Label();
            txtOutputFolder = new TextBox();
            btnBrowseOutput = new Button();
            grpOutputMode = new GroupBox();
            rdoSeparate = new RadioButton();
            rdoMerged = new RadioButton();
            btnSaveSettings = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(82, 23);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Default Template";
            // 
            // txtTemplatePath
            // 
            txtTemplatePath.Location = new Point(82, 60);
            txtTemplatePath.Name = "txtTemplatePath";
            txtTemplatePath.Size = new Size(100, 23);
            txtTemplatePath.TabIndex = 1;
            // 
            // btnBrowseTemplate
            // 
            btnBrowseTemplate.Location = new Point(222, 60);
            btnBrowseTemplate.Name = "btnBrowseTemplate";
            btnBrowseTemplate.Size = new Size(75, 23);
            btnBrowseTemplate.TabIndex = 2;
            btnBrowseTemplate.Text = "Browse";
            btnBrowseTemplate.UseVisualStyleBackColor = true;
            btnBrowseTemplate.Click += btnBrowseTemplate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(82, 119);
            label2.Name = "label2";
            label2.Size = new Size(122, 15);
            label2.TabIndex = 3;
            label2.Text = "Default Output Folder";
            // 
            // txtOutputFolder
            // 
            txtOutputFolder.Location = new Point(82, 153);
            txtOutputFolder.Name = "txtOutputFolder";
            txtOutputFolder.Size = new Size(100, 23);
            txtOutputFolder.TabIndex = 4;
            // 
            // btnBrowseOutput
            // 
            btnBrowseOutput.Location = new Point(222, 153);
            btnBrowseOutput.Name = "btnBrowseOutput";
            btnBrowseOutput.Size = new Size(75, 23);
            btnBrowseOutput.TabIndex = 5;
            btnBrowseOutput.Text = "Browse";
            btnBrowseOutput.UseVisualStyleBackColor = true;
            btnBrowseOutput.Click += btnBrowseOutput_Click;
            // 
            // grpOutputMode
            // 
            grpOutputMode.Location = new Point(82, 208);
            grpOutputMode.Name = "grpOutputMode";
            grpOutputMode.Size = new Size(194, 90);
            grpOutputMode.TabIndex = 6;
            grpOutputMode.TabStop = false;
            grpOutputMode.Text = "Default Output Mode";
            grpOutputMode.UseCompatibleTextRendering = true;
            // 
            // rdoSeparate
            // 
            rdoSeparate.AutoSize = true;
            rdoSeparate.Location = new Point(82, 254);
            rdoSeparate.Name = "rdoSeparate";
            rdoSeparate.Size = new Size(128, 19);
            rdoSeparate.TabIndex = 7;
            rdoSeparate.TabStop = true;
            rdoSeparate.Text = "Separate Word Files";
            rdoSeparate.UseVisualStyleBackColor = true;
            // 
            // rdoMerged
            // 
            rdoMerged.AutoSize = true;
            rdoMerged.Location = new Point(82, 279);
            rdoMerged.Name = "rdoMerged";
            rdoMerged.Size = new Size(154, 19);
            rdoMerged.TabIndex = 8;
            rdoMerged.TabStop = true;
            rdoMerged.Text = "Single Merged Word File";
            rdoMerged.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            btnSaveSettings.Location = new Point(107, 336);
            btnSaveSettings.Name = "btnSaveSettings";
            btnSaveSettings.Size = new Size(75, 23);
            btnSaveSettings.TabIndex = 9;
            btnSaveSettings.Text = "Save Settings";
            btnSaveSettings.UseVisualStyleBackColor = true;
            btnSaveSettings.Click += btnSaveSettings_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(201, 336);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveSettings);
            Controls.Add(rdoMerged);
            Controls.Add(rdoSeparate);
            Controls.Add(grpOutputMode);
            Controls.Add(btnBrowseOutput);
            Controls.Add(txtOutputFolder);
            Controls.Add(label2);
            Controls.Add(btnBrowseTemplate);
            Controls.Add(txtTemplatePath);
            Controls.Add(label1);
            Name = "SettingsForm";
            Text = "Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtTemplatePath;
        private Button btnBrowseTemplate;
        private Label label2;
        private TextBox txtOutputFolder;
        private Button btnBrowseOutput;
        private GroupBox grpOutputMode;
        private RadioButton rdoSeparate;
        private RadioButton rdoMerged;
        private Button btnSaveSettings;
        private Button btnCancel;
    }
}