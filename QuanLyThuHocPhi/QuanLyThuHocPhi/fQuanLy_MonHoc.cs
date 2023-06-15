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
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy_MonHoc : Form
    {
        private MONHOC obj = new MONHOC();
        private MONHOCBUS bus = new MONHOCBUS();

        public fQuanLy_MonHoc()
        {
            InitializeComponent();
        }

        public void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData();
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Mã môn học";
            dgvHienThi.Columns[1].HeaderText = "Tên môn học";
            dgvHienThi.Columns[2].HeaderText = "Học kỳ";
            dgvHienThi.Columns[3].HeaderText = "Số tín chỉ";
        }

        public void addDataComboBox(object sender, EventArgs e)
        {
            //combobox Hoc ky
            cbHocKy.Items.Add("1");
            cbHocKy.Items.Add("2");
            cbHocKy.Items.Add("3");
            cbHocKy.Items.Add("4");
            cbHocKy.Items.Add("5");
        }
        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaMH.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbTenMH.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            cbHocKy.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
            txbSoTC.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void fAdmin_MonHoc_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MAMH = txbMaMH.Text;
            obj.TENMH = txbTenMH.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            obj.SOTINCHI = int.Parse(txbSoTC.Text);
            if (bus.GetData(txbMaMH.Text).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã môn học đã tồn tại, vui lòng nhập mã môn học khác", "Thông báo");
                txbMaMH.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj.MAMH = txbMaMH.Text;
            obj.TENMH = txbTenMH.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            obj.SOTINCHI = int.Parse(txbSoTC.Text);
            if (bus.GetData(txbMaMH.Text).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã môn học không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaMH.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(txbMaMH.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa môn học này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(txbMaMH.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã môn học không tồn tại, vui lòng nhập mã môn học khác", "Thông báo");
                txbMaMH.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaMH.Text = "";
            txbTenMH.Text = "";
            cbHocKy.Text = "";
            txbSoTC.Text = "";
        }

        private void btXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];

            //Tạo tiêu đề
            Excel.Range header = worksheet.Range["A1", "D1"];
            header.MergeCells = true;
            header.Value = "DANH SÁCH MÔN HỌC";
            header.Font.Size = 25;
            header.Font.Bold = true;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Tạo các cột cho bảng
            Excel.Range columnHeader = worksheet.Range["A2", "D2"];
            columnHeader.Font.Size = 13;
            columnHeader.ColumnWidth = 20;
            columnHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            worksheet.Columns["B"].ColumnWidth = 40;

            for (int i = 0; i < dgvHienThi.Columns.Count; i++)
            {
                columnHeader.Cells[1, i + 1].Value = dgvHienThi.Columns[i].HeaderText.ToString();
            }

            // Thêm dữ liệu vào excel
            for (int row = 0; row < dgvHienThi.Rows.Count - 1; row++)
            {
                for (int col = 0; col < dgvHienThi.Rows[row].Cells.Count; col++)
                {
                    worksheet.Cells[row + 3, col + 1] = dgvHienThi.Rows[row].Cells[col].Value.ToString();
                }
            }

            // Tạo bảng trong excel
            Excel.Range dataRange = worksheet.Range["A2", $"D{dgvHienThi.Rows.Count + 1}"];
            dataRange.Borders.Color = Color.Black;
            Excel.ListObject table = worksheet.ListObjects.AddEx(Excel.XlListObjectSourceType.xlSrcRange, dataRange, Type.Missing, Excel.XlYesNoGuess.xlYes);
            string tableName = "MyTable";
            table.Name = tableName;

            table.TableStyle = "TableStyleMedium2"; // Áp dụng một kiểu bảng
            table.HeaderRowRange.Font.Bold = true; // Đặt in đậm cho hàng đầu tiên của bảng
            table.HeaderRowRange.Interior.Color = Color.YellowGreen; // Đặt màu nền cho hàng đầu tiên của bảng

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx";
            sfd.Title = "Save Excel File";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfd.FileName;
                workbook.SaveAs(filePath);
            }
            workbook.Close();
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }

        private void btNhapExcel_Click(object sender, EventArgs e)
        {
            // Tạo một OpenFileDialog để chọn file Excel
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            string filePath = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của file Excel đã chọn
                filePath = openFileDialog.FileName;
            }

            // Khởi tạo một đối tượng Excel.Application
            Excel.Application excelApp = new Excel.Application();

            // Mở file Excel
            Excel.Workbook workbook = excelApp.Workbooks.Open(filePath);

            // Lấy Sheet đầu tiên từ Workbook
            Excel.Worksheet worksheet = workbook.Sheets[1];

            // Đọc dữ liệu từ Sheet
            int row = 3;
            while (worksheet.Cells[row, 1].Value != null)
            {

                obj.MAMH = worksheet.Cells[row, 1].Value.ToString();
                obj.TENMH = worksheet.Cells[row, 2].Value.ToString();
                obj.HOCKY = int.Parse(worksheet.Cells[row, 3].Value.ToString());
                obj.SOTINCHI = int.Parse(worksheet.Cells[row, 4].Value.ToString());
                if (bus.GetData(obj.MAMH).Rows.Count == 0)
                {
                    bus.Insert(obj);
                }
                row++;
            }
            load_dgvHienThi(sender, e);
            // Đóng Workbook và thoát khỏi ứng dụng Excel
            workbook.Close();
            excelApp.Quit();

            // Giải phóng bộ nhớ
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
        }
    }
}
