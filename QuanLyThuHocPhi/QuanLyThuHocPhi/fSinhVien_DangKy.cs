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
using ValueObject;

namespace QuanLyThuHocPhi
{
    public partial class fSinhVien_DangKy : Form
    {
        private string MASV;
        private DANGKY obj = new DANGKY();
        private DANGKYBUS bus = new DANGKYBUS();
        public fSinhVien_DangKy()
        {
            InitializeComponent();
        }

        public fSinhVien_DangKy(string MASV)
        {
            this.MASV = MASV;
            InitializeComponent();
        }

        public void addDataComboBox()
        {
            //ComboBox Hoc ky
            cbHocKy.Items.Add("1");
            cbHocKy.Items.Add("2");
            cbHocKy.Items.Add("3");
            cbHocKy.Items.Add("4");
            cbHocKy.Items.Add("5");
            cbHocKy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbHocKy.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void load_dgvHienThi()
        {
            dgvHienThi.DataSource = bus.GetDataByMASV(MASV);
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã đăng ký";
            dgvHienThi.Columns[1].HeaderText = "Mã sinh viên";
            dgvHienThi.Columns[2].HeaderText = "Học kỳ";
            // Tạo cột DataGridViewButtonColumn mới
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
            buttonColumn.Name = "btChiTiet";
            buttonColumn.HeaderText = "";
            // Sử dụng Text của Column làm Text của Button
            buttonColumn.UseColumnTextForButtonValue = true; 
            buttonColumn.Text = "Chi tiết";
            // Thêm cột mới vào DataGridView
            dgvHienThi.Columns.Add(buttonColumn);
        }

        public void settingMaDK()
        {
            txbMaDK.ReadOnly = true;
            txbMaDK.Text = bus.GetDataSTTMaDK().Rows[0].ItemArray[0].ToString();
            txbMaSV.Text = MASV;
            txbMaSV.ReadOnly = true;
        }

        private void dgvHienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHienThi.Columns[e.ColumnIndex].Name == "btChiTiet")
            {
                obj.MADK = int.Parse(dgvHienThi.Rows[e.RowIndex].Cells[1].Value.ToString());
                obj.MASV = dgvHienThi.Rows[e.RowIndex].Cells[2].Value.ToString();
                obj.HOCKY = int.Parse(dgvHienThi.Rows[e.RowIndex].Cells[3].Value.ToString());
                fSinhVien_ChiTietDangKy temp = new fSinhVien_ChiTietDangKy(obj);
                temp.ShowDialog();
            }
        }

        private void fSinhVien_DangKy_Load(object sender, EventArgs e)
        {
            addDataComboBox();
            load_dgvHienThi();
            settingMaDK();
        }

        private void btDangKy_Click(object sender, EventArgs e)
        {
            //Them dang ky vao csdl
            obj.MADK = int.Parse(txbMaDK.Text);
            obj.MASV = txbMaSV.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            bus.Insert(obj);
            dgvHienThi.DataSource = bus.GetDataByMASV(MASV);
            //Mo bang them chi tiet dang ky
            fSinhVien_ThemCTDK ftemp = new fSinhVien_ThemCTDK(obj);
            ftemp.ShowDialog();
        }
    }
}
