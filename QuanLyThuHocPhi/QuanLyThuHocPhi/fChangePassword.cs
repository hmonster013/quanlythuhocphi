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

namespace QuanLyThuHocPhi
{
    public partial class fChangePassword : Form
    {
        private string tentaikhoan;
        private NGUOIDUNG obj = new NGUOIDUNG();
        private NGUOIDUNGBUS bus = new NGUOIDUNGBUS();
        public fChangePassword()
        {
            InitializeComponent();
        }

        public fChangePassword(string tentaikhoan)
        {
            this.tentaikhoan = tentaikhoan;
            InitializeComponent();
        }

        private void btHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = bus.GetData(tentaikhoan);
            if (txbMKHT.Text == dt.Rows[0].ItemArray[1].ToString())
            {
                if (txbNMKM.Text == txbNLMK.Text)
                {
                    obj.TENTAIKHOAN = tentaikhoan;
                    obj.MATKHAU = txbNMKM.Text;
                    obj.QUYEN = dt.Rows[0].ItemArray[2].ToString();
                    bus.Update(obj);
                    MessageBox.Show("Đổi mật khẩu thành công", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không khớp, vui lòng nhập lại", "Thông báo");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng, vui lòng nhập lại", "Thông báo");
                txbMKHT.Focus();
            }
        }
    }
}
