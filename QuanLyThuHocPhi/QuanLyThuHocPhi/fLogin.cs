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
using static System.Net.WebRequestMethods;

namespace QuanLyThuHocPhi
{
    public partial class fLogin : Form
    {
        private NGUOIDUNGBUS bus = new NGUOIDUNGBUS();
        private static fLogin instance;
        public static fLogin Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new fLogin();
                }
                return instance;
            }
        }
        public fLogin()
        {
            InitializeComponent();
        }

        private void settingTextBox()
        {
            txbMatKhau.UseSystemPasswordChar = true;
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            settingTextBox();
            this.KeyPreview = true;
        }

        private async void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txbTaiKhoan.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var nguoidung = await bus.GetDataByID(txbTaiKhoan.Text);
                if (nguoidung != null)
                {
                    fChangePassword fcp = new fChangePassword(txbTaiKhoan.Text);
                    fcp.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbTaiKhoan.Focus();
                }
            }
        }

        private async void btLogin_Click(object sender, EventArgs e)
        {
            if (txbTaiKhoan.Text == "" || txbMatKhau.Text == "")
            {
                MessageBox.Show("Vui lòng nhập thông tin hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var nguoidung = await bus.GetDataByID(txbTaiKhoan.Text);
                if (nguoidung != null)
                {
                    if (nguoidung.MATKHAU == txbMatKhau.Text)
                    {
                        this.Visible = false;
                        if (nguoidung.QUYEN == "Admin")
                        {
                            fAdmin fm = new fAdmin();
                            fm.Show();
                        }
                        if (nguoidung.QUYEN == "User")
                        {
                            fSinhVien fm = new fSinhVien(txbTaiKhoan.Text);
                            fm.Show();
                        }
                        if (nguoidung.QUYEN == "QuanLy")
                        {
                            fQuanLy fm = new fQuanLy();
                            fm.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu sai, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbTaiKhoan.Focus();
                }
            }
        }

        private void fLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btLogin.PerformClick();
            }
        }

        private void cbShowPassword_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                txbMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txbMatKhau.UseSystemPasswordChar = true;
            }
        }
    }
}
