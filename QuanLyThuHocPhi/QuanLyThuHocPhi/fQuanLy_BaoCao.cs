    using BusinessLogicLayer;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Char = System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy_BaoCao : Form
    {
        private SINHVIENBUS bus_SV = new SINHVIENBUS();
        private KHOABUS bus_KHOA = new KHOABUS();
        private CHUYENNGANHBUS bus_CN = new CHUYENNGANHBUS();
        private LOPBUS bus_LOP = new LOPBUS();
        private XULYHOCPHIBUS bus_XLHP = new XULYHOCPHIBUS();

        public fQuanLy_BaoCao()
        {
            InitializeComponent();
        }

        //==========================
        //XU LY LOAD DATA GRID VIEW
        //==========================

        private void load_HocPhi_dgvHienThi()
        {
            HocPhi_dgvHienThi.DataSource = bus_XLHP.GetAllDataHocPhi("", "", "");
            HocPhi_dgvHienThi.ReadOnly = true;
            HocPhi_dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            HocPhi_dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HocPhi_dgvHienThi.Columns[0].HeaderText = "Mã sinh viên";
            HocPhi_dgvHienThi.Columns[1].HeaderText = "Họ và tên";
            HocPhi_dgvHienThi.Columns[2].HeaderText = "Tình trạng";
            HocPhi_dgvHienThi.Columns[3].HeaderText = "Lớp quản lý";
            HocPhi_dgvHienThi.Columns[4].HeaderText = "Tổng số tín chỉ";
            HocPhi_dgvHienThi.Columns[5].HeaderText = "Tổng tiền học phí";
            HocPhi_dgvHienThi.Columns[6].HeaderText = "Tổng tiền học phí đã đóng";
            HocPhi_dgvHienThi.Columns[7].HeaderText = "Tổng tiền học phí chưa đóng";
        }

        //==========================
        //THEM DU LIEU VAO COMBO BOX
        //==========================

        public void addDataComboBox()
        {
            HocPhi_cbKhoa.Items.Clear();
            HocPhi_cbChuyenNganh.Items.Clear();
            HocPhi_cbLop.Items.Clear();
            BieuDo_cbKhoa.Items.Clear();
            BieuDo_cbChuyenNganh.Items.Clear();
            BieuDo_cbLop.Items.Clear();
            //Them ma khoa vao combo box khoa
            foreach (DataRow row in bus_KHOA.GetData().Rows)
            {
                HocPhi_cbKhoa.Items.Add(row[0]);
                BieuDo_cbKhoa.Items.Add(row[0]);
            }
            //Them ma chuyen nganh vao combo box chuyen nganh
            foreach (DataRow row in bus_CN.GetData().Rows)
            {
                HocPhi_cbChuyenNganh.Items.Add(row[0]);
                BieuDo_cbChuyenNganh.Items.Add(row[0]);
            }
            //Them ma lop vao combo box lop
            foreach (DataRow row in bus_LOP.GetData().Rows)
            {
                HocPhi_cbLop.Items.Add(row[0]);
                BieuDo_cbLop.Items.Add(row[0]);
            }

            BieuDo_cbTypeBieuDo.Items.Clear();
            BieuDo_cbTypeBieuDo.Items.Add("Column Char");
            BieuDo_cbTypeBieuDo.Items.Add("Pie Char");
        }

        //==========================
        //FROM LOAD
        //==========================

        private void fQuanLy_BaoCao_Load(object sender, EventArgs e)
        {
            addDataComboBox();
            load_HocPhi_dgvHienThi();
        }


        //====================================
        //XU LY SU KIEN VALUE CHANGE COMBO BOX
        //====================================

        private void HocPhi_cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            HocPhi_dgvHienThi.DataSource = bus_XLHP.GetAllDataHocPhi(HocPhi_cbKhoa.Text, HocPhi_cbChuyenNganh.Text, HocPhi_cbLop.Text);
            HocPhi_cbChuyenNganh.Items.Clear();
            HocPhi_cbLop.Items.Clear();
            foreach (DataRow row in bus_CN.GetDataByMAKHOA(HocPhi_cbKhoa.Text).Rows)
            {
                HocPhi_cbChuyenNganh.Items.Add(row[0]);
            }
            //Them ma lop vao combo box lop
            foreach (DataRow row in bus_LOP.GetDataByMAKHOA(HocPhi_cbKhoa.Text).Rows)
            {
                HocPhi_cbLop.Items.Add(row[0]);
            }
        }

        private void HocPhi_cbChuyenNganh_SelectedValueChanged(object sender, EventArgs e)
        {
            HocPhi_dgvHienThi.DataSource = bus_XLHP.GetAllDataHocPhi(HocPhi_cbKhoa.Text, HocPhi_cbChuyenNganh.Text, HocPhi_cbLop.Text);
            HocPhi_cbLop.Items.Clear();
            foreach (DataRow row in bus_LOP.GetdataByMACN(HocPhi_cbChuyenNganh.Text).Rows)
            {
                HocPhi_cbLop.Items.Add(row[0]);
            }
        }

        private void HocPhi_cbLop_SelectedValueChanged(object sender, EventArgs e)
        {
            HocPhi_dgvHienThi.DataSource = bus_XLHP.GetAllDataHocPhi(HocPhi_cbKhoa.Text, HocPhi_cbChuyenNganh.Text, HocPhi_cbLop.Text);
        }

        private void BieuDo_cbKhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            BieuDo_cbChuyenNganh.Items.Clear();
            BieuDo_cbLop.Items.Clear();
            foreach (DataRow row in bus_CN.GetDataByMAKHOA(BieuDo_cbKhoa.Text).Rows)
            {
                BieuDo_cbChuyenNganh.Items.Add(row[0]);
            }
            //Them ma lop vao combo box lop
            foreach (DataRow row in bus_LOP.GetDataByMAKHOA(BieuDo_cbKhoa.Text).Rows)
            {
                BieuDo_cbLop.Items.Add(row[0]);
            }
        }

        private void BieuDo_cbChuyenNganh_SelectedValueChanged(object sender, EventArgs e)
        {
            BieuDo_cbLop.Items.Clear();
            foreach (DataRow row in bus_LOP.GetdataByMACN(BieuDo_cbChuyenNganh.Text).Rows)
            {
                BieuDo_cbLop.Items.Add(row[0]);
            }
        }

        //=================
        //XU LY CAC BUTTON
        //=================

        private void HocPhi_btReset_Click(object sender, EventArgs e)
        {
            this.fQuanLy_BaoCao_Load(sender, e);
            HocPhi_cbKhoa.Text = null;
            HocPhi_cbChuyenNganh.Text = null;
            HocPhi_cbLop.Text = null;
        }

        private void HocPhi_btXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Workbook workbook = excelApp.Workbooks.Add();
            Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

            // Tạo tiêu đề
            Excel.Range header = worksheet.Range["A1", "H1"];
            header.MergeCells = true;
            header.Font.Size = 25;
            header.Font.Bold = true;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            if (cbChuaNopHP.Checked == true)
            {
                header.Value = "DANH SÁCH NỢ HỌC PHÍ CỦA SINH VIÊN";
            }
            else
            {
                header.Value = "DANH SÁCH HỌC PHÍ CỦA SINH VIÊN";
            }

            // Tạo các cột cho bảng
            Excel.Range headerRange = worksheet.Range["A2", "H2"];
            headerRange.Font.Size = 13;
            headerRange.ColumnWidth = 35;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            for (int i = 0; i < HocPhi_dgvHienThi.Columns.Count; i++)
            {
                headerRange.Cells[1, i + 1].Value = HocPhi_dgvHienThi.Columns[i].HeaderText.ToString();
            }

            // Thêm dữ liệu vào excel
            for (int row = 0; row < HocPhi_dgvHienThi.Rows.Count - 1; row++)
            {
                for (int col = 0; col < HocPhi_dgvHienThi.Rows[row].Cells.Count; col++)
                {
                    worksheet.Cells[row + 3, col + 1] = HocPhi_dgvHienThi.Rows[row].Cells[col].Value.ToString();
                }
            }

            // Tạo bảng trong excel
            Excel.Range dataRange = worksheet.Range["A2", $"H{HocPhi_dgvHienThi.Rows.Count + 1}"];
            dataRange.Borders.Color = Color.Black;
            Excel.ListObject table = worksheet.ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, dataRange, Type.Missing, Excel.XlYesNoGuess.xlYes);
            string tableName = "MyTable";
            table.Name = tableName;

            table.TableStyle = "TableStyleMedium2"; // Áp dụng một kiểu bảng
            table.HeaderRowRange.Font.Bold = true; // Đặt in đậm cho hàng đầu tiên của bảng
            table.HeaderRowRange.Interior.Color = Color.YellowGreen; // Đặt màu nền cho hàng đầu tiên của bảng

            Excel.Range timeRange = worksheet.Range[$"G{HocPhi_dgvHienThi.Rows.Count + 3}", $"G{HocPhi_dgvHienThi.Rows.Count + 5}"];
            timeRange.Font.Size = 13;
            timeRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            timeRange.Cells[1, 1].Value = "Hà Nội, ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString();
            timeRange.Cells[2, 1].Value = "Người lập";
            timeRange.Cells[2, 1].Font.Bold = true;
            timeRange.Cells[3, 1].Value = "(Ký, họ tên)";

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Save Excel File";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                workbook.SaveAs(filePath);
                // Tiếp tục quá trình lưu dữ liệu vào file Excel
            }
            else
            {
                // Người dùng đã hủy việc lưu file
            }
            workbook.Close();
            excelApp.Quit();
        }

        private void BieuDo_btReset_Click(object sender, EventArgs e)
        {
            this.fQuanLy_BaoCao_Load(sender, e);
            BieuDo_cbKhoa.Text = null;
            BieuDo_cbChuyenNganh.Text = null;
            BieuDo_cbLop.Text = null;
        }

        private void BieuDo_btTaoBieuDo_Click(object sender, EventArgs e)
        {
            BieuDo_Char.Series.Clear();
            Char.Series series = new Char.Series("Dữ liệu"); // Tạo Series mới và đặt tên cho nó

            // Thêm dữ liệu vào Series
            series.Points.AddXY("Tổng học phí", bus_XLHP.GetAllDataTongHocPhi(BieuDo_cbKhoa.Text, BieuDo_cbChuyenNganh.Text, BieuDo_cbLop.Text).Rows[0].ItemArray[0]);
            series.Points.AddXY("Tổng học phí đã đóng", bus_XLHP.GetAllDataTongHocPhi(BieuDo_cbKhoa.Text, BieuDo_cbChuyenNganh.Text, BieuDo_cbLop.Text).Rows[0].ItemArray[1]);
            series.Points.AddXY("Tổng học phí chưa đóng", bus_XLHP.GetAllDataTongHocPhi(BieuDo_cbKhoa.Text, BieuDo_cbChuyenNganh.Text, BieuDo_cbLop.Text).Rows[0].ItemArray[2]);
            
            // Hiển thị dữ liệu lên đầu các cột
            series.IsValueShownAsLabel = true;
            series.LabelForeColor = Color.Black;

            // Thêm Series vào biểu đồ
            BieuDo_Char.Series.Add(series);
            switch (BieuDo_cbTypeBieuDo.Text)
            {
                case "Column Char":
                    // Đặt màu sắc cho các cột
                    series.Color = Color.OrangeRed;

                    series.ChartType = SeriesChartType.Column; // Đặt loại biểu đồ là Column
                    BieuDo_Char.Invalidate(); // Vẽ lại biểu đồ để hiển thị các thay đổi
                    break;
                case "Pie Char":
                    series.ChartType = SeriesChartType.Pie; // Đặt loại biểu đồ là Column
                    BieuDo_Char.Invalidate(); // Vẽ lại biểu đồ để hiển thị các thay đổi
                    break;
                default:
                    MessageBox.Show("Không có loại biểu đồ này, vui lòng chọn lại", "Thông báo");
                    break;
            }
        }

        private void cbChuaNopHP_CheckedChanged(object sender, EventArgs e)
        {
            if (cbChuaNopHP.Checked)
            {
                HocPhi_dgvHienThi.DataSource = bus_XLHP.GetAllDataNoHocPhi(HocPhi_cbKhoa.Text, HocPhi_cbChuyenNganh.Text, HocPhi_cbLop.Text);
            }
            else
            {
                HocPhi_dgvHienThi.DataSource = bus_XLHP.GetAllDataHocPhi(HocPhi_cbKhoa.Text, HocPhi_cbChuyenNganh.Text, HocPhi_cbLop.Text);
            }
        }
    }
}
