namespace QuanLyThuHocPhi
{
    partial class fAdmin
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btThoat = new System.Windows.Forms.Button();
            this.btLopTinChi = new System.Windows.Forms.Button();
            this.btGiangVien = new System.Windows.Forms.Button();
            this.btLopHoc = new System.Windows.Forms.Button();
            this.btTinChi = new System.Windows.Forms.Button();
            this.btMonHoc = new System.Windows.Forms.Button();
            this.btKhoa = new System.Windows.Forms.Button();
            this.bt_SinhVien = new System.Windows.Forms.Button();
            this.pnlHienThi = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Pink;
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(211, 88);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btThoat);
            this.panel2.Controls.Add(this.btLopTinChi);
            this.panel2.Controls.Add(this.btGiangVien);
            this.panel2.Controls.Add(this.btLopHoc);
            this.panel2.Controls.Add(this.btTinChi);
            this.panel2.Controls.Add(this.btMonHoc);
            this.panel2.Controls.Add(this.btKhoa);
            this.panel2.Controls.Add(this.bt_SinhVien);
            this.panel2.Location = new System.Drawing.Point(1, 92);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(211, 588);
            this.panel2.TabIndex = 1;
            // 
            // btThoat
            // 
            this.btThoat.FlatAppearance.BorderSize = 0;
            this.btThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btThoat.Location = new System.Drawing.Point(3, 473);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(208, 64);
            this.btThoat.TabIndex = 7;
            this.btThoat.Text = "THOÁT";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);
            // 
            // btLopTinChi
            // 
            this.btLopTinChi.FlatAppearance.BorderSize = 0;
            this.btLopTinChi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLopTinChi.Location = new System.Drawing.Point(3, 406);
            this.btLopTinChi.Name = "btLopTinChi";
            this.btLopTinChi.Size = new System.Drawing.Size(208, 64);
            this.btLopTinChi.TabIndex = 6;
            this.btLopTinChi.Text = "LỚP TÍN CHỈ";
            this.btLopTinChi.UseVisualStyleBackColor = true;
            this.btLopTinChi.Click += new System.EventHandler(this.btLopTinChi_Click);
            // 
            // btGiangVien
            // 
            this.btGiangVien.FlatAppearance.BorderSize = 0;
            this.btGiangVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btGiangVien.Location = new System.Drawing.Point(3, 339);
            this.btGiangVien.Name = "btGiangVien";
            this.btGiangVien.Size = new System.Drawing.Size(208, 64);
            this.btGiangVien.TabIndex = 5;
            this.btGiangVien.Text = "GIẢNG VIÊN";
            this.btGiangVien.UseVisualStyleBackColor = true;
            this.btGiangVien.Click += new System.EventHandler(this.btGiangVien_Click);
            // 
            // btLopHoc
            // 
            this.btLopHoc.FlatAppearance.BorderSize = 0;
            this.btLopHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btLopHoc.Location = new System.Drawing.Point(3, 272);
            this.btLopHoc.Name = "btLopHoc";
            this.btLopHoc.Size = new System.Drawing.Size(208, 64);
            this.btLopHoc.TabIndex = 4;
            this.btLopHoc.Text = "LỚP HỌC";
            this.btLopHoc.UseVisualStyleBackColor = true;
            this.btLopHoc.Click += new System.EventHandler(this.btLopHoc_Click);
            // 
            // btTinChi
            // 
            this.btTinChi.FlatAppearance.BorderSize = 0;
            this.btTinChi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btTinChi.Location = new System.Drawing.Point(3, 205);
            this.btTinChi.Name = "btTinChi";
            this.btTinChi.Size = new System.Drawing.Size(208, 64);
            this.btTinChi.TabIndex = 3;
            this.btTinChi.Text = "TÍN CHỈ";
            this.btTinChi.UseVisualStyleBackColor = true;
            this.btTinChi.Click += new System.EventHandler(this.btTinChi_Click);
            // 
            // btMonHoc
            // 
            this.btMonHoc.FlatAppearance.BorderSize = 0;
            this.btMonHoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btMonHoc.Location = new System.Drawing.Point(3, 138);
            this.btMonHoc.Name = "btMonHoc";
            this.btMonHoc.Size = new System.Drawing.Size(208, 64);
            this.btMonHoc.TabIndex = 2;
            this.btMonHoc.Text = "MÔN HỌC";
            this.btMonHoc.UseVisualStyleBackColor = true;
            this.btMonHoc.Click += new System.EventHandler(this.btMonHoc_Click);
            // 
            // btKhoa
            // 
            this.btKhoa.FlatAppearance.BorderSize = 0;
            this.btKhoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btKhoa.Location = new System.Drawing.Point(3, 71);
            this.btKhoa.Name = "btKhoa";
            this.btKhoa.Size = new System.Drawing.Size(208, 64);
            this.btKhoa.TabIndex = 1;
            this.btKhoa.Text = "KHOA";
            this.btKhoa.UseVisualStyleBackColor = true;
            this.btKhoa.Click += new System.EventHandler(this.btKhoa_Click);
            // 
            // bt_SinhVien
            // 
            this.bt_SinhVien.FlatAppearance.BorderSize = 0;
            this.bt_SinhVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_SinhVien.Location = new System.Drawing.Point(3, 4);
            this.bt_SinhVien.Name = "bt_SinhVien";
            this.bt_SinhVien.Size = new System.Drawing.Size(208, 64);
            this.bt_SinhVien.TabIndex = 0;
            this.bt_SinhVien.Text = "SINH VIÊN";
            this.bt_SinhVien.UseVisualStyleBackColor = true;
            this.bt_SinhVien.Click += new System.EventHandler(this.bt_SinhVien_Click);
            // 
            // pnlHienThi
            // 
            this.pnlHienThi.Location = new System.Drawing.Point(212, 2);
            this.pnlHienThi.Name = "pnlHienThi";
            this.pnlHienThi.Size = new System.Drawing.Size(675, 678);
            this.pnlHienThi.TabIndex = 2;
            // 
            // fAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(888, 679);
            this.Controls.Add(this.pnlHienThi);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fAdmin";
            this.Text = "fAdmin";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btThoat;
        private System.Windows.Forms.Button btLopTinChi;
        private System.Windows.Forms.Button btGiangVien;
        private System.Windows.Forms.Button btLopHoc;
        private System.Windows.Forms.Button btTinChi;
        private System.Windows.Forms.Button btMonHoc;
        private System.Windows.Forms.Button btKhoa;
        private System.Windows.Forms.Button bt_SinhVien;
        private System.Windows.Forms.Panel pnlHienThi;
    }
}