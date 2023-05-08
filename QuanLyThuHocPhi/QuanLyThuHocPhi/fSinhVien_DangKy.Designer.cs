namespace QuanLyThuHocPhi
{
    partial class fSinhVien_DangKy
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btDangKy = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cbHocKy = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txbMaSV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txbMaDK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvHienThi = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btDangKy);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(937, 153);
            this.panel1.TabIndex = 0;
            // 
            // btDangKy
            // 
            this.btDangKy.AutoSize = true;
            this.btDangKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDangKy.Location = new System.Drawing.Point(12, 117);
            this.btDangKy.Name = "btDangKy";
            this.btDangKy.Size = new System.Drawing.Size(77, 30);
            this.btDangKy.TabIndex = 5;
            this.btDangKy.Text = "Đăng ký";
            this.btDangKy.UseVisualStyleBackColor = true;
            this.btDangKy.Click += new System.EventHandler(this.btDangKy_Click);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cbHocKy);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Location = new System.Drawing.Point(487, 12);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(397, 42);
            this.panel5.TabIndex = 4;
            // 
            // cbHocKy
            // 
            this.cbHocKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbHocKy.FormattingEnabled = true;
            this.cbHocKy.Location = new System.Drawing.Point(147, 5);
            this.cbHocKy.Name = "cbHocKy";
            this.cbHocKy.Size = new System.Drawing.Size(247, 28);
            this.cbHocKy.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(2, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Học kỳ:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txbMaSV);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(12, 60);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(397, 42);
            this.panel3.TabIndex = 3;
            // 
            // txbMaSV
            // 
            this.txbMaSV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaSV.Location = new System.Drawing.Point(142, 7);
            this.txbMaSV.Name = "txbMaSV";
            this.txbMaSV.Size = new System.Drawing.Size(252, 26);
            this.txbMaSV.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã sinh viên:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txbMaDK);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(397, 42);
            this.panel4.TabIndex = 2;
            // 
            // txbMaDK
            // 
            this.txbMaDK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaDK.Location = new System.Drawing.Point(142, 7);
            this.txbMaDK.Name = "txbMaDK";
            this.txbMaDK.Size = new System.Drawing.Size(252, 26);
            this.txbMaDK.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã đăng ký:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvHienThi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(937, 297);
            this.panel2.TabIndex = 1;
            // 
            // dgvHienThi
            // 
            this.dgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHienThi.Location = new System.Drawing.Point(0, 0);
            this.dgvHienThi.Name = "dgvHienThi";
            this.dgvHienThi.Size = new System.Drawing.Size(937, 297);
            this.dgvHienThi.TabIndex = 0;
            this.dgvHienThi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHienThi_CellContentClick);
            // 
            // fSinhVien_DangKy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fSinhVien_DangKy";
            this.Text = "fSinhVien_DangKy";
            this.Load += new System.EventHandler(this.fSinhVien_DangKy_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvHienThi;
        private System.Windows.Forms.Button btDangKy;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txbMaSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txbMaDK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbHocKy;
    }
}