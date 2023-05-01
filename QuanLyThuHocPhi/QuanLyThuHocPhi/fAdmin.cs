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

        private void bt_SinhVien_Click(object sender, EventArgs e)
        {
            UcSinhVien uc = new UcSinhVien();
            uc.Dock = DockStyle.Fill;
            pnlHienThi.Controls.Clear();
            pnlHienThi.Controls.Add(uc);

        }

        private void btKhoa_Click(object sender, EventArgs e)
        {
            UcKhoa uc = new UcKhoa();
            uc.Dock = DockStyle.Fill;
            pnlHienThi.Controls.Clear();
            pnlHienThi.Controls.Add(uc);
        }

        private void btMonHoc_Click(object sender, EventArgs e)
        {
            UcMonHoc uc = new UcMonHoc();
            uc.Dock = DockStyle.Fill;
            pnlHienThi.Controls.Clear();
            pnlHienThi.Controls.Add(uc);
        }

        private void btTinChi_Click(object sender, EventArgs e)
        {
            UcTinChi uc = new UcTinChi();
            uc.Dock = DockStyle.Fill;
            pnlHienThi.Controls.Clear();
            pnlHienThi.Controls.Add(uc);
        }

        private void btLopHoc_Click(object sender, EventArgs e)
        {
            UcLopHoc uc = new UcLopHoc();
            uc.Dock = DockStyle.Fill;
            pnlHienThi.Controls.Clear();
            pnlHienThi.Controls.Add(uc);
        }

        private void btGiangVien_Click(object sender, EventArgs e)
        {
            UcGiangVien uc = new UcGiangVien();
            uc.Dock = DockStyle.Fill;
            pnlHienThi.Controls.Clear();
            pnlHienThi.Controls.Add(uc);
        }

        private void btLopTinChi_Click(object sender, EventArgs e)
        {
            UcLopHocPhan uc = new UcLopHocPhan();
            uc.Dock = DockStyle.Fill;
            pnlHienThi.Controls.Clear();
            pnlHienThi.Controls.Add(uc);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
            fMain fm = new fMain();
            fm.Visible = true;
        }
    }
}
