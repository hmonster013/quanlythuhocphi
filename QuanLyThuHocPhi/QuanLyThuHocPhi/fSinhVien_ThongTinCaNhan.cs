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
    public partial class fSinhVien_ThongTinCaNhan : Form
    {
        private string MASV;
        private SINHVIENBUS bus = new SINHVIENBUS();
        public fSinhVien_ThongTinCaNhan()
        {
            InitializeComponent();
        }

        public fSinhVien_ThongTinCaNhan(string MASV)
        {
            this.MASV = MASV;
            InitializeComponent();
        }

        public void addDataToForm(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = bus.GetData(MASV);
            txbMaSV.Text = dt.Rows[0].ItemArray[0].ToString();
            txbHoSV.Text = dt.Rows[0].ItemArray[1].ToString();
            txbTenSV.Text = dt.Rows[0].ItemArray[2].ToString();
            txbDiaChi.Text = dt.Rows[0].ItemArray[6].ToString();
            txbTenTK.Text = dt.Rows[0].ItemArray[8].ToString();
            if (bool.Parse(dt.Rows[0].ItemArray[4].ToString()) == true)
            {
                rdbNu.Checked = true;
            }
            else
            {
                rdbNam.Checked = true;
            }
            if (bool.Parse(dt.Rows[0].ItemArray[7].ToString()) == true)
            {
                rdbTrue.Checked = true;
            }
            else
            {
                rdbFalse.Checked = true;
            }
            dtpNgaySinh.Value = DateTime.Parse(dt.Rows[0].ItemArray[5].ToString());
            cbMaLop.Text = dt.Rows[0].ItemArray[3].ToString();
        }

        private void fSinhVien_ThongTinCaNhan_Load(object sender, EventArgs e)
        {
            txbMaSV.Enabled = false;
            txbHoSV.Enabled = false;
            txbTenSV.Enabled = false;
            txbDiaChi.Enabled = false;
            txbTenTK.Enabled = false;
            rdbNam.Enabled = false;
            rdbNu.Enabled = false;
            rdbTrue.Enabled = false;
            rdbFalse.Enabled = false;
            dtpNgaySinh.Enabled = false;
            cbMaLop.Enabled = false;
            addDataToForm(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
