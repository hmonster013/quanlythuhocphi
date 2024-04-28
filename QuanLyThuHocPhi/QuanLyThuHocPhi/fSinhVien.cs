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
    public partial class fSinhVien : Form
    {

        private Form currentFormChild;
        private string MASV;
        public fSinhVien()
        {
            InitializeComponent();
        }

        public fSinhVien(string MASV)
        {
            this.MASV = MASV;
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnHienThi.Controls.Add(childForm);
            pnHienThi.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void fSinhVien_Load(object sender, EventArgs e)
        {
            panel4_Click(sender, e);
        }

        private void btTTCN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fSinhVien_ThongTinCaNhan(MASV));
            lbHienThi.Text = btTTCN.Text;
        }

        private void btChuongTrinhHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fSinhVien_ChuongTrinhHoc(MASV));
            lbHienThi.Text = btChuongTrinhHoc.Text;
        }

        private void btDKHP_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fSinhVien_DangKy(MASV));
            lbHienThi.Text = btDKHP.Text;
        }

        private void btHocPhi_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fSinhVien_HocPhi(MASV));
            lbHienThi.Text = btHocPhi.Text;
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            fLogin.Instance.Show();
            this.Dispose();
        }

        private async void panel4_Click(object sender, EventArgs e)
        {
            SINHVIENBUS bus = new SINHVIENBUS();
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            lbHienThi.Text = "Xin chào " + (await bus.GetData(MASV)).TEN;
        }

        private void fSinhVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
