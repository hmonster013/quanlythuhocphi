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
    public partial class fQuanLy_CTPhieuThu : Form
    {
        private PHIEUTHU obj_PT = new PHIEUTHU();
        private CTPHIEUTHU obj_CTPT = new CTPHIEUTHU();
        private CTPHIEUTHUBUS bus_CTPT = new CTPHIEUTHUBUS();
        private XULYHOCPHIBUS bus_XLHP = new XULYHOCPHIBUS();
        public fQuanLy_CTPhieuThu()
        {
            InitializeComponent();
        }

        public fQuanLy_CTPhieuThu(PHIEUTHU obj_PT)
        {
            this.obj_PT = obj_PT;
            InitializeComponent();
        }
        
        public void load_dgvHienThi()
        {
            dgvHienThi.DataSource = bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã chi tiết phiếu thu";
            dgvHienThi.Columns[1].HeaderText = "Mã phiếu thu";
            dgvHienThi.Columns[2].HeaderText = "Ngày đóng";
            dgvHienThi.Columns[3].HeaderText = "Số tiền đóng";
        }

        public void settingTextBox() 
        { 
            txbMaCTPT.Text = bus_CTPT.GetDataSTTCTPT().Rows[0].ItemArray[0].ToString();
            txbMaPT.Text = obj_PT.MAPT.ToString();
            txbMaCTPT.ReadOnly = true;
            txbMaPT.ReadOnly = true;
            txbSTDaDong.ReadOnly = true;
            txbSTChuaDong.ReadOnly = true;
            txbSTPhaiDong.ReadOnly = true;
        }

        public void settingLabel()
        {
            lbHienThi.Text += obj_PT.HOCKY.ToString();
        }

        private void fQuanLy_CTPhieuThu_Load(object sender, EventArgs e)
        {
            settingTextBox();
            settingLabel();
            load_dgvHienThi();
        }
        
        private void btKiemTra_Click(object sender, EventArgs e)
        {
            if (bus_XLHP.GetDataByHOCKY(obj_PT.MASV, obj_PT.HOCKY).Rows.Count != 0)
            {
                txbSTPhaiDong.Text = bus_XLHP.GetDataByHOCKY(obj_PT.MASV, obj_PT.HOCKY).Rows[0].ItemArray[5].ToString();
                txbSTDaDong.Text = bus_XLHP.GetDataByHOCKY(obj_PT.MASV, obj_PT.HOCKY).Rows[0].ItemArray[6].ToString();
                txbSTChuaDong.Text = bus_XLHP.GetDataByHOCKY(obj_PT.MASV, obj_PT.HOCKY).Rows[0].ItemArray[7].ToString();
                dgvHienThi.DataSource = bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu về học phí trong học kỳ này", "Thông báo");
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj_CTPT.MACTPT = int.Parse(txbMaCTPT.Text);
            obj_CTPT.MAPT = int.Parse(txbMaPT.Text);
            obj_CTPT.NGAYDONG = dtpNgayDong.Value;
            obj_CTPT.SOTIENDONG = float.Parse(txbSoTienDong.Text);
            if (bus_CTPT.GetData(int.Parse(txbMaCTPT.Text)).Rows.Count == 0)
            {
                bus_CTPT.Insert(obj_CTPT);
                MessageBox.Show("Thêm thành công", "Thông báo");
                dgvHienThi.DataSource = bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
                btKiemTra_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
            }
        }

        private void btSửa_Click(object sender, EventArgs e)
        {
            obj_CTPT.MACTPT = int.Parse(txbMaCTPT.Text);
            obj_CTPT.MAPT = int.Parse(txbMaPT.Text);
            obj_CTPT.NGAYDONG = dtpNgayDong.Value;
            obj_CTPT.SOTIENDONG = float.Parse(txbSoTienDong.Text);
            if (bus_CTPT.GetData(int.Parse(txbMaCTPT.Text)).Rows.Count != 0)
            {
                bus_CTPT.Update(obj_CTPT);
                MessageBox.Show("Sửa thành công", "Thông báo");
                dgvHienThi.DataSource = bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
                btKiemTra_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Mã phiếu thu không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaPT.Focus();
            }
        }

        private void btXóa_Click(object sender, EventArgs e)
        {
            if (bus_CTPT.GetData(int.Parse(txbMaCTPT.Text)).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa lớp này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus_CTPT.Delete(int.Parse(txbMaCTPT.Text));
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    dgvHienThi.DataSource = bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
                    btKiemTra_Click(sender, e);
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
            txbMaCTPT.Text = "";
            txbMaPT.Text = "";
            dtpNgayDong.Value = DateTime.Now;
            txbSoTienDong.Text = "";
            txbSTPhaiDong.Text = "";
            txbSTDaDong.Text = "";
            txbSTChuaDong.Text = "";
            settingTextBox();
            dgvHienThi.DataSource = bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaCTPT.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbMaPT.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            dtpNgayDong.Value = DateTime.Parse(dgvHienThi.SelectedRows[0].Cells[2].Value.ToString());
            txbSoTienDong.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
