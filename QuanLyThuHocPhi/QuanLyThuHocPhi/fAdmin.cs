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
            pnHienThi.Controls.Add(childForm);
            pnHienThi.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fAdmin_NguoiDung());
            lbHienThi.Text = "Quản lý tài khoản";
        }

        private bool isClickbtDangXuat = false;
        private void btDangXuat_Click(object sender, EventArgs e)
        {
            isClickbtDangXuat = true;
            this.Close();
            fLogin.Instance.Show();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLy ftempQuanLy = new fQuanLy();
            ftempQuanLy.ShowDialog();
        }
        private void sinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fSinhVien ftempSinhVien = new fSinhVien("Admin");
            ftempSinhVien.ShowDialog();
        }
        private void panel4_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            lbHienThi.Text = "Xin chào";
        }

        private void fAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClickbtDangXuat)
            {
                Application.Exit();
            }
        }
    }
}
