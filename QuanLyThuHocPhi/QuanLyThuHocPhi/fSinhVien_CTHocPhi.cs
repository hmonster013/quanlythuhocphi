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
    public partial class fSinhVien_CTHocPhi : Form
    {
        private int MAPT;
        private CTPHIEUTHUBUS bus = new CTPHIEUTHUBUS();
        public fSinhVien_CTHocPhi()
        {
            InitializeComponent();
        }

        public async void load_dgvHienThi()
        {
            dgvHienThi.DataSource = await bus.GetDataByMaPT(MAPT);
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvHienThi.Columns[0].HeaderText = "Mã chi tiết phiếu thu";
            dgvHienThi.Columns[1].HeaderText = "Mã phiếu thu";
            dgvHienThi.Columns[2].HeaderText = "Ngày đóng";
            dgvHienThi.Columns[3].HeaderText = "Số tiền đóng";
        }

        public fSinhVien_CTHocPhi(int MAPT)
        {
            this.MAPT = MAPT;
            InitializeComponent();
        }

        private void fSinhVien_CTHocPhi_Load(object sender, EventArgs e)
        {
            load_dgvHienThi();
        }
    }
}
