namespace AreaImportExportTool
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTeamProject = new System.Windows.Forms.TextBox();
            this.txtCollectionUri = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkIterationStructure = new System.Windows.Forms.CheckBox();
            this.chkAreaStructure = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdExport = new System.Windows.Forms.Button();
            this.cmdImport = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTeamProject);
            this.groupBox1.Controls.Add(this.txtCollectionUri);
            this.groupBox1.Location = new System.Drawing.Point(14, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(385, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Team &Project:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "TFS Collection URI:";
            // 
            // txtTeamProject
            // 
            this.txtTeamProject.Location = new System.Drawing.Point(125, 66);
            this.txtTeamProject.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTeamProject.Name = "txtTeamProject";
            this.txtTeamProject.Size = new System.Drawing.Size(249, 23);
            this.txtTeamProject.TabIndex = 3;
            this.txtTeamProject.TextChanged += new System.EventHandler(this.chkIterationStructure_CheckedChanged);
            // 
            // txtCollectionUri
            // 
            this.txtCollectionUri.Location = new System.Drawing.Point(125, 30);
            this.txtCollectionUri.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCollectionUri.Name = "txtCollectionUri";
            this.txtCollectionUri.Size = new System.Drawing.Size(249, 23);
            this.txtCollectionUri.TabIndex = 1;
            this.txtCollectionUri.TextChanged += new System.EventHandler(this.chkIterationStructure_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkIterationStructure);
            this.groupBox2.Controls.Add(this.chkAreaStructure);
            this.groupBox2.Location = new System.Drawing.Point(14, 139);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(385, 116);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Choose items to im-/export";
            // 
            // chkIterationStructure
            // 
            this.chkIterationStructure.AutoSize = true;
            this.chkIterationStructure.Checked = true;
            this.chkIterationStructure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIterationStructure.Location = new System.Drawing.Point(10, 68);
            this.chkIterationStructure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkIterationStructure.Name = "chkIterationStructure";
            this.chkIterationStructure.Size = new System.Drawing.Size(120, 19);
            this.chkIterationStructure.TabIndex = 1;
            this.chkIterationStructure.Text = "&Iteration structure";
            this.chkIterationStructure.UseVisualStyleBackColor = true;
            this.chkIterationStructure.CheckedChanged += new System.EventHandler(this.chkIterationStructure_CheckedChanged);
            // 
            // chkAreaStructure
            // 
            this.chkAreaStructure.AutoSize = true;
            this.chkAreaStructure.Checked = true;
            this.chkAreaStructure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAreaStructure.Location = new System.Drawing.Point(10, 34);
            this.chkAreaStructure.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkAreaStructure.Name = "chkAreaStructure";
            this.chkAreaStructure.Size = new System.Drawing.Size(100, 19);
            this.chkAreaStructure.TabIndex = 0;
            this.chkAreaStructure.Text = "&Area structure";
            this.chkAreaStructure.UseVisualStyleBackColor = true;
            this.chkAreaStructure.CheckedChanged += new System.EventHandler(this.chkIterationStructure_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 270);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(378, 55);
            this.label3.TabIndex = 2;
            this.label3.Text = "Note: This tool does not im-/export permissions that might be assigned to areas o" +
    "r iterations.";
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(24, 329);
            this.cmdExport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(87, 29);
            this.cmdExport.TabIndex = 3;
            this.cmdExport.Text = "&Export...";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // cmdImport
            // 
            this.cmdImport.Location = new System.Drawing.Point(119, 329);
            this.cmdImport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdImport.Name = "cmdImport";
            this.cmdImport.Size = new System.Drawing.Size(87, 29);
            this.cmdImport.TabIndex = 4;
            this.cmdImport.Text = "&Import...";
            this.cmdImport.UseVisualStyleBackColor = true;
            this.cmdImport.Click += new System.EventHandler(this.cmdImport_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdClose.Location = new System.Drawing.Point(213, 329);
            this.cmdClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(87, 29);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "&Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.cmdExport;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdClose;
            this.ClientSize = new System.Drawing.Size(420, 375);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdImport);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Area Import/Export Tool (for TFS 2010)";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCollectionUri;
        private System.Windows.Forms.TextBox txtTeamProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkIterationStructure;
        private System.Windows.Forms.CheckBox chkAreaStructure;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.Button cmdImport;
        private System.Windows.Forms.Button cmdClose;
    }
}

