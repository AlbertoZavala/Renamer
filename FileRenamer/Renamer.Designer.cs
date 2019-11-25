namespace FileRenamer
{
    partial class Renamer
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearchPath = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.chkCreationDate = new System.Windows.Forms.CheckBox();
            this.chkIncludeSubFolders = new System.Windows.Forms.CheckBox();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(119, 43);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(327, 23);
            this.txtPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta a renombrar:";
            // 
            // btnSearchPath
            // 
            this.btnSearchPath.Location = new System.Drawing.Point(452, 43);
            this.btnSearchPath.Name = "btnSearchPath";
            this.btnSearchPath.Size = new System.Drawing.Size(25, 23);
            this.btnSearchPath.TabIndex = 2;
            this.btnSearchPath.Text = "...";
            this.btnSearchPath.UseVisualStyleBackColor = true;
            this.btnSearchPath.Click += new System.EventHandler(this.btnSearchClick);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(191, 152);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(140, 23);
            this.btnRename.TabIndex = 3;
            this.btnRename.Text = "Renombrar";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRenameClick);
            // 
            // chkCreationDate
            // 
            this.chkCreationDate.AutoSize = true;
            this.chkCreationDate.Location = new System.Drawing.Point(136, 99);
            this.chkCreationDate.Name = "chkCreationDate";
            this.chkCreationDate.Size = new System.Drawing.Size(249, 19);
            this.chkCreationDate.TabIndex = 4;
            this.chkCreationDate.Text = "Fecha de creación (o última modificación)";
            this.chkCreationDate.UseVisualStyleBackColor = true;
            // 
            // chkIncludeSubFolders
            // 
            this.chkIncludeSubFolders.AutoSize = true;
            this.chkIncludeSubFolders.Location = new System.Drawing.Point(136, 77);
            this.chkIncludeSubFolders.Name = "chkIncludeSubFolders";
            this.chkIncludeSubFolders.Size = new System.Drawing.Size(131, 19);
            this.chkIncludeSubFolders.TabIndex = 5;
            this.chkIncludeSubFolders.Text = "Incluir Sub-carpetas";
            this.chkIncludeSubFolders.UseVisualStyleBackColor = true;
            // 
            // Renamer
            // 
            this.ClientSize = new System.Drawing.Size(488, 193);
            this.Controls.Add(this.chkIncludeSubFolders);
            this.Controls.Add(this.chkCreationDate);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnSearchPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPath);
            this.Name = "Renamer";

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearchPath;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.CheckBox chkCreationDate;
        private System.Windows.Forms.CheckBox chkIncludeSubFolders;
    }
}