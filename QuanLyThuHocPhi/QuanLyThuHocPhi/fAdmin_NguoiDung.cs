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
    public partial class fAdmin_NguoiDung : Form
    {
        private NGUOIDUNG obj = new NGUOIDUNG();
        private NGUOIDUNGBUS bus = new NGUOIDUNGBUS();
        public fAdmin_NguoiDung()
        {
            InitializeComponent();
        }

        private void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData();
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Tên tài khoản";
            dgvHienThi.Columns[1].HeaderText = "Mật khẩu";
            dgvHienThi.Columns[2].HeaderText = "Quyền";
        }

        private void addDataComboBox(object sender, EventArgs e)
        {
            cbQuyen.Items.Add("Admin");
            cbQuyen.Items.Add("QuanLy");
            cbQuyen.Items.Add("User");
        }
        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbTenTK.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbMatKhau.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            cbQuyen.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void fAdmin_NguoiDung_Load(object sender, EventArgs e)
        {
            load_dgvHienThi(sender, e);
            addDataComboBox(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.TENTAIKHOAN = txbTenTK.Text;
            obj.MATKHAU = txbMatKhau.Text;
            obj.QUYEN = cbQuyen.Text;
            if (bus.GetData(txbTenTK.Text).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại, vui lòng nhập lại", "Thông báo");
                txbTenTK.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj.TENTAIKHOAN = txbTenTK.Text;
            obj.MATKHAU = txbMatKhau.Text;
            obj.QUYEN = cbQuyen.Text;
            if (bus.GetData(txbTenTK.Text).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Tên tài khoản không tồn tại, vui lòng nhập lại", "Thông báo");
                txbTenTK.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(txbTenTK.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa tài khoản này không?", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(txbTenTK.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã lớp không tồn tại, vui lòng nhập lại", "Thông báo");
                txbTenTK.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbTenTK.Text = "";
            txbMatKhau.Text = "";
            cbQuyen.Text = "";
        }
    }
}
