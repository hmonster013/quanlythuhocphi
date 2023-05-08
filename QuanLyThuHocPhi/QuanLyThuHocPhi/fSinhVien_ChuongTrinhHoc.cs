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

        public void load_dgvHienThi()
        {
            dgvHienThi.DataSource = bus.GetData(MASV);
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
        private void btTimKiem_Click(object sender, EventArgs e)
        {
            if (cbHocKy.SelectedItem == null)
            {
                dgvHienThi.DataSource = bus.GetDataByTenMH(MASV, txbTenMH.Text);
            }
            else
            {
                dgvHienThi.DataSource = bus.GetDataByTenMH(MASV, txbTenMH.Text, int.Parse(cbHocKy.Text));
            }
        }

        private void fSinhVien_ChuongTrinhHoc_Load(object sender, EventArgs e)
        {
            addDataComboBox();
            load_dgvHienThi();
        }

        private void cbHocKy_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData(MASV, int.Parse(cbHocKy.SelectedItem.ToString()));
        }
    }
}
