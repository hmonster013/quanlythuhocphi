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
        private Form currentFormChild;

        public fAdmin()
        {
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

        private void btTaiKhoan_Click(object sender, EventArgs e)
        {
            OpenChildForm(new fAdmin_NguoiDung());
            lbHienThi.Text = "Quản lý tài khoản";
        }

        private void btDangXuat_Click(object sender, EventArgs e)
        {
            fLogin.Instance.Show();
            this.Dispose();
        }

        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fQuanLy ftempQuanLy = new fQuanLy();
            ftempQuanLy.ShowDialog();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            lbHienThi.Text = "ADMIN";
        }

        private void fAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {

        }
    }
}
