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
using ValueObject;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy_ChuyenNganh_ChuongTrinhHoc : Form
    {
        private string MACN;
        private CTCHUYENNGANH obj = new CTCHUYENNGANH();
        private CHUONGTRINHHOCBUS bus_CTH = new CHUONGTRINHHOCBUS();
        private CTCHUYENNGANHBUS bus_CTCN = new CTCHUYENNGANHBUS();

        public fQuanLy_ChuyenNganh_ChuongTrinhHoc()
        {
            InitializeComponent();
        }

        public fQuanLy_ChuyenNganh_ChuongTrinhHoc(string MACN)
        {
            this.MACN = MACN;
            InitializeComponent();
        }

        public void load_dgv1()
        {
            dataGridView1.DataSource = bus_CTH.GetDataNotInChuyenNganh(MACN);
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

        public void load_dgv2()
        {
            dataGridView2.DataSource = bus_CTH.GetDataByChuyenNganh(MACN);
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "btThem")
            {
                obj.MACN = MACN;
                obj.MAMH = dataGridView1.Rows[e.RowIndex].Cells["MAMH"].Value.ToString();
                bus_CTCN.Insert(obj);

                dataGridView1.DataSource = bus_CTH.GetDataNotInChuyenNganh(MACN);
                dataGridView2.DataSource = bus_CTH.GetDataByChuyenNganh(MACN);
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "btHuy")
            {
                bus_CTCN.DeleteByMaMH(dataGridView2.Rows[e.RowIndex].Cells["MAMH"].Value.ToString());

                dataGridView1.DataSource = bus_CTH.GetDataNotInChuyenNganh(MACN);
                dataGridView2.DataSource = bus_CTH.GetDataByChuyenNganh(MACN);
            }
        }

        private void txbTimKiemdgv1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bus_CTH.FindByTenMHNotInChuyenNganh(MACN, txbMonHocdgv1.Text);
        }

        private void txbTimKiemdgv2_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = bus_CTH.FindByTenMHandChuyenNganh(MACN, txbMonHocdgv2.Text);
        }
    }
}
