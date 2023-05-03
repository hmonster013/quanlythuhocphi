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
    public partial class fAdmin_Lop : Form
    {
        private LOP obj = new LOP();
        private LOPBUS bus = new LOPBUS();

        public fAdmin_Lop()
        {
            InitializeComponent();
        }

        public void addDataComboBox(object sender, EventArgs e)
        {
            KHOABUS temp = new KHOABUS();
            DataTable dt = new DataTable();
            dt = temp.GetData();

            foreach (DataRow row in dt.Rows)
            {
                cbMaKhoa.Items.Add(row[0].ToString());
            }
        }

        public void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData();
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Mã lớp";
            dgvHienThi.Columns[1].HeaderText = "Chuyên ngành";
            dgvHienThi.Columns[2].HeaderText = "Mã khoa";
        }

        private void fAdmin_Lop_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaLop.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbChuyenNganh.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            cbMaKhoa.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MALOP = txbMaLop.Text;
            obj.CHUYENNGANH = txbChuyenNganh.Text;
            obj.MAKHOA = cbMaKhoa.Text;
            if (bus.GetData(txbMaLop.Text).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }else
            {
                MessageBox.Show("Mã lớp đã tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaLop.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj.MALOP = txbMaLop.Text;
            obj.CHUYENNGANH = txbChuyenNganh.Text;
            obj.MAKHOA = cbMaKhoa.Text;
            if (bus.GetData(txbMaLop.Text).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã lớp không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaLop.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(txbMaLop.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa lớp này không?", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(txbMaLop.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã lớp không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaLop.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaLop.Text = "";
            txbChuyenNganh.Text = "";
            cbMaKhoa.Text = "";
        }
    }
}
