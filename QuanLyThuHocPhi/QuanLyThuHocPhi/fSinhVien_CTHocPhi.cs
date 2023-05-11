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

        public void load_dgvHienThi()
        {
            dgvHienThi.DataSource = bus.GetDataByMaPT(MAPT);
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
