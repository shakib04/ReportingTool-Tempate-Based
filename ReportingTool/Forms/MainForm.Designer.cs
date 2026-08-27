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
            label2 = new Label();
            txtTemplatePath = new TextBox();
            txtOutputPath = new TextBox();
            label3 = new Label();
            label4 = new Label();
            rdoSeparate = new RadioButton();
            rdoMerged = new RadioButton();
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
            btnSelectExcel.Location = new Point(649, 64);
            btnSelectExcel.Name = "btnSelectExcel";
            btnSelectExcel.Size = new Size(112, 24);
            btnSelectExcel.TabIndex = 1;
            btnSelectExcel.Text = "[ Browse ]";
            btnSelectExcel.UseVisualStyleBackColor = true;
            btnSelectExcel.Click += btnSelectExcel_Click;
            // 
            // btnSelectTemplate
            // 
            btnSelectTemplate.Location = new Point(649, 118);
            btnSelectTemplate.Name = "btnSelectTemplate";
            btnSelectTemplate.Size = new Size(112, 26);
            btnSelectTemplate.TabIndex = 2;
            btnSelectTemplate.Text = "[ Browse ]";
            btnSelectTemplate.UseVisualStyleBackColor = true;
            btnSelectTemplate.Click += btnSelectTemplate_Click;
            // 
            // btnSelectOutput
            // 
            btnSelectOutput.Location = new Point(649, 169);
            btnSelectOutput.Name = "btnSelectOutput";
            btnSelectOutput.Size = new Size(112, 26);
            btnSelectOutput.TabIndex = 3;
            btnSelectOutput.Text = "[ Browse ]";
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
            btnSettings.Location = new Point(0, 2);
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
            label1.Size = new Size(56, 17);
            label1.TabIndex = 6;
            label1.Text = "Excel File";
            // 
            // txtExcelPath
            // 
            txtExcelPath.Location = new Point(118, 64);
            txtExcelPath.Name = "txtExcelPath";
            txtExcelPath.ReadOnly = true;
            txtExcelPath.Size = new Size(525, 23);
            txtExcelPath.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Location = new Point(118, 101);
            label2.Name = "label2";
            label2.Size = new Size(58, 17);
            label2.TabIndex = 8;
            label2.Text = "Template";
            // 
            // txtTemplatePath
            // 
            txtTemplatePath.Location = new Point(118, 121);
            txtTemplatePath.Name = "txtTemplatePath";
            txtTemplatePath.ReadOnly = true;
            txtTemplatePath.Size = new Size(525, 23);
            txtTemplatePath.TabIndex = 9;
            // 
            // txtOutputPath
            // 
            txtOutputPath.Location = new Point(118, 172);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.ReadOnly = true;
            txtOutputPath.Size = new Size(525, 23);
            txtOutputPath.TabIndex = 10;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(118, 152);
            label3.Name = "label3";
            label3.Size = new Size(83, 17);
            label3.TabIndex = 11;
            label3.Text = "Output Folder";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Location = new Point(118, 214);
            label4.Name = "label4";
            label4.Size = new Size(81, 17);
            label4.TabIndex = 12;
            label4.Text = "Output Mode";
            // 
            // rdoSeparate
            // 
            rdoSeparate.AutoSize = true;
            rdoSeparate.Location = new Point(118, 243);
            rdoSeparate.Name = "rdoSeparate";
            rdoSeparate.Size = new Size(96, 19);
            rdoSeparate.TabIndex = 13;
            rdoSeparate.TabStop = true;
            rdoSeparate.Text = "Separate Files";
            rdoSeparate.UseVisualStyleBackColor = true;
            // 
            // rdoMerged
            // 
            rdoMerged.AutoSize = true;
            rdoMerged.Location = new Point(118, 266);
            rdoMerged.Name = "rdoMerged";
            rdoMerged.Size = new Size(87, 19);
            rdoMerged.TabIndex = 14;
            rdoMerged.TabStop = true;
            rdoMerged.Text = "Merged File\n";
            rdoMerged.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rdoMerged);
            Controls.Add(rdoSeparate);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(txtOutputPath);
            Controls.Add(txtTemplatePath);
            Controls.Add(label2);
            Controls.Add(txtExcelPath);
            Controls.Add(label1);
            Controls.Add(btnSettings);
            Controls.Add(btnGenerate);
            Controls.Add(btnSelectOutput);
            Controls.Add(btnSelectTemplate);
            Controls.Add(btnSelectExcel);
            Controls.Add(lblStatus);
            Name = "MainForm";
            Text = "  ";
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
        private Label label2;
        private TextBox txtTemplatePath;
        private TextBox txtOutputPath;
        private Label label3;
        private Label label4;
        private RadioButton rdoSeparate;
        private RadioButton rdoMerged;
    }
}
