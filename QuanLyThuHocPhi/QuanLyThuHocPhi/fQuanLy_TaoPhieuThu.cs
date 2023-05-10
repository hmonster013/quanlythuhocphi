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
    public partial class fQuanLy_TaoPhieuThu : Form
    {
        private PHIEUTHU obj = new PHIEUTHU();
        private PHIEUTHUBUS bus_PT = new PHIEUTHUBUS();
        private XULYHOCPHIBUS bus_XLHP = new XULYHOCPHIBUS();
        public fQuanLy_TaoPhieuThu()
        {
            InitializeComponent();
        }

        public void load_dgvHienThi()
        {
            dgvHienThi.DataSource = bus_PT.GetData();
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã phiếu thu";
            dgvHienThi.Columns[1].HeaderText = "Mã sinh viên";
            dgvHienThi.Columns[2].HeaderText = "Niên khóa";
            dgvHienThi.Columns[3].HeaderText = "Học kỳ";
            dgvHienThi.Columns[4].HeaderText = "Ngày đóng";
            dgvHienThi.Columns[5].HeaderText = "Số tiền đóng";
        }

        public void addDataComboBox()
        {
            //add data cbHocKy
            cbHocKy.Items.Add("1");
            cbHocKy.Items.Add("2");
            cbHocKy.Items.Add("3");
            cbHocKy.Items.Add("4");
            cbHocKy.Items.Add("5");
            cbHocKy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbHocKy.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void settingTextBox() 
        { 
            txbMaPT.Text = bus_PT.GetDataSTTPT().Rows[0].ItemArray[0].ToString();
        }

        private void fQuanLy_TaoPhieuThu_Load(object sender, EventArgs e)
        {
            settingTextBox();
            addDataComboBox();
            load_dgvHienThi();
        }

        private void btKiemTra_Click(object sender, EventArgs e)
        {
            lbPhaiDong.Text = "Số tiền phải đóng: " + bus_XLHP.GetDataHocPhi(txbMaSV.Text, int.Parse(cbHocKy.Text)).Rows[0].ItemArray[4].ToString() + "vnđ";
            lbDaDong.Text = "Số tiền đã đóng: " + bus_XLHP.GetDataHocPhi(txbMaSV.Text, int.Parse(cbHocKy.Text)).Rows[0].ItemArray[5].ToString() + "vnđ";
            lbChuaDong.Text = "Số tiền chưa đóng: " + bus_XLHP.GetDataHocPhi(txbMaSV.Text, int.Parse(cbHocKy.Text)).Rows[0].ItemArray[6].ToString() + "vnđ";
            dgvHienThi.DataSource = bus_PT.GetDataByMaSVandHK(txbMaSV.Text, int.Parse(cbHocKy.Text));
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MAPT = int.Parse(txbMaPT.Text);
            obj.MASV = txbMaSV.Text;
            obj.NIENKHOA = txbNienKhoa.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            obj.NGAYDONG = dtpNgayDong.Value;
            obj.SOTIENDONG = float.Parse(txbSoTienDong.Text);
            if (bus_PT.GetDataByMaSVandHK(txbMaSV.Text, int.Parse(cbHocKy.Text)).Rows.Count == 0)
            {
                bus_PT.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi();
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
            }
        }

        private void btSửa_Click(object sender, EventArgs e)
        {
            obj.MAPT = int.Parse(txbMaPT.Text);
            obj.MASV = txbMaSV.Text;
            obj.NIENKHOA = txbNienKhoa.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            obj.NGAYDONG = dtpNgayDong.Value;
            obj.SOTIENDONG = float.Parse(txbSoTienDong.Text);
            if (bus_PT.GetData(int.Parse(txbMaPT.Text)).Rows.Count != 0)
            {
                bus_PT.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi();
            }
            else
            {
                MessageBox.Show("Mã phiếu thu không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaPT.Focus();
            }
        }

        private void btXóa_Click(object sender, EventArgs e)
        {
            if (bus_PT.GetData(int.Parse(txbMaPT.Text)).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa lớp này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus_PT.Delete(int.Parse(txbMaPT.Text));
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi();
                }
            }
            else
            {
                MessageBox.Show("Mã phiếu thu không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaPT.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaPT.Text = "";
            txbMaSV.Text = "";
            txbNienKhoa.Text = "";
            cbHocKy.Text = "";
            dtpNgayDong.Value = DateTime.Now;
            txbSoTienDong.Text = "";
            load_dgvHienThi();
        }

        private void btDongThemTien_Click(object sender, EventArgs e)
        {
            obj.MAPT = int.Parse(txbMaPT.Text);
            obj.MASV = txbMaSV.Text;
            obj.NIENKHOA = txbNienKhoa.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            obj.NGAYDONG = dtpNgayDong.Value;
            obj.SOTIENDONG = float.Parse(txbSoTienDong.Text) + float.Parse(bus_PT.GetData(int.Parse(txbMaPT.Text)).Rows[0].ItemArray[5].ToString());
            if (bus_PT.GetData(int.Parse(txbMaPT.Text)).Rows.Count != 0)
            {
                bus_PT.Update(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                btKiemTra_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Mã phiếu thu không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaPT.Focus();
            }
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaPT.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbMaSV.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            txbNienKhoa.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
            cbHocKy.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
            dtpNgayDong.Value = DateTime.Parse(dgvHienThi.SelectedRows[0].Cells[4].Value.ToString());
            txbSoTienDong.Text = dgvHienThi.SelectedRows[0].Cells[5].Value.ToString();
        }

    }
}
