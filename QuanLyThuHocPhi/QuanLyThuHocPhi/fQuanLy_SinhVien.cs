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
        private SINHVIEN obj_SV = new SINHVIEN();
        private NGUOIDUNG obj_ND = new NGUOIDUNG();
        private SINHVIENBUS bus_SV = new SINHVIENBUS();
        private NGUOIDUNGBUS bus_ND = new NGUOIDUNGBUS();
        public fQuanLy_SinhVien()
        {
            InitializeComponent();
        }

        public void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus_SV.GetData();
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã sinh viên";
            dgvHienThi.Columns[1].HeaderText = "Họ sinh viên";
            dgvHienThi.Columns[2].HeaderText = "Tên sinh viên";
            dgvHienThi.Columns[3].HeaderText = "Mã lớp";
            dgvHienThi.Columns[4].HeaderText = "Giới tính";
            dgvHienThi.Columns[5].HeaderText = "Ngày sinh";
            dgvHienThi.Columns[6].HeaderText = "Địa chỉ";
            dgvHienThi.Columns[7].HeaderText = "Đang nghỉ học";
            dgvHienThi.Columns[8].HeaderText = "Tên tài khoản";
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaSV.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbHoSV.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            txbTenSV.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
            txbDiaChi.Text = dgvHienThi.SelectedRows[0].Cells[6].Value.ToString();
            txbMaSV.Text = dgvHienThi.SelectedRows[0].Cells[8].Value.ToString();
            if (bool.Parse(dgvHienThi.SelectedRows[0].Cells[4].Value.ToString()) == true)
            {
                rdbNu.Checked = true;
            }
            else
            {
                rdbNam.Checked = true;
            }
            if (bool.Parse(dgvHienThi.SelectedRows[0].Cells[7].Value.ToString()) == true)
            {
                rdbTrue.Checked = true;
            }
            else
            {
                rdbFalse.Checked = true;
            }
            dtpNgaySinh.Value = DateTime.Parse(dgvHienThi.SelectedRows[0].Cells[5].Value.ToString());
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
        }

        private void fAdmin_SinhVien_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            //Gán dữ liệu cho obj_SV
            obj_SV.MASV = txbMaSV.Text;
            obj_SV.HO = txbHoSV.Text;
            obj_SV.TEN = txbTenSV.Text;
            obj_SV.DIACHI = txbDiaChi.Text;
            obj_SV.TENTAIKHOAN = txbMaSV.Text;
            if (rdbNam.Checked == true)
            {
                obj_SV.PHAI = false;
            }
            if (rdbNu.Checked == true)
            {
                obj_SV.PHAI = true;
            }
            if (rdbTrue.Checked == true)
            {
                obj_SV.DANGNGHIHOC = true;
            }
            if (rdbFalse.Checked == true)
            {
                obj_SV.DANGNGHIHOC = false;
            }
            obj_SV.NGAYSINH = dtpNgaySinh.Value;
            obj_SV.MALOP = cbMaLop.Text;
            //Gán dữ liệu cho obj người dùng
            obj_ND.TENTAIKHOAN = txbMaSV.Text.ToString();
            obj_ND.MATKHAU = "1";
            obj_ND.QUYEN = "User";
            if (bus_SV.GetData(txbMaSV.Text).Rows.Count == 0)
            {
                bus_ND.Insert(obj_ND);
                bus_SV.Insert(obj_SV);
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
            obj_SV.MASV = txbMaSV.Text;
            obj_SV.HO = txbHoSV.Text; ;
            obj_SV.TEN = txbTenSV.Text;
            obj_SV.DIACHI = txbDiaChi.Text;
            obj_SV.TENTAIKHOAN = txbMaSV.Text;
            if (rdbNam.Checked == true)
            {
                obj_SV.PHAI = false;
            }
            if (rdbNu.Checked == true)
            {
                obj_SV.PHAI = true;
            }
            if (rdbTrue.Checked == true)
            {
                obj_SV.DANGNGHIHOC = true;
            }
            if (rdbFalse.Checked == true)
            {
                obj_SV.DANGNGHIHOC = false;
            }
            obj_SV.NGAYSINH = dtpNgaySinh.Value;
            obj_SV.MALOP = cbMaLop.Text;
            if (bus_SV.GetData(txbMaSV.Text).Rows.Count != 0)
            {
                bus_SV.Update(obj_SV);
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
            if (bus_SV.GetData(txbMaSV.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa sinh viên này không?", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus_SV.Delete(txbMaSV.Text);
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
            txbMaSV.Text = "";
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            rdbTrue.Checked = false;
            rdbFalse.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            cbMaLop.Text = "";
        }
    }
}
