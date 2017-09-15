using System;

namespace YTmp3
{
    partial class Downloader
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
            this.urlBox = new System.Windows.Forms.TextBox();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.downloadBtn = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderPickerBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.outputBox = new System.Windows.Forms.TextBox();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // urlBox
            // 
            this.urlBox.AcceptsReturn = true;
            this.urlBox.Location = new System.Drawing.Point(13, 13);
            this.urlBox.Multiline = true;
            this.urlBox.Name = "urlBox";
            this.urlBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.urlBox.Size = new System.Drawing.Size(403, 376);
            this.urlBox.TabIndex = 0;
            this.urlBox.Text = "https://www.youtube.com/watch?v=lXMskKTw3Bc";
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(13, 395);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(192, 20);
            this.pathBox.TabIndex = 1;
            // 
            // downloadBtn
            // 
            this.downloadBtn.Location = new System.Drawing.Point(328, 395);
            this.downloadBtn.Name = "downloadBtn";
            this.downloadBtn.Size = new System.Drawing.Size(87, 20);
            this.downloadBtn.TabIndex = 2;
            this.downloadBtn.Text = "Download";
            this.downloadBtn.UseVisualStyleBackColor = true;
            this.downloadBtn.Click += new System.EventHandler(this.downloadBtn_Click);
            // 
            // folderPickerBtn
            // 
            this.folderPickerBtn.Location = new System.Drawing.Point(193, 395);
            this.folderPickerBtn.Name = "folderPickerBtn";
            this.folderPickerBtn.Size = new System.Drawing.Size(12, 20);
            this.folderPickerBtn.TabIndex = 3;
            this.folderPickerBtn.UseVisualStyleBackColor = true;
            this.folderPickerBtn.Click += new System.EventHandler(this.folderPickerBtn_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(212, 395);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(110, 20);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.DataSource = Enum.GetValues(typeof(Downloader.DLOptions));
            // 
            // outputBox
            // 
            this.outputBox.Enabled = false;
            this.outputBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputBox.Location = new System.Drawing.Point(423, 13);
            this.outputBox.Multiline = true;
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(343, 376);
            this.outputBox.TabIndex = 5;
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(690, 395);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 20);
            this.cancelBtn.TabIndex = 6;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 427);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.folderPickerBtn);
            this.Controls.Add(this.downloadBtn);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.urlBox);
            this.Name = "Downloader";
            this.Text = "YTmp3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button downloadBtn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button folderPickerBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox outputBox;
        private System.Windows.Forms.Button cancelBtn;
    }
}

