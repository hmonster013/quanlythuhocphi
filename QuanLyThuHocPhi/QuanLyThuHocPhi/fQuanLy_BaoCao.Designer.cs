namespace QuanLyThuHocPhi
{
    partial class fQuanLy_BaoCao
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tbBieuDo = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.BieuDo_Char = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.BieuDo_cbTypeBieuDo = new System.Windows.Forms.ComboBox();
            this.BieuDo_cbLop = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.BieuDo_cbChuyenNganh = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BieuDo_cbKhoa = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.BieuDo_btReset = new System.Windows.Forms.Button();
            this.BieuDo_btTaoBieuDo = new System.Windows.Forms.Button();
            this.tbHocPhi = new System.Windows.Forms.TabPage();
            this.HocPhi_dgvHienThi = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.HocPhi_cbLop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.HocPhi_cbChuyenNganh = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.HocPhi_cbKhoa = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.HocPhi_btReset = new System.Windows.Forms.Button();
            this.HocPhi_btXuatExcel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.cbChuaNopHP = new System.Windows.Forms.CheckBox();
            this.tbBieuDo.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BieuDo_Char)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.tbHocPhi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HocPhi_dgvHienThi)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbBieuDo
            // 
            this.tbBieuDo.Controls.Add(this.panel6);
            this.tbBieuDo.Controls.Add(this.panel5);
            this.tbBieuDo.Location = new System.Drawing.Point(4, 29);
            this.tbBieuDo.Name = "tbBieuDo";
            this.tbBieuDo.Size = new System.Drawing.Size(1073, 601);
            this.tbBieuDo.TabIndex = 2;
            this.tbBieuDo.Text = "Biểu đồ";
            this.tbBieuDo.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.BieuDo_Char);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 100);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1073, 501);
            this.panel6.TabIndex = 2;
            // 
            // BieuDo_Char
            // 
            chartArea2.Name = "ChartArea1";
            this.BieuDo_Char.ChartAreas.Add(chartArea2);
            this.BieuDo_Char.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.BieuDo_Char.Legends.Add(legend2);
            this.BieuDo_Char.Location = new System.Drawing.Point(0, 0);
            this.BieuDo_Char.Name = "BieuDo_Char";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.BieuDo_Char.Series.Add(series2);
            this.BieuDo_Char.Size = new System.Drawing.Size(1073, 501);
            this.BieuDo_Char.TabIndex = 1;
            this.BieuDo_Char.Text = "chart1";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.BieuDo_cbTypeBieuDo);
            this.panel5.Controls.Add(this.BieuDo_cbLop);
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.BieuDo_cbChuyenNganh);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.BieuDo_cbKhoa);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.panel7);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1073, 100);
            this.panel5.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Loại biểu đồ:";
            // 
            // BieuDo_cbTypeBieuDo
            // 
            this.BieuDo_cbTypeBieuDo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BieuDo_cbTypeBieuDo.FormattingEnabled = true;
            this.BieuDo_cbTypeBieuDo.Location = new System.Drawing.Point(113, 66);
            this.BieuDo_cbTypeBieuDo.Name = "BieuDo_cbTypeBieuDo";
            this.BieuDo_cbTypeBieuDo.Size = new System.Drawing.Size(159, 28);
            this.BieuDo_cbTypeBieuDo.TabIndex = 19;
            // 
            // BieuDo_cbLop
            // 
            this.BieuDo_cbLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BieuDo_cbLop.FormattingEnabled = true;
            this.BieuDo_cbLop.Location = new System.Drawing.Point(649, 7);
            this.BieuDo_cbLop.Name = "BieuDo_cbLop";
            this.BieuDo_cbLop.Size = new System.Drawing.Size(159, 28);
            this.BieuDo_cbLop.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(603, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Lớp:";
            // 
            // BieuDo_cbChuyenNganh
            // 
            this.BieuDo_cbChuyenNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BieuDo_cbChuyenNganh.FormattingEnabled = true;
            this.BieuDo_cbChuyenNganh.Location = new System.Drawing.Point(372, 7);
            this.BieuDo_cbChuyenNganh.Name = "BieuDo_cbChuyenNganh";
            this.BieuDo_cbChuyenNganh.Size = new System.Drawing.Size(159, 28);
            this.BieuDo_cbChuyenNganh.TabIndex = 16;
            this.BieuDo_cbChuyenNganh.SelectedValueChanged += new System.EventHandler(this.BieuDo_cbChuyenNganh_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(250, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Chuyên ngành:";
            // 
            // BieuDo_cbKhoa
            // 
            this.BieuDo_cbKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BieuDo_cbKhoa.FormattingEnabled = true;
            this.BieuDo_cbKhoa.Location = new System.Drawing.Point(64, 7);
            this.BieuDo_cbKhoa.Name = "BieuDo_cbKhoa";
            this.BieuDo_cbKhoa.Size = new System.Drawing.Size(159, 28);
            this.BieuDo_cbKhoa.TabIndex = 14;
            this.BieuDo_cbKhoa.SelectedValueChanged += new System.EventHandler(this.BieuDo_cbKhoa_SelectedValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 20);
            this.label9.TabIndex = 13;
            this.label9.Text = "Khoa:";
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.BieuDo_btReset);
            this.panel7.Controls.Add(this.BieuDo_btTaoBieuDo);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(964, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(109, 100);
            this.panel7.TabIndex = 0;
            // 
            // BieuDo_btReset
            // 
            this.BieuDo_btReset.AutoSize = true;
            this.BieuDo_btReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.BieuDo_btReset.Location = new System.Drawing.Point(0, 30);
            this.BieuDo_btReset.Name = "BieuDo_btReset";
            this.BieuDo_btReset.Size = new System.Drawing.Size(109, 30);
            this.BieuDo_btReset.TabIndex = 20;
            this.BieuDo_btReset.Text = "Reset";
            this.BieuDo_btReset.UseVisualStyleBackColor = true;
            this.BieuDo_btReset.Click += new System.EventHandler(this.BieuDo_btReset_Click);
            // 
            // BieuDo_btTaoBieuDo
            // 
            this.BieuDo_btTaoBieuDo.AutoSize = true;
            this.BieuDo_btTaoBieuDo.Dock = System.Windows.Forms.DockStyle.Top;
            this.BieuDo_btTaoBieuDo.Location = new System.Drawing.Point(0, 0);
            this.BieuDo_btTaoBieuDo.Name = "BieuDo_btTaoBieuDo";
            this.BieuDo_btTaoBieuDo.Size = new System.Drawing.Size(109, 30);
            this.BieuDo_btTaoBieuDo.TabIndex = 19;
            this.BieuDo_btTaoBieuDo.Text = "Tạo biểu đồ";
            this.BieuDo_btTaoBieuDo.UseVisualStyleBackColor = true;
            this.BieuDo_btTaoBieuDo.Click += new System.EventHandler(this.BieuDo_btTaoBieuDo_Click);
            // 
            // tbHocPhi
            // 
            this.tbHocPhi.Controls.Add(this.HocPhi_dgvHienThi);
            this.tbHocPhi.Controls.Add(this.panel3);
            this.tbHocPhi.Location = new System.Drawing.Point(4, 29);
            this.tbHocPhi.Name = "tbHocPhi";
            this.tbHocPhi.Padding = new System.Windows.Forms.Padding(3);
            this.tbHocPhi.Size = new System.Drawing.Size(1073, 601);
            this.tbHocPhi.TabIndex = 1;
            this.tbHocPhi.Text = "Học phí";
            this.tbHocPhi.UseVisualStyleBackColor = true;
            // 
            // HocPhi_dgvHienThi
            // 
            this.HocPhi_dgvHienThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HocPhi_dgvHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HocPhi_dgvHienThi.Location = new System.Drawing.Point(3, 67);
            this.HocPhi_dgvHienThi.Name = "HocPhi_dgvHienThi";
            this.HocPhi_dgvHienThi.Size = new System.Drawing.Size(1067, 531);
            this.HocPhi_dgvHienThi.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cbChuaNopHP);
            this.panel3.Controls.Add(this.HocPhi_cbLop);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.HocPhi_cbChuyenNganh);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.HocPhi_cbKhoa);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1067, 64);
            this.panel3.TabIndex = 0;
            // 
            // HocPhi_cbLop
            // 
            this.HocPhi_cbLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HocPhi_cbLop.FormattingEnabled = true;
            this.HocPhi_cbLop.Location = new System.Drawing.Point(646, 3);
            this.HocPhi_cbLop.Name = "HocPhi_cbLop";
            this.HocPhi_cbLop.Size = new System.Drawing.Size(159, 28);
            this.HocPhi_cbLop.TabIndex = 12;
            this.HocPhi_cbLop.SelectedValueChanged += new System.EventHandler(this.HocPhi_cbLop_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(600, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Lớp:";
            // 
            // HocPhi_cbChuyenNganh
            // 
            this.HocPhi_cbChuyenNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HocPhi_cbChuyenNganh.FormattingEnabled = true;
            this.HocPhi_cbChuyenNganh.Location = new System.Drawing.Point(369, 3);
            this.HocPhi_cbChuyenNganh.Name = "HocPhi_cbChuyenNganh";
            this.HocPhi_cbChuyenNganh.Size = new System.Drawing.Size(159, 28);
            this.HocPhi_cbChuyenNganh.TabIndex = 10;
            this.HocPhi_cbChuyenNganh.SelectedValueChanged += new System.EventHandler(this.HocPhi_cbChuyenNganh_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(247, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Chuyên ngành:";
            // 
            // HocPhi_cbKhoa
            // 
            this.HocPhi_cbKhoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HocPhi_cbKhoa.FormattingEnabled = true;
            this.HocPhi_cbKhoa.Location = new System.Drawing.Point(61, 3);
            this.HocPhi_cbKhoa.Name = "HocPhi_cbKhoa";
            this.HocPhi_cbKhoa.Size = new System.Drawing.Size(159, 28);
            this.HocPhi_cbKhoa.TabIndex = 8;
            this.HocPhi_cbKhoa.SelectedIndexChanged += new System.EventHandler(this.HocPhi_cbKhoa_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Khoa:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.HocPhi_btReset);
            this.panel4.Controls.Add(this.HocPhi_btXuatExcel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(947, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(120, 64);
            this.panel4.TabIndex = 0;
            // 
            // HocPhi_btReset
            // 
            this.HocPhi_btReset.AutoSize = true;
            this.HocPhi_btReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.HocPhi_btReset.Location = new System.Drawing.Point(0, 30);
            this.HocPhi_btReset.Name = "HocPhi_btReset";
            this.HocPhi_btReset.Size = new System.Drawing.Size(120, 30);
            this.HocPhi_btReset.TabIndex = 1;
            this.HocPhi_btReset.Text = "Reset";
            this.HocPhi_btReset.UseVisualStyleBackColor = true;
            this.HocPhi_btReset.Click += new System.EventHandler(this.HocPhi_btReset_Click);
            // 
            // HocPhi_btXuatExcel
            // 
            this.HocPhi_btXuatExcel.AutoSize = true;
            this.HocPhi_btXuatExcel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HocPhi_btXuatExcel.Location = new System.Drawing.Point(0, 0);
            this.HocPhi_btXuatExcel.Name = "HocPhi_btXuatExcel";
            this.HocPhi_btXuatExcel.Size = new System.Drawing.Size(120, 30);
            this.HocPhi_btXuatExcel.TabIndex = 0;
            this.HocPhi_btXuatExcel.Text = "Xuất file excel";
            this.HocPhi_btXuatExcel.UseVisualStyleBackColor = true;
            this.HocPhi_btXuatExcel.Click += new System.EventHandler(this.HocPhi_btXuatExcel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbHocPhi);
            this.tabControl1.Controls.Add(this.tbBieuDo);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1081, 634);
            this.tabControl1.TabIndex = 0;
            // 
            // cbChuaNopHP
            // 
            this.cbChuaNopHP.AutoSize = true;
            this.cbChuaNopHP.Location = new System.Drawing.Point(9, 37);
            this.cbChuaNopHP.Name = "cbChuaNopHP";
            this.cbChuaNopHP.Size = new System.Drawing.Size(152, 24);
            this.cbChuaNopHP.TabIndex = 13;
            this.cbChuaNopHP.Text = "Chưa nộp học phí";
            this.cbChuaNopHP.UseVisualStyleBackColor = true;
            this.cbChuaNopHP.CheckedChanged += new System.EventHandler(this.cbChuaNopHP_CheckedChanged);
            // 
            // fQuanLy_BaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1081, 634);
            this.Controls.Add(this.tabControl1);
            this.Name = "fQuanLy_BaoCao";
            this.Text = "fQuanLy_BaoCao";
            this.Load += new System.EventHandler(this.fQuanLy_BaoCao_Load);
            this.tbBieuDo.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BieuDo_Char)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.tbHocPhi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HocPhi_dgvHienThi)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tbBieuDo;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataVisualization.Charting.Chart BieuDo_Char;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox BieuDo_cbTypeBieuDo;
        private System.Windows.Forms.ComboBox BieuDo_cbLop;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox BieuDo_cbChuyenNganh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox BieuDo_cbKhoa;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Button BieuDo_btReset;
        private System.Windows.Forms.Button BieuDo_btTaoBieuDo;
        private System.Windows.Forms.TabPage tbHocPhi;
        private System.Windows.Forms.DataGridView HocPhi_dgvHienThi;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox HocPhi_cbLop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox HocPhi_cbChuyenNganh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox HocPhi_cbKhoa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button HocPhi_btReset;
        private System.Windows.Forms.Button HocPhi_btXuatExcel;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.CheckBox cbChuaNopHP;
    }
}