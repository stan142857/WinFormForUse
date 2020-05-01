namespace mingrisoft_3_
{
    partial class geneTest
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.BtnDo = new System.Windows.Forms.Button();
            this.lblinfo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BtnWpf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(12, 246);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // BtnDo
            // 
            this.BtnDo.Location = new System.Drawing.Point(12, 171);
            this.BtnDo.Name = "BtnDo";
            this.BtnDo.Size = new System.Drawing.Size(124, 23);
            this.BtnDo.TabIndex = 1;
            this.BtnDo.Text = "BtnDo";
            this.BtnDo.UseVisualStyleBackColor = true;
            // 
            // lblinfo
            // 
            this.lblinfo.AutoSize = true;
            this.lblinfo.Location = new System.Drawing.Point(102, 29);
            this.lblinfo.Name = "lblinfo";
            this.lblinfo.Size = new System.Drawing.Size(47, 12);
            this.lblinfo.TabIndex = 2;
            this.lblinfo.Text = "lblinfo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 81);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 21);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 119);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(180, 21);
            this.textBox2.TabIndex = 4;
            // 
            // BtnWpf
            // 
            this.BtnWpf.Location = new System.Drawing.Point(455, 158);
            this.BtnWpf.Name = "BtnWpf";
            this.BtnWpf.Size = new System.Drawing.Size(75, 23);
            this.BtnWpf.TabIndex = 5;
            this.BtnWpf.Text = "BtnWpf";
            this.BtnWpf.UseVisualStyleBackColor = true;
            this.BtnWpf.Click += new System.EventHandler(this.BtnWpf_Click);
            // 
            // geneTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnWpf);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblinfo);
            this.Controls.Add(this.BtnDo);
            this.Controls.Add(this.listView1);
            this.Name = "geneTest";
            this.Text = "geneTest";
            this.Load += new System.EventHandler(this.geneTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button BtnDo;
        private System.Windows.Forms.Label lblinfo;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button BtnWpf;
    }
}