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

namespace QuanLyThuHocPhi
{
    public partial class fSinhVien_HocPhi : Form
    {
        private string MASV;
        private XULYHOCPHIBUS bus = new XULYHOCPHIBUS();
        public fSinhVien_HocPhi()
        {
            InitializeComponent();
        }

        public fSinhVien_HocPhi(string MASV)
        {
            this.MASV = MASV;
            InitializeComponent();
        }

        public void load_dgvHienThi()
        {
            dgvHienThi.DataSource = bus.GetDataHocPhi(MASV);
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Mã đăng ký";
            dgvHienThi.Columns[1].HeaderText = "Mã sinh viên";
            dgvHienThi.Columns[2].HeaderText = "Niên khóa";
            dgvHienThi.Columns[3].HeaderText = "Học kỳ";
            dgvHienThi.Columns[4].HeaderText = "Tổng số tín chỉ";
            dgvHienThi.Columns[5].HeaderText = "Mã phiếu thu";
            dgvHienThi.Columns[6].HeaderText = "Học phí";
            dgvHienThi.Columns[7].HeaderText = "Đã đóng";
            dgvHienThi.Columns[8].HeaderText = "Chưa đóng";

            DataGridViewButtonColumn btChiTiet = new DataGridViewButtonColumn();
            btChiTiet.Name = "btChiTiet";
            btChiTiet.Text = "Chi tiết";
            btChiTiet.HeaderText = "";
            btChiTiet.UseColumnTextForButtonValue = true;

            dgvHienThi.Columns.Add(btChiTiet);
        }

        private void fSinhVien_HocPhi_Load(object sender, EventArgs e)
        {
            load_dgvHienThi();
        }

        private void dgvHienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHienThi.Columns[e.ColumnIndex].Name == "btChiTiet")
            {
                if (dgvHienThi.Rows[e.RowIndex].Cells["MAPT"].Value != DBNull.Value)
                {
                    fSinhVien_CTHocPhi ftemp = new fSinhVien_CTHocPhi(int.Parse(dgvHienThi.Rows[e.RowIndex].Cells["MAPT"].Value.ToString()));
                    ftemp.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu về việc nộp học phí", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
    }
}
