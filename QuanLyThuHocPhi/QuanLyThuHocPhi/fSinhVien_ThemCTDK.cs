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
    public partial class fSinhVien_ThemCTDK : Form
    {
        private DANGKY obj = new DANGKY();
        private DANGKYBUS bus_DK = new DANGKYBUS();
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

        public void load_dgvHienThi()
        {

        }

        public void load_ThongTinPhieuDK()
        {
            txbMaDK.Text = bus_DK.GetData(obj.MADK).Rows[0].ItemArray[0].ToString();
            txbMaDK.ReadOnly = true;
        }

        private void fSinhVien_ThemCTDK_Load(object sender, EventArgs e)
        {
            load_dgvHienThi();
        }
    }
}
