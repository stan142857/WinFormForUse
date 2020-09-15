namespace mingrisoft_3_
{
    partial class ImgCompare
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
            this.btnCompare = new System.Windows.Forms.Button();
            this.btnAddPic2 = new System.Windows.Forms.Button();
            this.btnAddPic1 = new System.Windows.Forms.Button();
            this.TBFloderPath = new System.Windows.Forms.TextBox();
            this.btnReadFloder = new System.Windows.Forms.Button();
            this.btnCompareFloder = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.rTBInfo = new System.Windows.Forms.RichTextBox();
            this.btnDelectThisFile = new System.Windows.Forms.Button();
            this.TBAddName = new System.Windows.Forms.TextBox();
            this.btnSaveRecord = new System.Windows.Forms.Button();
            this.LblTip = new System.Windows.Forms.Label();
            this.btnSaveFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(452, 303);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 5;
            this.btnCompare.Text = "对比";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // btnAddPic2
            // 
            this.btnAddPic2.Image = global::mingrisoft_3_.Properties.Resources._128706;
            this.btnAddPic2.Location = new System.Drawing.Point(33, 303);
            this.btnAddPic2.Name = "btnAddPic2";
            this.btnAddPic2.Size = new System.Drawing.Size(176, 103);
            this.btnAddPic2.TabIndex = 4;
            this.btnAddPic2.Text = "加载图片";
            this.btnAddPic2.UseVisualStyleBackColor = true;
            // 
            // btnAddPic1
            // 
            this.btnAddPic1.Image = global::mingrisoft_3_.Properties.Resources._128706;
            this.btnAddPic1.Location = new System.Drawing.Point(242, 303);
            this.btnAddPic1.Name = "btnAddPic1";
            this.btnAddPic1.Size = new System.Drawing.Size(176, 103);
            this.btnAddPic1.TabIndex = 0;
            this.btnAddPic1.Text = "加载图片";
            this.btnAddPic1.UseVisualStyleBackColor = true;
            // 
            // TBFloderPath
            // 
            this.TBFloderPath.Location = new System.Drawing.Point(187, 14);
            this.TBFloderPath.Name = "TBFloderPath";
            this.TBFloderPath.Size = new System.Drawing.Size(340, 21);
            this.TBFloderPath.TabIndex = 6;
            // 
            // btnReadFloder
            // 
            this.btnReadFloder.Location = new System.Drawing.Point(33, 12);
            this.btnReadFloder.Name = "btnReadFloder";
            this.btnReadFloder.Size = new System.Drawing.Size(132, 23);
            this.btnReadFloder.TabIndex = 8;
            this.btnReadFloder.Text = "读取图片文件夹路径";
            this.btnReadFloder.UseVisualStyleBackColor = true;
            this.btnReadFloder.Click += new System.EventHandler(this.btnReadFloder_Click);
            // 
            // btnCompareFloder
            // 
            this.btnCompareFloder.Location = new System.Drawing.Point(535, 14);
            this.btnCompareFloder.Name = "btnCompareFloder";
            this.btnCompareFloder.Size = new System.Drawing.Size(139, 23);
            this.btnCompareFloder.TabIndex = 9;
            this.btnCompareFloder.Text = "批量对比开始处理";
            this.btnCompareFloder.UseVisualStyleBackColor = true;
            this.btnCompareFloder.Click += new System.EventHandler(this.btnCompareFloder_Click);
            // 
            // rTBInfo
            // 
            this.rTBInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTBInfo.Location = new System.Drawing.Point(33, 104);
            this.rTBInfo.Name = "rTBInfo";
            this.rTBInfo.Size = new System.Drawing.Size(734, 169);
            this.rTBInfo.TabIndex = 10;
            this.rTBInfo.Text = "";
            // 
            // btnDelectThisFile
            // 
            this.btnDelectThisFile.Location = new System.Drawing.Point(535, 47);
            this.btnDelectThisFile.Name = "btnDelectThisFile";
            this.btnDelectThisFile.Size = new System.Drawing.Size(139, 23);
            this.btnDelectThisFile.TabIndex = 11;
            this.btnDelectThisFile.Text = "删除+转移 处理开始";
            this.btnDelectThisFile.UseVisualStyleBackColor = true;
            this.btnDelectThisFile.Click += new System.EventHandler(this.btnDelectThisFile_Click);
            // 
            // TBAddName
            // 
            this.TBAddName.Location = new System.Drawing.Point(187, 47);
            this.TBAddName.Name = "TBAddName";
            this.TBAddName.Size = new System.Drawing.Size(340, 21);
            this.TBAddName.TabIndex = 12;
            // 
            // btnSaveRecord
            // 
            this.btnSaveRecord.Location = new System.Drawing.Point(452, 274);
            this.btnSaveRecord.Name = "btnSaveRecord";
            this.btnSaveRecord.Size = new System.Drawing.Size(75, 23);
            this.btnSaveRecord.TabIndex = 13;
            this.btnSaveRecord.Text = "保存记录";
            this.btnSaveRecord.UseVisualStyleBackColor = true;
            this.btnSaveRecord.Click += new System.EventHandler(this.btnSaveRecord_Click);
            // 
            // LblTip
            // 
            this.LblTip.AutoSize = true;
            this.LblTip.Location = new System.Drawing.Point(533, 71);
            this.LblTip.Name = "LblTip";
            this.LblTip.Size = new System.Drawing.Size(41, 12);
            this.LblTip.TabIndex = 14;
            this.LblTip.Text = "LblTip";
            // 
            // btnSaveFolder
            // 
            this.btnSaveFolder.Location = new System.Drawing.Point(33, 47);
            this.btnSaveFolder.Name = "btnSaveFolder";
            this.btnSaveFolder.Size = new System.Drawing.Size(132, 23);
            this.btnSaveFolder.TabIndex = 15;
            this.btnSaveFolder.Text = "选择转移文件夹";
            this.btnSaveFolder.UseVisualStyleBackColor = true;
            this.btnSaveFolder.Click += new System.EventHandler(this.btnSaveFolder_Click);
            // 
            // ImgCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnSaveFolder);
            this.Controls.Add(this.LblTip);
            this.Controls.Add(this.btnSaveRecord);
            this.Controls.Add(this.TBAddName);
            this.Controls.Add(this.btnDelectThisFile);
            this.Controls.Add(this.rTBInfo);
            this.Controls.Add(this.btnCompareFloder);
            this.Controls.Add(this.btnReadFloder);
            this.Controls.Add(this.TBFloderPath);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.btnAddPic2);
            this.Controls.Add(this.btnAddPic1);
            this.Name = "ImgCompare";
            this.Text = "ImgCompare";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddPic1;
        private System.Windows.Forms.Button btnAddPic2;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.TextBox TBFloderPath;
        private System.Windows.Forms.Button btnReadFloder;
        private System.Windows.Forms.Button btnCompareFloder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.RichTextBox rTBInfo;
        private System.Windows.Forms.Button btnDelectThisFile;
        private System.Windows.Forms.TextBox TBAddName;
        private System.Windows.Forms.Button btnSaveRecord;
        private System.Windows.Forms.Label LblTip;
        private System.Windows.Forms.Button btnSaveFolder;
    }
}