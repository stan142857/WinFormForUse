﻿namespace mingrisoft_3_
{
    partial class NeuGet
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
            this.btnCSVInsert = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.LblTips = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnCSVInsert
            // 
            this.btnCSVInsert.Location = new System.Drawing.Point(41, 35);
            this.btnCSVInsert.Name = "btnCSVInsert";
            this.btnCSVInsert.Size = new System.Drawing.Size(109, 23);
            this.btnCSVInsert.TabIndex = 0;
            this.btnCSVInsert.Text = "CSV文档录入";
            this.btnCSVInsert.UseVisualStyleBackColor = true;
            this.btnCSVInsert.Click += new System.EventHandler(this.btnCSVInsert_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // LblTips
            // 
            this.LblTips.AutoSize = true;
            this.LblTips.Location = new System.Drawing.Point(200, 46);
            this.LblTips.Name = "LblTips";
            this.LblTips.Size = new System.Drawing.Size(41, 12);
            this.LblTips.TabIndex = 1;
            this.LblTips.Text = "label1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(41, 64);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(502, 240);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(41, 334);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "格式化数据库";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(150, 310);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(187, 47);
            this.richTextBox2.TabIndex = 5;
            this.richTextBox2.Text = "";
            // 
            // richTextBox3
            // 
            this.richTextBox3.Location = new System.Drawing.Point(343, 310);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(200, 47);
            this.richTextBox3.TabIndex = 6;
            this.richTextBox3.Text = "";
            // 
            // NeuGet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.LblTips);
            this.Controls.Add(this.btnCSVInsert);
            this.Name = "NeuGet";
            this.Text = "NeuGet";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCSVInsert;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label LblTips;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.RichTextBox richTextBox3;
    }
}