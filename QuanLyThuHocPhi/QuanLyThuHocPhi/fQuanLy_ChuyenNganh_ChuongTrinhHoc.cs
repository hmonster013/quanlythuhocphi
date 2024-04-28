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
using ValueObject.CTChuyenNganh;
using ValueObject.MonHoc;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy_ChuyenNganh_ChuongTrinhHoc : Form
    {
        private string MACN;
        private CTCHUYENNGANH obj = new CTCHUYENNGANH();
        private CHUONGTRINHHOCBUS bus_CTH = new CHUONGTRINHHOCBUS();
        private CTCHUYENNGANHBUS bus_CTCN = new CTCHUYENNGANHBUS();
        private BindingList<MONHOC> bdlMonHocLeft;
        private BindingList<MONHOC> bdlMonHocRight;

        public fQuanLy_ChuyenNganh_ChuongTrinhHoc()
        {
            InitializeComponent();
        }

        public fQuanLy_ChuyenNganh_ChuongTrinhHoc(string MACN)
        {
            this.MACN = MACN;
            InitializeComponent();
        }

        public async void load_dgv1()
        {
            List<MONHOC> dsMonHoc = await bus_CTH.GetDataNotInChuyenNganh(MACN);
            bdlMonHocLeft = new BindingList<MONHOC>(dsMonHoc);
            dataGridView1.DataSource = bdlMonHocLeft;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Columns[0].HeaderText = "Mã môn học";
            dataGridView1.Columns[1].HeaderText = "Tên môn học";
            dataGridView1.Columns[2].HeaderText = "Học kỳ";
            dataGridView1.Columns[3].HeaderText = "Số tín chỉ";

            DataGridViewButtonColumn btThem = new DataGridViewButtonColumn();
            btThem.Name = "btThem";
            btThem.HeaderText = "";
            btThem.Text = "Thêm";
            btThem.UseColumnTextForButtonValue = true;

            dataGridView1.Columns.Add(btThem);
        }

        public async void load_dgv2()
        {
            List<MONHOC> dsMonHoc = await bus_CTH.GetDataByChuyenNganh(MACN);
            bdlMonHocRight = new BindingList<MONHOC>(dsMonHoc);
            dataGridView2.DataSource = bdlMonHocRight;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns[0].HeaderText = "Mã môn học";
            dataGridView2.Columns[1].HeaderText = "Tên môn học";
            dataGridView2.Columns[2].HeaderText = "Học kỳ";
            dataGridView2.Columns[3].HeaderText = "Số tín chỉ";

            DataGridViewButtonColumn btHuy = new DataGridViewButtonColumn();
            btHuy.Name = "btHuy";
            btHuy.HeaderText = "";
            btHuy.Text = "Hủy";
            btHuy.UseColumnTextForButtonValue = true;

            dataGridView2.Columns.Add(btHuy);
        }

        private void fQuanLy_ChuyenNganh_ChuongTrinhHoc_Load(object sender, EventArgs e)
        {
            load_dgv1();
            load_dgv2();    
        }

        private async void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btThem")
            {
                obj.MACN = MACN;
                obj.MAMH = dataGridView1.Rows[e.RowIndex].Cells["MAMH"].Value.ToString();
                await bus_CTCN.Insert(obj);

                DataGridViewRow tempRow = dataGridView1.Rows[e.RowIndex];
                MONHOC tempMonHoc = new MONHOC();
                tempMonHoc.MAMH = tempRow.Cells[0].Value.ToString();
                tempMonHoc.TENMH = tempRow.Cells[1].Value.ToString();
                tempMonHoc.SOTINCHI = int.Parse(tempRow.Cells[2].Value.ToString());
                tempMonHoc.HOCKY = int.Parse(tempRow.Cells[3].Value.ToString());
                bdlMonHocLeft.RemoveAt(e.RowIndex);
                bdlMonHocRight.Add(tempMonHoc);
            }
        }

        private async void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "btHuy")
            {
                await bus_CTCN.DeleteByMaMH(dataGridView2.Rows[e.RowIndex].Cells["MAMH"].Value.ToString());

                DataGridViewRow tempRow = dataGridView2.Rows[e.RowIndex];
                MONHOC tempMonHoc = new MONHOC();
                tempMonHoc.MAMH = tempRow.Cells[0].Value.ToString();
                tempMonHoc.TENMH = tempRow.Cells[1].Value.ToString();
                tempMonHoc.SOTINCHI = int.Parse(tempRow.Cells[2].Value.ToString());
                tempMonHoc.HOCKY = int.Parse(tempRow.Cells[3].Value.ToString());
                bdlMonHocRight.RemoveAt(e.RowIndex);
                bdlMonHocLeft.Add(tempMonHoc);
            }
        }

        private void txbMonHocdgv1_TextChanged(object sender, EventArgs e)
        {
            string keyword = txbMonHocdgv1.Text.Trim().ToLower();

            dataGridView1.BindingContext[dataGridView1.DataSource].SuspendBinding();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    bool found = string.IsNullOrEmpty(keyword) || row.Cells[1].Value?.ToString().ToLower().Contains(keyword) == true;
                    row.Visible = found;
                }
            }

            dataGridView1.BindingContext[dataGridView1.DataSource].ResumeBinding();
        }

        private void txbMonHocdgv2_TextChanged(object sender, EventArgs e)
        {
            string keyword = txbMonHocdgv2.Text.Trim().ToLower();

            dataGridView2.BindingContext[dataGridView2.DataSource].SuspendBinding();

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {
                    bool found = string.IsNullOrEmpty(keyword) || row.Cells[1].Value?.ToString().ToLower().Contains(keyword) == true;
                    row.Visible = found;
                }
            }

            dataGridView2.BindingContext[dataGridView2.DataSource].ResumeBinding();
        }
    }
}
