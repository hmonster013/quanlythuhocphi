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
using DataAccessLayer;

namespace QuanLyThuHocPhi
{
    public partial class fSinhVien_ChiTietDangKy : Form
    {
        private DANGKY obj;
        private DANGKYBUS bus_DK = new DANGKYBUS(); 
        private XULYDANGKYBUS bus_XLDK = new XULYDANGKYBUS();
        public fSinhVien_ChiTietDangKy()
        {
            InitializeComponent();
        }

        public fSinhVien_ChiTietDangKy(DANGKY obj)
        {
            this.obj = obj;
            InitializeComponent();
        }

        public void load_ThongTinPhieuDK()
        {
            txbMaDK.Text = bus_DK.GetData(obj.MADK).Rows[0].ItemArray[0].ToString();
            txbMaSV.Text = bus_DK.GetData(obj.MADK).Rows[0].ItemArray[1].ToString();
            txbHocKy.Text = bus_DK.GetData(obj.MADK).Rows[0].ItemArray[2].ToString();
            txbMaDK.ReadOnly = true;
            txbMaSV.ReadOnly = true;
            txbHocKy.ReadOnly = true;
        }

        public void load_dgvHienThi()
        {
            dgvHienThi.DataSource = bus_XLDK.GetData(obj);
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã lớp học phần";
            dgvHienThi.Columns[1].HeaderText = "Mã môn học";
            dgvHienThi.Columns[2].HeaderText = "Tên môn học";
            dgvHienThi.Columns[3].HeaderText = "Tên giáo viên";
            dgvHienThi.Columns[4].HeaderText = "Số tín chỉ";
            dgvHienThi.Columns[5].HeaderText = "Niên khóa";
            dgvHienThi.Columns[6].HeaderText = "Học kỳ";
            dgvHienThi.Columns[7].HeaderText = "Hủy lớp";
        }

        private void fSinhVien_DangKyHocPhan_Load(object sender, EventArgs e)
        {
            load_dgvHienThi();
            load_ThongTinPhieuDK();
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus_XLDK.GetData(obj, txbTenMH.Text);
        }
    }
}
