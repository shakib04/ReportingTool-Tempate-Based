namespace ReportingTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStatus = new Label();
            btnSelectExcel = new Button();
            btnSelectTemplate = new Button();
            btnSelectOutput = new Button();
            btnGenerate = new Button();
            btnSettings = new Button();
            label1 = new Label();
            txtExcelPath = new TextBox();
            SuspendLayout();
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Location = new Point(238, 371);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(41, 17);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Ready";
            // 
            // btnSelectExcel
            // 
            btnSelectExcel.Location = new Point(356, 62);
            btnSelectExcel.Name = "btnSelectExcel";
            btnSelectExcel.Size = new Size(112, 24);
            btnSelectExcel.TabIndex = 1;
            btnSelectExcel.Text = "[ Browse ]";
            btnSelectExcel.UseVisualStyleBackColor = true;
            btnSelectExcel.Click += btnSelectExcel_Click;
            // 
            // btnSelectTemplate
            // 
            btnSelectTemplate.Location = new Point(118, 143);
            btnSelectTemplate.Name = "btnSelectTemplate";
            btnSelectTemplate.Size = new Size(330, 46);
            btnSelectTemplate.TabIndex = 2;
            btnSelectTemplate.Text = "[ Select Word Template ]";
            btnSelectTemplate.UseVisualStyleBackColor = true;
            btnSelectTemplate.Click += btnSelectTemplate_Click;
            // 
            // btnSelectOutput
            // 
            btnSelectOutput.Location = new Point(118, 212);
            btnSelectOutput.Name = "btnSelectOutput";
            btnSelectOutput.Size = new Size(330, 46);
            btnSelectOutput.TabIndex = 3;
            btnSelectOutput.Text = "[ Select Output Folder ]";
            btnSelectOutput.UseVisualStyleBackColor = true;
            btnSelectOutput.Click += btnSelectOutput_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Location = new Point(118, 291);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(330, 46);
            btnGenerate.TabIndex = 4;
            btnGenerate.Text = "[ Generate Reports ]";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(454, 12);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(74, 26);
            btnSettings.TabIndex = 5;
            btnSettings.Text = "Settings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Location = new Point(118, 38);
            label1.Name = "label1";
            label1.Size = new Size(41, 17);
            label1.TabIndex = 6;
            label1.Text = "Ready";
            // 
            // txtExcelPath
            // 
            txtExcelPath.Location = new Point(118, 64);
            txtExcelPath.Name = "txtExcelPath";
            txtExcelPath.Size = new Size(219, 23);
            txtExcelPath.TabIndex = 7;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtExcelPath);
            Controls.Add(label1);
            Controls.Add(btnSettings);
            Controls.Add(btnGenerate);
            Controls.Add(btnSelectOutput);
            Controls.Add(btnSelectTemplate);
            Controls.Add(btnSelectExcel);
            Controls.Add(lblStatus);
            Name = "MainForm";
            Text = "Reporting Tool";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblStatus;
        private Button btnSelectExcel;
        private Button btnSelectTemplate;
        private Button btnSelectOutput;
        private Button btnGenerate;
        private Button btnSettings;
        private Label label1;
        private TextBox txtExcelPath;
    }
}
