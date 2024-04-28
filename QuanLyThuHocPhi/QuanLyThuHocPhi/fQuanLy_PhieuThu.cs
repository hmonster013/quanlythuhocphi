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
using ValueObject.PhieuThu;
using ValueObject.XuLyHocPhi;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy_PhieuThu : Form
    {
        private PHIEUTHU obj = new PHIEUTHU();
        private PHIEUTHUBUS bus_PT = new PHIEUTHUBUS();
        private XULYHOCPHIBUS bus_XLHP = new XULYHOCPHIBUS();
        private SINHVIENBUS bus_SV = new SINHVIENBUS();
        public fQuanLy_PhieuThu()
        {
            InitializeComponent();
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
            txbTongHocPhi.ReadOnly = true;
            txbTongChuaDong.ReadOnly = true;
            txbTongDaDong.ReadOnly = true;
        }

        public async void load_dgvHienThi()
        {
            dgvHienThi.DataSource = await bus_PT.GetData();
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns["MAPT"].HeaderText = "Mã phiếu thu";
            dgvHienThi.Columns["MASV"].HeaderText = "Mã sinh viên";
            dgvHienThi.Columns["NIENKHOA"].HeaderText = "Niên khóa";
            dgvHienThi.Columns["HOCKY"].HeaderText = "Học kỳ";

            DataGridViewButtonColumn btChiTiet = new DataGridViewButtonColumn();
            btChiTiet.Name = "btChiTiet";
            btChiTiet.HeaderText = "";
            btChiTiet.Text = "Chi tiết";
            btChiTiet.UseColumnTextForButtonValue = true;
            dgvHienThi.Columns.Add(btChiTiet);
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaPT.Text = dgvHienThi.SelectedRows[0].Cells["MAPT"].Value.ToString();
            txbMaSV.Text = dgvHienThi.SelectedRows[0].Cells["MASV"].Value.ToString();
            txbNienKhoa.Text = dgvHienThi.SelectedRows[0].Cells["NIENKHOA"].Value.ToString();
            cbHocKy.Text = dgvHienThi.SelectedRows[0].Cells["HOCKY"].Value.ToString();
        }

        private void fQuanLy_PhieuThu_Load(object sender, EventArgs e)
        {
            addDataComboBox();
            settingTextBox();
            load_dgvHienThi();
        }

        private async void btThem_Click(object sender, EventArgs e)
        {
            if (txbMaSV.Text == "" || txbNienKhoa.Text == "" || cbHocKy.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                obj.MAPT = int.Parse(txbMaPT.Text);
                obj.MASV = txbMaSV.Text;
                obj.NIENKHOA = txbNienKhoa.Text;
                obj.HOCKY = int.Parse(cbHocKy.Text);
                if (await bus_PT.GetData(int.Parse(txbMaPT.Text)) == null)
                {
                    if (await bus_PT.GetDataByMaSVandHK(txbMaSV.Text, int.Parse(cbHocKy.Text)) == null)
                    {
                        await bus_PT.Insert(obj);
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvHienThi.DataSource = await bus_PT.GetData();

                        fQuanLy_CTPhieuThu ftemp = new fQuanLy_CTPhieuThu(obj);
                        ftemp.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Thông tin không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Mã phiếu thu đã tồn tại, vui lòng reset", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private async void btSửa_Click(object sender, EventArgs e)
        {
            if (txbMaPT.Text == "" || txbMaSV.Text == "" || txbNienKhoa.Text == "" || cbHocKy.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                obj.MAPT = int.Parse(txbMaPT.Text);
                obj.MASV = txbMaSV.Text;
                obj.NIENKHOA = txbNienKhoa.Text;
                obj.HOCKY = int.Parse(cbHocKy.Text);
                if (await bus_PT.GetData(int.Parse(txbMaPT.Text)) != null)
                {
                    await bus_PT.Update(obj);
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    dgvHienThi.DataSource = await bus_PT.GetData();
                }
                else
                {
                    MessageBox.Show("Mã phiếu thu không tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbMaPT.Focus();
                }
            }
        }

        private async void btXóa_Click(object sender, EventArgs e)
        {
            if (txbMaPT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (await bus_PT.GetData(int.Parse(txbMaPT.Text)) != null)
                {
                    DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu thu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        await bus_PT.Delete(int.Parse(txbMaPT.Text));
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btReset_Click(sender, e);
                        dgvHienThi.DataSource = await bus_PT.GetData();
                    }
                }
                else
                {
                    MessageBox.Show("Mã phiếu thu không tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbMaPT.Focus();
                }
            }
        }

        private async void btReset_Click(object sender, EventArgs e)
        {
            txbMaSV.Text = "";
            txbNienKhoa.Text = "";
            cbHocKy.Text = "";
            txbTongHocPhi.Text = "";
            txbTongDaDong.Text = "";
            txbTongChuaDong.Text = "";
            dgvHienThi.DataSource = await bus_PT.GetData();
        }

        private async void btKiemTra_Click(object sender, EventArgs e)
        {
            if (txbMaSV.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else
            {
                if (await bus_SV.GetData(txbMaSV.Text) != null)
                {
                    HocPhiDto temp = await bus_XLHP.GetDataTongHocPhiOfSV(txbMaSV.Text);
                    txbTongHocPhi.Text = temp.TONGHOCPHI.ToString();
                    txbTongDaDong.Text = temp.TONGDADONG.ToString();
                    txbTongChuaDong.Text = temp.TONGCHUADONG.ToString();

                    dgvHienThi.DataSource = await bus_PT.GetDataByMASV(txbMaSV.Text);
                }
                else
                {
                    MessageBox.Show("Mã sinh viên không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbMaSV.Focus();
                }
            }
        }

        private void dgvHienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHienThi.Columns[e.ColumnIndex].Name == "btChiTiet") 
            {
                obj.MAPT = int.Parse(txbMaPT.Text);
                obj.MASV = txbMaSV.Text;
                obj.NIENKHOA = txbNienKhoa.Text;
                obj.HOCKY = int.Parse(cbHocKy.Text);
                fQuanLy_CTPhieuThu ftemp = new fQuanLy_CTPhieuThu(obj);
                ftemp.ShowDialog();
            }
        }
    }
}
