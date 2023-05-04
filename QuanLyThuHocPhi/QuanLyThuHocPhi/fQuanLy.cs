using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy : Form
    {
        public fQuanLy()
        {
            InitializeComponent();
        }
        private Form currentFormChild;

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

        private void btSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLy_SinhVien());
            lbHienThi.Text = btSinhVien.Text;
        }

        private void btGiangVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLy_GiangVien());
            lbHienThi.Text = btGiangVien.Text;
        }

        private void btMonHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLy_MonHoc());
            lbHienThi.Text = btMonHoc.Text;
        }

        private void btKhoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLy_Khoa());
            lbHienThi.Text = btKhoa.Text;
        }

        private void btLop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLy_Lop());
            lbHienThi.Text = btLop.Text;
        }

        private void btLopHocPhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLy_LopHocPhan());
            lbHienThi.Text = btLopHocPhan.Text;
        }

        private void btTaoPhieuThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLy_TaoPhieuThu());
            lbHienThi.Text = btTaoPhieuThu.Text;
        }

        private void btCN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fQuanLy_ChuyenNganh());
            lbHienThi.Text = btCN.Text;
        }
        private bool isClickbtDangXuat = false;
        private void btDangXuat_Click(object sender, EventArgs e)
        {
            isClickbtDangXuat = true;
            this.Close();
            fLogin.Instance.Show();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            lbHienThi.Text = "HOME";
        }

        private void fQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClickbtDangXuat)
            {
                Application.Exit();
            }
        }
    }
}
