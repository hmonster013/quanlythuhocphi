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
using BusinessLogicLayer;
using static System.Net.WebRequestMethods;

namespace QuanLyThuHocPhi
{
    public partial class fLogin : Form
    {
        private NGUOIDUNG obj = new NGUOIDUNG();
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

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = bus.GetData(txbTaiKhoan.Text);
            if (dt.Rows.Count > 0)
            {
                fChangePassword fcp = new fChangePassword(txbTaiKhoan.Text);
                fcp.ShowDialog();
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại, vui lòng nhập lại", "Thông báo");
                txbTaiKhoan.Focus();
            }
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = bus.GetData(txbTaiKhoan.Text);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0].ItemArray[1].ToString() == txbMatKhau.Text)
                {
                    this.Visible = false;
                    if (dt.Rows[0].ItemArray[2].ToString() == "Admin")
                    {
                        fAdmin fm = new fAdmin();
                        fm.Show();
                    }
                    if (dt.Rows[0].ItemArray[2].ToString() == "User")
                    {
                        fSinhVien fm = new fSinhVien(txbTaiKhoan.Text);
                        fm.Show();
                    }
                    if (dt.Rows[0].ItemArray[2].ToString() == "QuanLy")
                    {
                        fQuanLy fm = new fQuanLy();
                        fm.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu sai, vui lòng nhập lại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Tài khoản không tồn tại, vui lòng nhập lại", "Thông báo");
                txbTaiKhoan.Focus();
            }
        }
    }
}
