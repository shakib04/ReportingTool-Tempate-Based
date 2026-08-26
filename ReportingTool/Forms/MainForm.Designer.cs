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
            btnSelectExcel.Location = new Point(118, 72);
            btnSelectExcel.Name = "btnSelectExcel";
            btnSelectExcel.Size = new Size(330, 46);
            btnSelectExcel.TabIndex = 1;
            btnSelectExcel.Text = "[ Select Excel ]";
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnGenerate);
            Controls.Add(btnSelectOutput);
            Controls.Add(btnSelectTemplate);
            Controls.Add(btnSelectExcel);
            Controls.Add(lblStatus);
            Name = "Form1";
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
    }
}
