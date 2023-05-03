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
using DataAccessLayer;
using System.Data.SqlClient;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy_Khoa : Form
    {
        KHOA obj = new KHOA();
        KHOABUS bus = new KHOABUS();
        
        public fQuanLy_Khoa()
        {
            InitializeComponent();
        }

        private void fAdmin_Khoa_Load(object sender, EventArgs e)
        {
            load_dgvHienThi(sender, e);
        }

        private void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData();
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Mã khoa";
            dgvHienThi.Columns[1].HeaderText = "Tên khoa";
            dgvHienThi.Columns[2].HeaderText = "Đơn giá";
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaKhoa.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbTenKhoa.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            txbGTTC.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MAKHOA = txbMaKhoa.Text;
            obj.TENKHOA = txbTenKhoa.Text;
            obj.DONGIA = int.Parse(txbGTTC.Text.ToString());
            if (bus.GetData(txbMaKhoa.Text).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã khoa đã tồn tại, vui lòng nhập mã khoa khác", "Thông báo");
                txbMaKhoa.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj.MAKHOA = txbMaKhoa.Text;
            obj.TENKHOA = txbTenKhoa.Text;
            obj.DONGIA = int.Parse(txbGTTC.Text.ToString());
            if (bus.GetData(txbMaKhoa.Text).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã khoa không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaKhoa.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(txbMaKhoa.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa khoa này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(txbMaKhoa.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã khoa không tồn tại, vui lòng nhập mã khoa khác", "Thông báo");
                txbMaKhoa.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaKhoa.Text = "";
            txbTenKhoa.Text = "";
            txbGTTC.Text = "";
        }
    }
}
