﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObject;
using BusinessLogicLayer;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy_MonHoc : Form
    {
        private MONHOC obj = new MONHOC();
        private MONHOCBUS bus = new MONHOCBUS();

        public fQuanLy_MonHoc()
        {
            InitializeComponent();
        }

        public void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData();
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Mã môn học";
            dgvHienThi.Columns[1].HeaderText = "Mã chuyên ngành";
            dgvHienThi.Columns[2].HeaderText = "Tên môn học";
            dgvHienThi.Columns[3].HeaderText = "Tên học kỳ";
            dgvHienThi.Columns[4].HeaderText = "Số tín chỉ";
        }

        public void addDataComboBox(object sender, EventArgs e)
        {
            //combobox Chuyen Nganh
            CHUYENNGANHBUS temp = new CHUYENNGANHBUS();
            DataTable dt = new DataTable();
            dt = temp.GetData();

            foreach (DataRow row in dt.Rows)
            {
                cbMaCN.Items.Add(row[0].ToString());
            }
            cbMaCN.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaCN.AutoCompleteSource = AutoCompleteSource.ListItems;
            //combobox Hoc ky
            cbHocKy.Items.Add("1");
            cbHocKy.Items.Add("2");
            cbHocKy.Items.Add("3");
            cbHocKy.Items.Add("4");
            cbHocKy.Items.Add("5");
        }
        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaMH.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            cbMaCN.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            txbTenMH.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
            cbHocKy.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
            txbSoTC.Text = dgvHienThi.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void fAdmin_MonHoc_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MAMH = txbMaMH.Text;
            obj.MACN = cbMaCN.Text;
            obj.TENMH = txbTenMH.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            obj.SOTINCHI = int.Parse(txbSoTC.Text);
            if (bus.GetData(txbMaMH.Text).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã môn học đã tồn tại, vui lòng nhập mã môn học khác", "Thông báo");
                txbMaMH.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj.MAMH = txbMaMH.Text;
            obj.MACN = cbMaCN.Text;
            obj.TENMH = txbTenMH.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            obj.SOTINCHI = int.Parse(txbSoTC.Text);
            if (bus.GetData(txbMaMH.Text).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã môn học không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaMH.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(txbMaMH.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa môn học này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(txbMaMH.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã môn học không tồn tại, vui lòng nhập mã môn học khác", "Thông báo");
                txbMaMH.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaMH.Text = "";
            cbMaCN.Text = "";
            txbTenMH.Text = "";
            cbHocKy.Text = "";
            txbSoTC.Text = "";
        }
    }
}