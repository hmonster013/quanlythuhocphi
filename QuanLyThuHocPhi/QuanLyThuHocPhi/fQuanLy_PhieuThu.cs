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
            txbMaPT.Text = bus_PT.GetDataSTTPT().Rows[0].ItemArray[0].ToString();;
            txbMaPT.ReadOnly = true;
            txbTongHocPhi.ReadOnly = true;
            txbTongChuaDong.ReadOnly = true;
            txbTongDaDong.ReadOnly = true;
        }

        public void load_dgvHienThi()
        {
            dgvHienThi.DataSource = bus_PT.GetData();
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

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MAPT = int.Parse(txbMaPT.Text);
            obj.MASV = txbMaSV.Text;
            obj.NIENKHOA = txbNienKhoa.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            if (bus_PT.GetData(int.Parse(txbMaPT.Text)).Rows.Count == 0)
            {
                if (bus_PT.GetDataByMaSVandHK(txbMaSV.Text, int.Parse(cbHocKy.Text)).Rows.Count == 0)
                {
                    bus_PT.Insert(obj);
                    MessageBox.Show("Thêm thành công", "Thông báo");
                    dgvHienThi.DataSource = bus_PT.GetData();

                    fQuanLy_CTPhieuThu ftemp = new fQuanLy_CTPhieuThu(obj);
                    ftemp.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thông tin không hợp lệ", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Mã phiếu thu đã tồn tại, vui lòng reset", "Thông báo");
            }
        }

        private void btSửa_Click(object sender, EventArgs e)
        {
            obj.MAPT = int.Parse(txbMaPT.Text);
            obj.MASV = txbMaSV.Text;
            obj.NIENKHOA = txbNienKhoa.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            if (bus_PT.GetData(int.Parse(txbMaPT.Text)).Rows.Count != 0)
            {
                bus_PT.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                dgvHienThi.DataSource = bus_PT.GetData();
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
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu thu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus_PT.Delete(int.Parse(txbMaPT.Text));
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    dgvHienThi.DataSource = bus_PT.GetData();
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
            txbMaPT.Text = bus_PT.GetDataSTTPT().Rows[0].ItemArray[0].ToString();
            txbMaSV.Text = "";
            txbNienKhoa.Text = "";
            cbHocKy.Text = "";
            txbTongHocPhi.Text = "";
            txbTongDaDong.Text = "";
            txbTongChuaDong.Text = "";
            dgvHienThi.DataSource = bus_PT.GetData();
        }

        private void btKiemTra_Click(object sender, EventArgs e)
        {
            if(bus_SV.GetData(txbMaSV.Text).Rows.Count != 0)
            {
                txbTongHocPhi.Text = bus_XLHP.GetDataTongHocPHi(txbMaSV.Text).Rows[0].ItemArray[1].ToString();
                txbTongDaDong.Text = bus_XLHP.GetDataTongHocPHi(txbMaSV.Text).Rows[0].ItemArray[2].ToString();
                txbTongChuaDong.Text = bus_XLHP.GetDataTongHocPHi(txbMaSV.Text).Rows[0].ItemArray[3].ToString();
            }
            else
            {
                MessageBox.Show("Mã sinh viên không tồn tại", "Thông báo");
                txbMaSV.Focus();
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
