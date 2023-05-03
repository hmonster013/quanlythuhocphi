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
    public partial class fAdmin_MonHoc : Form
    {
        private MONHOC obj = new MONHOC();
        private MONHOCBUS bus = new MONHOCBUS();

        public fAdmin_MonHoc()
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
            dgvHienThi.Columns[1].HeaderText = "Tên môn học";
            dgvHienThi.Columns[2].HeaderText = "Số tín chỉ";
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaMH.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbTenMH.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            txbSoTC.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void fAdmin_MonHoc_Load(object sender, EventArgs e)
        {
            load_dgvHienThi(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MAMH = txbMaMH.Text;
            obj.TENMH = txbTenMH.Text;
            obj.SOTINCHI = int.Parse(txbSoTC.Text.ToString());
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
            obj.TENMH = txbTenMH.Text;
            obj.SOTINCHI = int.Parse(txbSoTC.Text.ToString());
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
            txbTenMH.Text = "";
            txbSoTC.Text = "";
        }
    }
}
