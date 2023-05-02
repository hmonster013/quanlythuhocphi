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
    public partial class fAdmin : Form
    {
        public fAdmin()
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
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btSinhVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fAdmin_SinhVien());
            lbHienThi.Text = btSinhVien.Text;
        }

        private void btGiangVien_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fAdmin_GiangVien());
            lbHienThi.Text = btGiangVien.Text;
        }

        private void btMonHoc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fAdmin_MonHoc());
            lbHienThi.Text = btMonHoc.Text;
        }

        private void btKhoa_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fAdmin_Khoa());
            lbHienThi.Text = btKhoa.Text;
        }

        private void btLop_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fAdmin_Lop());
            lbHienThi.Text = btLop.Text;
        }

        private void btLopHocPhan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fAdmin_LopHocPhan());
            lbHienThi.Text = btLopHocPhan.Text;
        }

        private void btTaoPhieuThu_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fAdmin_TaoPhieuThu());
            lbHienThi.Text = btTaoPhieuThu.Text;
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            lbHienThi.Text = "HOME";
        }
    }
}
