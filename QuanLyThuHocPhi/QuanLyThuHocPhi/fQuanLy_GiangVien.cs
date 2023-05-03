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
    public partial class fQuanLy_GiangVien : Form
    {
        private GIANGVIEN obj = new GIANGVIEN();
        private GIANGVIENBUS bus = new GIANGVIENBUS();

        public fQuanLy_GiangVien()
        {
            InitializeComponent();
        }

        public void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData();
            dgvHienThi.ReadOnly = true;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Mã giảng viên";
            dgvHienThi.Columns[1].HeaderText = "Mã khoa";
            dgvHienThi.Columns[2].HeaderText = "Họ giảng viên";
            dgvHienThi.Columns[3].HeaderText = "Tên giảng viên";
            dgvHienThi.Columns[4].HeaderText = "Học hàm";
        }

        public void addDataComboBox(object sender, EventArgs e)
        {
            //ComboBox Ma Khoa
            KHOABUS temp = new KHOABUS();
            DataTable tb = new DataTable();
            tb = temp.GetData();
            foreach(DataRow row in tb.Rows)
            {
                cbMaKhoa.Items.Add(row[0].ToString());
            }
            cbMaKhoa.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;
            //ComboBox Hoc Ham
            cbHocHam.Items.Add("Tiến Sĩ");
            cbHocHam.Items.Add("Thạc Sĩ");
            cbHocHam.Items.Add("Giáo Sư");
            cbHocHam.Items.Add("P.Giáo sư");
            cbHocHam.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbHocHam.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaGV.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            cbMaKhoa.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            txbHoGV.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
            txbTenGV.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
            cbHocHam.Text = dgvHienThi.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void fAdmin_GiangVien_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MAGV = txbMaGV.Text;
            obj.MAKHOA = cbMaKhoa.Text;
            obj.HO = txbHoGV.Text;
            obj.TEN = txbTenGV.Text;
            obj.HOCHAM = cbHocHam.Text;
            if (bus.GetData(txbMaGV.Text).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã giảng viên đã tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaGV.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj.MAGV = txbMaGV.Text;
            obj.MAKHOA = cbMaKhoa.Text;
            obj.HO = txbHoGV.Text;
            obj.TEN = txbTenGV.Text;
            obj.HOCHAM = cbHocHam.Text;
            if (bus.GetData(txbMaGV.Text).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã giảng viên không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaGV.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(txbMaGV.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa giảng viên này không?", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(txbMaGV.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã lớp không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaGV.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaGV.Text = "";
            cbMaKhoa.Text = "";
            txbHoGV.Text = "";
            txbTenGV.Text = "";
            cbHocHam.Text = "";
        }
    }
}
