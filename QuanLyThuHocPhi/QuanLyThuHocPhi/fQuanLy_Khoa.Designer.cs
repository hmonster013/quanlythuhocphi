﻿namespace QuanLyThuHocPhi
{
    partial class fQuanLy_Khoa
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvHienThi = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txbTenKhoa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txbGTTC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.txbMaKhoa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btNhapExcel = new System.Windows.Forms.Button();
            this.btXuatExcel = new System.Windows.Forms.Button();
            this.btReset = new System.Windows.Forms.Button();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvHienThi);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 275);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 359);
            this.panel2.TabIndex = 3;
            // 
            // dgvHienThi
            // 
            this.dgvHienThi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHienThi.Location = new System.Drawing.Point(0, 0);
            this.dgvHienThi.Name = "dgvHienThi";
            this.dgvHienThi.Size = new System.Drawing.Size(1081, 359);
            this.dgvHienThi.TabIndex = 0;
            this.dgvHienThi.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHienThi_CellClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txbTenKhoa);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(36, 62);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(397, 42);
            this.panel5.TabIndex = 1;
            // 
            // txbTenKhoa
            // 
            this.txbTenKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbTenKhoa.Location = new System.Drawing.Point(142, 9);
            this.txbTenKhoa.Name = "txbTenKhoa";
            this.txbTenKhoa.Size = new System.Drawing.Size(252, 26);
            this.txbTenKhoa.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tên khoa:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.txbGTTC);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(507, 14);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(397, 42);
            this.panel6.TabIndex = 2;
            // 
            // txbGTTC
            // 
            this.txbGTTC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbGTTC.Location = new System.Drawing.Point(142, 8);
            this.txbGTTC.Name = "txbGTTC";
            this.txbGTTC.Size = new System.Drawing.Size(252, 26);
            this.txbGTTC.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giá tiền 1 tín chỉ:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.txbMaKhoa);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Location = new System.Drawing.Point(36, 14);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(397, 42);
            this.panel4.TabIndex = 0;
            // 
            // txbMaKhoa
            // 
            this.txbMaKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbMaKhoa.Location = new System.Drawing.Point(142, 7);
            this.txbMaKhoa.Name = "txbMaKhoa";
            this.txbMaKhoa.Size = new System.Drawing.Size(252, 26);
            this.txbMaKhoa.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khoa:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.btNhapExcel);
            this.panel3.Controls.Add(this.btXuatExcel);
            this.panel3.Controls.Add(this.btReset);
            this.panel3.Controls.Add(this.btXoa);
            this.panel3.Controls.Add(this.btSua);
            this.panel3.Controls.Add(this.btThem);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(968, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(113, 275);
            this.panel3.TabIndex = 3;
            // 
            // btNhapExcel
            // 
            this.btNhapExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btNhapExcel.Location = new System.Drawing.Point(0, 225);
            this.btNhapExcel.Name = "btNhapExcel";
            this.btNhapExcel.Size = new System.Drawing.Size(109, 45);
            this.btNhapExcel.TabIndex = 5;
            this.btNhapExcel.Text = "Nhập Excel";
            this.btNhapExcel.UseVisualStyleBackColor = true;
            this.btNhapExcel.Click += new System.EventHandler(this.btNhapExcel_Click);
            // 
            // btXuatExcel
            // 
            this.btXuatExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btXuatExcel.Location = new System.Drawing.Point(0, 180);
            this.btXuatExcel.Name = "btXuatExcel";
            this.btXuatExcel.Size = new System.Drawing.Size(109, 45);
            this.btXuatExcel.TabIndex = 4;
            this.btXuatExcel.Text = "Xuất Excel";
            this.btXuatExcel.UseVisualStyleBackColor = true;
            this.btXuatExcel.Click += new System.EventHandler(this.btXuatExcel_Click);
            // 
            // btReset
            // 
            this.btReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.btReset.Location = new System.Drawing.Point(0, 135);
            this.btReset.Name = "btReset";
            this.btReset.Size = new System.Drawing.Size(109, 45);
            this.btReset.TabIndex = 3;
            this.btReset.Text = "Reset";
            this.btReset.UseVisualStyleBackColor = true;
            this.btReset.Click += new System.EventHandler(this.btReset_Click);
            // 
            // btXoa
            // 
            this.btXoa.Dock = System.Windows.Forms.DockStyle.Top;
            this.btXoa.Location = new System.Drawing.Point(0, 90);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(109, 45);
            this.btXoa.TabIndex = 2;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.Dock = System.Windows.Forms.DockStyle.Top;
            this.btSua.Location = new System.Drawing.Point(0, 45);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(109, 45);
            this.btSua.TabIndex = 1;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btThem
            // 
            this.btThem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btThem.Location = new System.Drawing.Point(0, 0);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(109, 45);
            this.btThem.TabIndex = 0;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1081, 275);
            this.panel1.TabIndex = 2;
            // 
            // fQuanLy_Khoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 634);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "fQuanLy_Khoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fQuanLy_Khoa";
            this.Load += new System.EventHandler(this.fAdmin_Khoa_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHienThi)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvHienThi;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txbTenKhoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox txbGTTC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txbMaKhoa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btReset;
        private System.Windows.Forms.Button btNhapExcel;
        private System.Windows.Forms.Button btXuatExcel;
    }
}