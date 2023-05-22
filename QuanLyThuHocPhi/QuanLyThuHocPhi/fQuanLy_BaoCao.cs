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

        public void load_SinhVien_dgvHienThi()
        {
            SinhVien_dgvHienThi.DataSource = bus_SV.GetData();
            SinhVien_dgvHienThi.ReadOnly = true;
            SinhVien_dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SinhVien_dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SinhVien_dgvHienThi.Columns[0].HeaderText = "Mã sinh viên";
            SinhVien_dgvHienThi.Columns[1].HeaderText = "Họ sinh viên";
            SinhVien_dgvHienThi.Columns[2].HeaderText = "Tên sinh viên";
            SinhVien_dgvHienThi.Columns[3].HeaderText = "Mã lớp";
            SinhVien_dgvHienThi.Columns[4].HeaderText = "Giới tính";
            SinhVien_dgvHienThi.Columns[5].HeaderText = "Ngày sinh";
            SinhVien_dgvHienThi.Columns[6].HeaderText = "Địa chỉ";
            SinhVien_dgvHienThi.Columns[7].HeaderText = "Đang nghỉ học";
            SinhVien_dgvHienThi.Columns[8].HeaderText = "Tên tài khoản";
        }

        private void load_HocPhi_dgvHienThi()
        {
            HocPhi_dgvHienThi.DataSource = bus_XLHP.GetAllDataHocPhi("", "", "");
            HocPhi_dgvHienThi.ReadOnly = true;
            HocPhi_dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            HocPhi_dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            HocPhi_dgvHienThi.Columns[0].HeaderText = "Mã sinh viên";
            HocPhi_dgvHienThi.Columns[1].HeaderText = "Tổng số tín chỉ";
            HocPhi_dgvHienThi.Columns[2].HeaderText = "Tổng tiền học phí";
            HocPhi_dgvHienThi.Columns[3].HeaderText = "Tổng tiền học phí đã đóng";
            HocPhi_dgvHienThi.Columns[4].HeaderText = "Tổng tiền học phí chưa đóng";
        }

        //==========================
        //THEM DU LIEU VAO COMBO BOX
        //==========================

        public void addDataComboBox()
        {
            SinhVien_cbKhoa.Items.Clear();
            SinhVien_cbChuyenNganh.Items.Clear();
            SinhVien_cbLop.Items.Clear();
            HocPhi_cbKhoa.Items.Clear();
            HocPhi_cbChuyenNganh.Items.Clear();
            HocPhi_cbLop.Items.Clear();
            BieuDo_cbKhoa.Items.Clear();
            BieuDo_cbChuyenNganh.Items.Clear();
            BieuDo_cbLop.Items.Clear();
            //Them ma khoa vao combo box khoa
            foreach (DataRow row in bus_KHOA.GetData().Rows)
            {
                SinhVien_cbKhoa.Items.Add(row[0]);
                HocPhi_cbKhoa.Items.Add(row[0]);
                BieuDo_cbKhoa.Items.Add(row[0]);
            }
            //Them ma chuyen nganh vao combo box chuyen nganh
            foreach (DataRow row in bus_CN.GetData().Rows)
            {
                SinhVien_cbChuyenNganh.Items.Add(row[0]);
                HocPhi_cbChuyenNganh.Items.Add(row[0]);
                BieuDo_cbChuyenNganh.Items.Add(row[0]);
            }
            //Them ma lop vao combo box lop
            foreach (DataRow row in bus_LOP.GetData().Rows)
            {
                SinhVien_cbLop.Items.Add(row[0]);
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
            load_SinhVien_dgvHienThi();
            load_HocPhi_dgvHienThi();
        }


        //====================================
        //XU LY SU KIEN VALUE CHANGE COMBO BOX
        //====================================

        private void SinhVien_cbKhoa_SelectedValueChanged(object sender, EventArgs e)
        {
            SinhVien_dgvHienThi.DataSource = bus_SV.GetDataByCondition(SinhVien_cbKhoa.Text, SinhVien_cbChuyenNganh.Text, SinhVien_cbLop.Text);
            SinhVien_cbChuyenNganh.Items.Clear();
            SinhVien_cbLop.Items.Clear();
            foreach (DataRow row in bus_CN.GetDataByMAKHOA(SinhVien_cbKhoa.Text).Rows)
            {
                SinhVien_cbChuyenNganh.Items.Add(row[0]);
            }
            //Them ma lop vao combo box lop
            foreach (DataRow row in bus_LOP.GetDataByMAKHOA(SinhVien_cbKhoa.Text).Rows)
            {
                SinhVien_cbLop.Items.Add(row[0]);
            }
        }

        private void SinhVien_cbChuyenNganh_SelectedValueChanged(object sender, EventArgs e)
        {
            SinhVien_dgvHienThi.DataSource = bus_SV.GetDataByCondition(SinhVien_cbKhoa.Text, SinhVien_cbChuyenNganh.Text, SinhVien_cbLop.Text);
            SinhVien_cbLop.Items.Clear();
            foreach (DataRow row in bus_LOP.GetdataByMACN(SinhVien_cbChuyenNganh.Text).Rows)
            {
                SinhVien_cbLop.Items.Add(row[0]);
            }
        }

        private void SinhVien_cbLop_SelectedValueChanged(object sender, EventArgs e)
        {
            SinhVien_dgvHienThi.DataSource = bus_SV.GetDataByCondition(SinhVien_cbKhoa.Text, SinhVien_cbChuyenNganh.Text, SinhVien_cbLop.Text);
        }

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

        private void btReset_Click(object sender, EventArgs e)
        {
            this.fQuanLy_BaoCao_Load(sender, e);
            SinhVien_cbKhoa.Text = null;
            SinhVien_cbChuyenNganh.Text = null;
            SinhVien_cbLop.Text = null;
        }

        private void btXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Workbook workbook = excelApp.Workbooks.Add();
            Worksheet worksheet = (Worksheet)workbook.Worksheets[1];

            // Tạo tiêu đề
            Excel.Range header = worksheet.Range["A1", "I1"];
            header.MergeCells = true;
            header.Value = "DANH SÁCH SINH VIÊN";
            header.Font.Size = 25;
            header.Font.Bold = true;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Tạo các cột cho bảng
            Excel.Range headerRange = worksheet.Range["A2", "I2"];
            headerRange.Font.Size = 13;
            headerRange.ColumnWidth = 20;
            headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            for (int i = 0; i < SinhVien_dgvHienThi.Columns.Count; i++)
            {
                headerRange.Cells[1, i + 1].Value = SinhVien_dgvHienThi.Columns[i].HeaderText.ToString();
            }

            // Thêm dữ liệu vào excel
            for (int row = 0; row < SinhVien_dgvHienThi.Rows.Count - 1; row++)
            {
                for (int col = 0; col < SinhVien_dgvHienThi.Rows[row].Cells.Count; col++)
                {
                    if (col == 5 && SinhVien_dgvHienThi.Rows[row].Cells[col].Value != null)
                    {
                        worksheet.Cells[row + 3, col + 1] = DateTime.Parse(SinhVien_dgvHienThi.Rows[row].Cells[col].Value.ToString()).ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        worksheet.Cells[row + 3, col + 1] = SinhVien_dgvHienThi.Rows[row].Cells[col].Value.ToString();
                    }
                }
            }

            // Tạo bảng trong excel
            Excel.Range dataRange = worksheet.Range["A2", $"I{SinhVien_dgvHienThi.Rows.Count + 1}"];
            dataRange.Borders.Color = Color.Black;
            Excel.ListObject table = worksheet.ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, dataRange, Type.Missing, Excel.XlYesNoGuess.xlYes);
            string tableName = "MyTable";
            table.Name = tableName;

            table.TableStyle = "TableStyleMedium2"; // Áp dụng một kiểu bảng
            table.HeaderRowRange.Font.Bold = true; // Đặt in đậm cho hàng đầu tiên của bảng
            table.HeaderRowRange.Interior.Color = Color.YellowGreen; // Đặt màu nền cho hàng đầu tiên của bảng

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
            Excel.Range header = worksheet.Range["A1", "E1"];
            header.MergeCells = true;
            header.Value = "DANH SÁCH HỌC PHÍ CỦA SINH VIÊN";
            header.Font.Size = 25;
            header.Font.Bold = true;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            // Tạo các cột cho bảng
            Excel.Range headerRange = worksheet.Range["A2", "E2"];
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
            Excel.Range dataRange = worksheet.Range["A2", $"E{HocPhi_dgvHienThi.Rows.Count + 1}"];
            dataRange.Borders.Color = Color.Black;
            Excel.ListObject table = worksheet.ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, dataRange, Type.Missing, Excel.XlYesNoGuess.xlYes);
            string tableName = "MyTable";
            table.Name = tableName;

            table.TableStyle = "TableStyleMedium2"; // Áp dụng một kiểu bảng
            table.HeaderRowRange.Font.Bold = true; // Đặt in đậm cho hàng đầu tiên của bảng
            table.HeaderRowRange.Interior.Color = Color.YellowGreen; // Đặt màu nền cho hàng đầu tiên của bảng

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
    }
}
