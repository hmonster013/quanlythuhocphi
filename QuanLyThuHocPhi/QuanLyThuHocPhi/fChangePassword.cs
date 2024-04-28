using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObject.NguoiDung;
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

        private async void btLuu_Click(object sender, EventArgs e)
        {
            var nguoidung = await bus.GetDataByID(tentaikhoan);
            if (txbMKHT.Text == nguoidung.MATKHAU)
            {
                if (txbNMKM.Text == txbNLMK.Text)
                {
                    obj.TENTAIKHOAN = tentaikhoan;
                    obj.MATKHAU = txbNMKM.Text;
                    obj.QUYEN = nguoidung.QUYEN;

                    if (await bus.Update(obj) == 1)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    } else
                    {
                        MessageBox.Show("Đổi mật khẩu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không khớp, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMKHT.Focus();
            }
        }
    }
}
