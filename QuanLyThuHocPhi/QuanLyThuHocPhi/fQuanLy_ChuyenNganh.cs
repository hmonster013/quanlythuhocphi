﻿using BusinessLogicLayer;
using System;
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
    public partial class fQuanLy_ChuyenNganh : Form
    {
        private CHUYENNGANH obj = new CHUYENNGANH();
        private CHUYENNGANHBUS bus = new CHUYENNGANHBUS();

        public fQuanLy_ChuyenNganh()
        {
            InitializeComponent();
        }

        public void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData();
            dgvHienThi.ReadOnly = true;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Mã chuyên ngành";
            dgvHienThi.Columns[1].HeaderText = "Tên chuyên ngành";
            dgvHienThi.Columns[2].HeaderText = "Mã khoa";
        }

        public void addDataComboBox(object sender, EventArgs e)
        {
            //ComboBox Ma Khoa
            KHOABUS temp = new KHOABUS();
            DataTable tb = new DataTable();
            tb = temp.GetData();
            foreach (DataRow row in tb.Rows)
            {
                cbMaKhoa.Items.Add(row[0].ToString());
            }
            cbMaKhoa.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaCN.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbTenCN.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            cbMaKhoa.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void fQuanLy_ChuyenNganh_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MACN = txbMaCN.Text;
            obj.TENCN = txbTenCN.Text;
            obj.MAKHOA = cbMaKhoa.Text;
            if (bus.GetData(txbMaCN.Text).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã chuyên ngành đã tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaCN.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj.MACN = txbMaCN.Text;
            obj.TENCN = txbTenCN.Text;
            obj.MAKHOA = cbMaKhoa.Text;
            if (bus.GetData(txbMaCN.Text).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã chuyên ngành không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaCN.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(txbMaCN.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa chuyên ngành này không?", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(txbMaCN.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã lớp không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaCN.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaCN.Text = "";
            txbTenCN.Text = "";
            cbMaKhoa.Text = "";
        }
    }
}