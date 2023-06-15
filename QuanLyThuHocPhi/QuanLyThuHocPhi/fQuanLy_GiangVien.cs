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
    public partial class fQuanLy_GiangVien : Form
    {
        private GIANGVIEN obj = new GIANGVIEN();
        private GIANGVIENBUS bus = new GIANGVIENBUS();

        public fQuanLy_GiangVien()
        {
            InitializeComponent();
        }

        public void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData();
            dgvHienThi.ReadOnly = true;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Mã giảng viên";
            dgvHienThi.Columns[1].HeaderText = "Mã khoa";
            dgvHienThi.Columns[2].HeaderText = "Họ giảng viên";
            dgvHienThi.Columns[3].HeaderText = "Tên giảng viên";
            dgvHienThi.Columns[4].HeaderText = "Học hàm";
        }

        public void addDataComboBox(object sender, EventArgs e)
        {
            //ComboBox Ma Khoa
            KHOABUS temp = new KHOABUS();
            DataTable tb = new DataTable();
            tb = temp.GetData();
            foreach(DataRow row in tb.Rows)
            {
                cbMaKhoa.Items.Add(row[0].ToString());
            }
            cbMaKhoa.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;
            //ComboBox Hoc Ham
            cbHocHam.Items.Add("Tiến Sĩ");
            cbHocHam.Items.Add("Thạc Sĩ");
            cbHocHam.Items.Add("Giáo Sư");
            cbHocHam.Items.Add("P.Giáo sư");
            cbHocHam.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbHocHam.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaGV.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            cbMaKhoa.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            txbHoGV.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
            txbTenGV.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
            cbHocHam.Text = dgvHienThi.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void fAdmin_GiangVien_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MAGV = txbMaGV.Text;
            obj.MAKHOA = cbMaKhoa.Text;
            obj.HO = txbHoGV.Text;
            obj.TEN = txbTenGV.Text;
            obj.HOCHAM = cbHocHam.Text;
            if (bus.GetData(txbMaGV.Text).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã giảng viên đã tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaGV.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj.MAGV = txbMaGV.Text;
            obj.MAKHOA = cbMaKhoa.Text;
            obj.HO = txbHoGV.Text;
            obj.TEN = txbTenGV.Text;
            obj.HOCHAM = cbHocHam.Text;
            if (bus.GetData(txbMaGV.Text).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã giảng viên không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaGV.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(txbMaGV.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa giảng viên này không?", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(txbMaGV.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã lớp không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaGV.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaGV.Text = "";
            cbMaKhoa.Text = "";
            txbHoGV.Text = "";
            txbTenGV.Text = "";
            cbHocHam.Text = "";
        }

        private void btXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];

            //Tạo tiêu đề
            Excel.Range header = worksheet.Range["A1", "E1"];
            header.MergeCells = true;
            header.Value = "DANH SÁCH GIẢNG VIÊN";
            header.Font.Size = 25;
            header.Font.Bold = true;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Tạo các cột cho bảng
            Excel.Range columnHeader = worksheet.Range["A2", "E2"];
            columnHeader.Font.Size = 13;
            columnHeader.ColumnWidth = 20;
            columnHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

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
            Excel.Range dataRange = worksheet.Range["A2", $"E{dgvHienThi.Rows.Count + 1}"];
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

                obj.MAGV = worksheet.Cells[row, 1].Value.ToString();
                obj.MAKHOA = worksheet.Cells[row, 2].Value.ToString();
                obj.HO = worksheet.Cells[row, 3].Value.ToString();
                obj.TEN = worksheet.Cells[row, 4].Value.ToString();
                obj.HOCHAM = worksheet.Cells[row, 5].Value.ToString();
                if (bus.GetData(obj.MAGV).Rows.Count == 0)
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
