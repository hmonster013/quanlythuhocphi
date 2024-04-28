using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObject.DangKy;
using ValueObject.CTDangKy;
using BusinessLogicLayer;
using DataAccessLayer;

namespace QuanLyThuHocPhi
{
    public partial class fSinhVien_ChiTietDangKy : Form
    {
        private DANGKY obj;
        private DANGKYBUS bus_DK = new DANGKYBUS(); 
        private CTDANGKYBUS bus_CTDK = new CTDANGKYBUS();
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

        public async void load_ThongTinPhieuDK()
        {
            DANGKY temp = await bus_DK.GetData(obj.MADK);
            txbMaDK.Text = temp.MADK.ToString();
            txbMaSV.Text = temp.MASV;
            txbHocKy.Text = temp.HOCKY.ToString();
            txbMaDK.ReadOnly = true;
            txbMaSV.ReadOnly = true;
            txbHocKy.ReadOnly = true;
        }

        public async void load_dgvHienThi()
        {
            dgvHienThi.DataSource = await bus_XLDK.GetDataLHPDaDK(obj);
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã lớp học phần";
            dgvHienThi.Columns[1].HeaderText = "Mã môn học";
            dgvHienThi.Columns[2].HeaderText = "Tên môn học";
            dgvHienThi.Columns[3].HeaderText = "Tên giáo viên";
            dgvHienThi.Columns[4].HeaderText = "Số tín chỉ";
            dgvHienThi.Columns[5].HeaderText = "Niên khóa";
            dgvHienThi.Columns[6].HeaderText = "Học kỳ";
            dgvHienThi.Columns[7].HeaderText = "Hủy lớp";

            DataGridViewButtonColumn btcl = new DataGridViewButtonColumn();
            btcl.Name = "btHuyDK";
            btcl.HeaderText = "";
            btcl.Text = "Hủy đăng ký";
            btcl.UseColumnTextForButtonValue = true;

            dgvHienThi.Columns.Add(btcl);
        }

        private void fSinhVien_DangKyHocPhan_Load(object sender, EventArgs e)
        {
            load_dgvHienThi();
            load_ThongTinPhieuDK();
        }

        private void btDangKyThem_Click(object sender, EventArgs e)
        {
            fSinhVien_ThemCTDK ftemp = new fSinhVien_ThemCTDK(obj);
            ftemp.FormClosed += Ftemp_FormClosed; // Gán sự kiện FormClosed của fSinhVien_ThemCTDK
            ftemp.ShowDialog();
        }

        private async void Ftemp_FormClosed(object sender, FormClosedEventArgs e)
        {
            dgvHienThi.DataSource = await bus_XLDK.GetDataLHPDaDK(obj); // Gán giá trị mới cho DataSource của DataGridView
        }

        private async void dgvHienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHienThi.Columns[e.ColumnIndex].Name == "btHuyDK")
            {
                await bus_CTDK.DeleteByCondition(int.Parse(txbMaDK.Text), int.Parse(dgvHienThi.Rows[e.RowIndex].Cells["MALHP"].Value.ToString()));
                dgvHienThi.DataSource = await bus_XLDK.GetDataLHPDaDK(obj);
            }
        }

        private void txbTenMH_TextChanged(object sender, EventArgs e)
        {
            string keyword = txbTenMH.Text.Trim().ToLower();

            dgvHienThi.BindingContext[dgvHienThi.DataSource].SuspendBinding();

            foreach (DataGridViewRow row in dgvHienThi.Rows)
            {
                row.Visible = true;
            }

            foreach (DataGridViewRow row in dgvHienThi.Rows)
            {
                bool found = string.IsNullOrEmpty(keyword) || row.Cells[2].Value?.ToString().ToLower().Contains(keyword) == true;

                if (row.Visible != found)
                {
                    row.Visible = found;
                }
            }

            dgvHienThi.BindingContext[dgvHienThi.DataSource].ResumeBinding();
        }
    }
}
