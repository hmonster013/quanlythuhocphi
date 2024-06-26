﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;
using ValueObject.DangKy;

namespace QuanLyThuHocPhi
{
    public partial class fSinhVien_DangKy : Form
    {
        private string MASV;
        private DANGKY obj = new DANGKY();
        private DANGKYBUS bus = new DANGKYBUS();
        public fSinhVien_DangKy()
        {
            InitializeComponent();
        }

        public fSinhVien_DangKy(string MASV)
        {
            this.MASV = MASV;
            InitializeComponent();
        }

        public void addDataComboBox()
        {
            //ComboBox Hoc ky
            cbHocKy.Items.Add("1");
            cbHocKy.Items.Add("2");
            cbHocKy.Items.Add("3");
            cbHocKy.Items.Add("4");
            cbHocKy.Items.Add("5");
            cbHocKy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbHocKy.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public async void load_dgvHienThi()
        {
            dgvHienThi.DataSource = await bus.GetDataByMASV(MASV);
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã đăng ký";
            dgvHienThi.Columns[1].HeaderText = "Mã sinh viên";
            dgvHienThi.Columns[2].HeaderText = "Học kỳ";
            // Tạo cột DataGridViewButtonColumn mới
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "btChiTiet";
            buttonColumn.HeaderText = "";
            // Sử dụng Text của Column làm Text của Button
            buttonColumn.UseColumnTextForButtonValue = true; 
            buttonColumn.Text = "Chi tiết";
            // Thêm cột mới vào DataGridView
            dgvHienThi.Columns.Add(buttonColumn);
        }

        public void settingMaDK()
        {
            txbMaSV.Text = MASV;
            txbMaSV.ReadOnly = true;
        }

        private void dgvHienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHienThi.Columns[e.ColumnIndex].Name == "btChiTiet")
            {
                obj.MADK = int.Parse(dgvHienThi.Rows[e.RowIndex].Cells[0].Value.ToString());
                obj.MASV = dgvHienThi.Rows[e.RowIndex].Cells[1].Value.ToString();
                obj.HOCKY = int.Parse(dgvHienThi.Rows[e.RowIndex].Cells[2].Value.ToString());
                fSinhVien_ChiTietDangKy temp = new fSinhVien_ChiTietDangKy(obj);
                temp.ShowDialog();
            }
        }

        private void fSinhVien_DangKy_Load(object sender, EventArgs e)
        {
            addDataComboBox();
            load_dgvHienThi();
            settingMaDK();
        }

        private async void btDangKy_Click(object sender, EventArgs e)
        {
            if (await bus.GetDataByMASVandHOCKY(txbMaSV.Text, int.Parse(cbHocKy.Text)) == null)
            {
                await bus.Insert(obj);
                settingMaDK();
                dgvHienThi.DataSource = await bus.GetDataByMASV(MASV);
                //Mo bang them chi tiet dang ky
                fSinhVien_ThemCTDK ftemp = new fSinhVien_ThemCTDK(obj);
                ftemp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Học kỳ đã được đăng ký, vui lòng chọn lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
