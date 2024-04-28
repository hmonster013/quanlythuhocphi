using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogicLayer;

namespace QuanLyThuHocPhi
{
    public partial class fSinhVien_ChuongTrinhHoc : Form
    {
        private CHUONGTRINHHOCBUS bus = new CHUONGTRINHHOCBUS();
        private string MASV;
        public fSinhVien_ChuongTrinhHoc()
        {
            InitializeComponent();
        }

        public fSinhVien_ChuongTrinhHoc(string MASV)
        {
            InitializeComponent();
            this.MASV = MASV;
        }

        public async void load_dgvHienThi()
        {
            dgvHienThi.DataSource = await bus.GetDataBySinhVien(MASV);
            dgvHienThi.ReadOnly = true;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Mã môn học";
            dgvHienThi.Columns[1].HeaderText = "Tên môn học";
            dgvHienThi.Columns[2].HeaderText = "Học kỳ";
            dgvHienThi.Columns[3].HeaderText = "Số tín chỉ";
        }

        public void addDataComboBox()
        {
            cbHocKy.Items.Add("1");
            cbHocKy.Items.Add("2");
            cbHocKy.Items.Add("3");
            cbHocKy.Items.Add("4");
            cbHocKy.Items.Add("5");
        }

        private void fSinhVien_ChuongTrinhHoc_Load(object sender, EventArgs e)
        {
            addDataComboBox();
            load_dgvHienThi();
        }

        private async void cbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = await bus.GetDataBySVHocKy(MASV, int.Parse(cbHocKy.SelectedItem.ToString()));
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
                bool found = string.IsNullOrEmpty(keyword) || row.Cells[1].Value?.ToString().ToLower().Contains(keyword) == true;

                if (row.Visible != found)
                {
                    row.Visible = found;
                }
            }

            dgvHienThi.BindingContext[dgvHienThi.DataSource].ResumeBinding();
        }
    }
}
