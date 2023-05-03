using BusinessLogicLayer;
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
    public partial class fQuanLy_SinhVien : Form
    {
        private SINHVIEN obj = new SINHVIEN();
        private SINHVIENBUS bus = new SINHVIENBUS();
        public fQuanLy_SinhVien()
        {
            InitializeComponent();
        }

        public void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData();
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã sinh viên";
            dgvHienThi.Columns[1].HeaderText = "Họ sinh viên";
            dgvHienThi.Columns[2].HeaderText = "Tên sinh viên";
            dgvHienThi.Columns[3].HeaderText = "Mã lớp";
            dgvHienThi.Columns[4].HeaderText = "Mã khoa";
            dgvHienThi.Columns[5].HeaderText = "Giới tính";
            dgvHienThi.Columns[6].HeaderText = "Ngày sinh";
            dgvHienThi.Columns[7].HeaderText = "Địa chỉ";
            dgvHienThi.Columns[8].HeaderText = "Đang nghỉ học";
            dgvHienThi.Columns[9].HeaderText = "Tên tài khoản";
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaSV.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbHoSV.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            txbTenSV.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
            txbDiaChi.Text = dgvHienThi.SelectedRows[0].Cells[7].Value.ToString();
            txbTenTK.Text = dgvHienThi.SelectedRows[0].Cells[9].Value.ToString();
            if (bool.Parse(dgvHienThi.SelectedRows[0].Cells[5].Value.ToString()) == true)
            {
                rdbNu.Checked = true;
            }
            else
            {
                rdbNam.Checked = true;
            }
            if (bool.Parse(dgvHienThi.SelectedRows[0].Cells[8].Value.ToString()) == true)
            {
                rdbTrue.Checked = true;
            }
            else
            {
                rdbFalse.Checked = true;
            }
            dtpNgaySinh.Value = DateTime.Parse(dgvHienThi.SelectedRows[0].Cells[6].Value.ToString());
            cbMaKhoa.Text = dgvHienThi.SelectedRows[0].Cells[4].Value.ToString();
            cbMaLop.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void addDataComboBox(object sender, EventArgs e)
        {
            LOPBUS tempLop = new LOPBUS();
            KHOABUS tempKhoa = new KHOABUS();
            DataTable dtLop = tempLop.GetData();
            DataTable dtKhoa = tempKhoa.GetData();
            //ComboBox Ma Lop
            foreach (DataRow row in dtLop.Rows)
            {
                cbMaLop.Items.Add(row[0].ToString());
            }
            cbMaLop.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaLop.AutoCompleteSource = AutoCompleteSource.ListItems;
            //ComboBox Ma Khoa
            foreach (DataRow row in dtKhoa.Rows)
            {
                cbMaKhoa.Items.Add(row[0].ToString());
            }
            cbMaKhoa.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void fAdmin_SinhVien_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MASV = txbMaSV.Text;
            obj.HO = txbHoSV.Text; ;
            obj.TEN = txbTenSV.Text;
            obj.DIACHI = txbDiaChi.Text;
            obj.TENTAIKHOAN = txbTenTK.Text;
            if (rdbNam.Checked == true)
            {
                obj.PHAI = false;
            }
            if (rdbNu.Checked == true)
            {
                obj.PHAI = true;
            }
            if (rdbTrue.Checked == true)
            {
                obj.DANGNGHIHOC = true;
            }
            if (rdbFalse.Checked == true)
            {
                obj.DANGNGHIHOC = false;
            }
            obj.NGAYSINH = dtpNgaySinh.Value;
            obj.MAKHOA = cbMaKhoa.Text;
            obj.MALOP = cbMaLop.Text;
            if (bus.GetData(txbMaSV.Text).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã sinh viên đã tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaSV.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj.MASV = txbMaSV.Text;
            obj.HO = txbHoSV.Text; ;
            obj.TEN = txbTenSV.Text;
            obj.DIACHI = txbDiaChi.Text;
            obj.TENTAIKHOAN = txbTenTK.Text;
            if (rdbNam.Checked == true)
            {
                obj.PHAI = false;
            }
            if (rdbNu.Checked == true)
            {
                obj.PHAI = true;
            }
            if (rdbTrue.Checked == true)
            {
                obj.DANGNGHIHOC = true;
            }
            if (rdbFalse.Checked == true)
            {
                obj.DANGNGHIHOC = false;
            }
            obj.NGAYSINH = dtpNgaySinh.Value;
            obj.MAKHOA = cbMaKhoa.Text;
            obj.MALOP = cbMaLop.Text;
            if (bus.GetData(txbMaSV.Text).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã sinh viên không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaSV.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(txbMaSV.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa sinh viên này không?", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(txbMaSV.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã sinh viên không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaSV.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaSV.Text = "";
            txbHoSV.Text = "";
            txbTenSV.Text = "";
            txbDiaChi.Text = "";
            txbTenTK.Text = "";
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            rdbTrue.Checked = false;
            rdbFalse.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            cbMaKhoa.Text = "";
            cbMaLop.Text = "";
        }
    }
}
