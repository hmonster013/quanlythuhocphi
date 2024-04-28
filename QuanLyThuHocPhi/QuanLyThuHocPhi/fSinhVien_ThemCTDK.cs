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
using ValueObject.DangKy;
using ValueObject.CTDangKy;

namespace QuanLyThuHocPhi
{
    public partial class fSinhVien_ThemCTDK : Form
    {
        private DANGKY obj = new DANGKY();
        private DANGKYBUS bus_DK = new DANGKYBUS();
        private CTDANGKYBUS bus_CTDK = new CTDANGKYBUS();
        private XULYDANGKYBUS bus_XLDK = new XULYDANGKYBUS();
        public fSinhVien_ThemCTDK()
        {
            InitializeComponent();
        }

        public fSinhVien_ThemCTDK(DANGKY obj)
        {
            this.obj = obj;
            InitializeComponent();
        }
        
        public async void load_dgvHienThi()
        {
            dgvHienThi.DataSource = await bus_XLDK.GetDataLHPChuaDK(obj);
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã lớp học phần";
            dgvHienThi.Columns[1].HeaderText = "Mã môn học";
            dgvHienThi.Columns[2].HeaderText = "Tên môn học";
            dgvHienThi.Columns[3].HeaderText = "Tên giáo viên";
            dgvHienThi.Columns[4].HeaderText = "Số tín chỉ";
            dgvHienThi.Columns[5].HeaderText = "Niên khóa";
            dgvHienThi.Columns[6].HeaderText = "Học kỳ";
            dgvHienThi.Columns[7].HeaderText = "Hủy lớp";
            DataGridViewCheckBoxColumn dgvcheckbox = new DataGridViewCheckBoxColumn();

            dgvcheckbox.Name = "btChiTiet";
            dgvcheckbox.HeaderText = "Trạng thái";
            dgvHienThi.Columns.Add(dgvcheckbox);
        }

        public async void load_ThongTinPhieuDK()
        {
            txbMaDK.Text = (await bus_DK.GetData(obj.MADK)).MADK.ToString();
            txbMaDK.ReadOnly = true;
        }

        private void fSinhVien_ThemCTDK_Load(object sender, EventArgs e)
        {
            load_dgvHienThi();
            load_ThongTinPhieuDK();
        }

        private async void btDangKy_Click(object sender, EventArgs e)
        {
            CTDANGKY temp = new CTDANGKY();
            temp.MADK = obj.MADK;
            foreach (DataGridViewRow row in dgvHienThi.Rows)
            {
                if (row.Cells[8].Value != null && bool.Parse(row.Cells[8].Value.ToString()))
                {
                    temp.MALHP = int.Parse(row.Cells[0].Value.ToString());
                    await bus_CTDK.Insert(temp);
                }
            }
            dgvHienThi.DataSource = await bus_XLDK.GetDataLHPChuaDK(obj);
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
