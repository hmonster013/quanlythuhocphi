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
using ValueObject.SinhVien;

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

        public async void addDataToForm(object sender, EventArgs e)
        {
            SINHVIEN sinhvien = await bus.GetData(MASV);
            txbMaSV.Text = sinhvien.MASV;
            txbHoSV.Text = sinhvien.HO;
            txbTenSV.Text = sinhvien.TEN;
            txbDiaChi.Text = sinhvien.DIACHI;
            txbTenTK.Text = sinhvien.TENTAIKHOAN;
            if (sinhvien.PHAI)
            {
                rdbNu.Checked = true;
            }
            else
            {
                rdbNam.Checked = true;
            }

            if (sinhvien.DANGNGHIHOC)
            {
                rdbTrue.Checked = true;
            }
            else
            {
                rdbFalse.Checked = true;
            }

            dtpNgaySinh.Value = sinhvien.NGAYSINH;
            cbMaLop.Text = sinhvien.MALOP;
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
