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
using BusinessLogicLayer;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy_ChuyenNganh : Form
    {
        private CHUYENNGANH obj = new CHUYENNGANH();
        private CHUYENNGANHBUS bus = new CHUYENNGANHBUS();

        public fQuanLy_ChuyenNganh()
        {
            InitializeComponent();
        }

        public void load_dgvHienThi()
        {
            dgvHienThi.DataSource = bus.GetData();
            dgvHienThi.ReadOnly = true;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Mã chuyên ngành";
            dgvHienThi.Columns[1].HeaderText = "Tên chuyên ngành";
            dgvHienThi.Columns[2].HeaderText = "Mã khoa";

            if (dgvHienThi.Columns.Count == 3)
            {
                DataGridViewButtonColumn btChuongTrinhHoc = new DataGridViewButtonColumn();
                btChuongTrinhHoc.Name = "btChuongTrinhHoc";
                btChuongTrinhHoc.HeaderText = "";
                btChuongTrinhHoc.Text = "Chương trình học";
                btChuongTrinhHoc.UseColumnTextForButtonValue = true;

                dgvHienThi.Columns.Add(btChuongTrinhHoc);
            }
        }

        public void addDataComboBox()
        {
            //ComboBox Ma Khoa
            KHOABUS temp = new KHOABUS();
            DataTable tb = new DataTable();
            tb = temp.GetData();
            foreach (DataRow row in tb.Rows)
            {
                cbMaKhoa.Items.Add(row[0].ToString());
            }
            cbMaKhoa.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaKhoa.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaCN.Text = dgvHienThi.SelectedRows[0].Cells["MACN"].Value.ToString();
            txbTenCN.Text = dgvHienThi.SelectedRows[0].Cells["TENCN"].Value.ToString();
            cbMaKhoa.Text = dgvHienThi.SelectedRows[0].Cells["MAKHOA"].Value.ToString();
        }

        private void fQuanLy_ChuyenNganh_Load(object sender, EventArgs e)
        {
            addDataComboBox();
            load_dgvHienThi();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            obj.MACN = txbMaCN.Text;
            obj.TENCN = txbTenCN.Text;
            obj.MAKHOA = cbMaKhoa.Text;
            if (bus.GetData(txbMaCN.Text).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi();
            }
            else
            {
                MessageBox.Show("Mã chuyên ngành đã tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaCN.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj.MACN = txbMaCN.Text;
            obj.TENCN = txbTenCN.Text;
            obj.MAKHOA = cbMaKhoa.Text;
            if (bus.GetData(txbMaCN.Text).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi();
            }
            else
            {
                MessageBox.Show("Mã chuyên ngành không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaCN.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(txbMaCN.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa chuyên ngành này không?", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(txbMaCN.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi();
                }
            }
            else
            {
                MessageBox.Show("Mã chuyên ngành không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaCN.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaCN.Text = "";
            txbTenCN.Text = "";
            cbMaKhoa.Text = "";
        }

        private void dgvHienThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvHienThi.Columns[e.ColumnIndex].Name == "btChuongTrinhHoc")
            {
                fQuanLy_ChuyenNganh_ChuongTrinhHoc ftemp = new fQuanLy_ChuyenNganh_ChuongTrinhHoc(dgvHienThi.Rows[e.RowIndex].Cells["MACN"].Value.ToString());
                ftemp.ShowDialog();
            }
        }

        private void btXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];

            //Tạo tiêu đề
            Excel.Range header = worksheet.Range["A1", "C1"];
            header.MergeCells = true;
            header.Value = "DANH SÁCH CHUYÊN NGÀNH";
            header.Font.Size = 25;
            header.Font.Bold = true;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Tạo các cột cho bảng
            Excel.Range columnHeader = worksheet.Range["A2", "C2"];
            columnHeader.Font.Size = 13;
            columnHeader.ColumnWidth = 20;
            columnHeader.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            for (int i = 1; i < dgvHienThi.Columns.Count; i++)
            {
                columnHeader.Cells[1, i].Value = dgvHienThi.Columns[i].HeaderText.ToString();
            }

            // Thêm dữ liệu vào excel
            for (int row = 0; row < dgvHienThi.Rows.Count - 1; row++)
            {
                for (int col = 1; col < dgvHienThi.Rows[row].Cells.Count; col++)
                {
                    worksheet.Cells[row + 3, col] = dgvHienThi.Rows[row].Cells[col].Value.ToString();
                }
            }

            // Tạo bảng trong excel
            Excel.Range dataRange = worksheet.Range["A2", $"C{dgvHienThi.Rows.Count + 1}"];
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

                obj.MACN = worksheet.Cells[row, 1].Value.ToString();
                obj.TENCN = worksheet.Cells[row, 2].Value.ToString();
                obj.MAKHOA = worksheet.Cells[row, 3].Value.ToString();
                if (bus.GetData(obj.MACN).Rows.Count == 0)
                {
                    bus.Insert(obj);
                }
                row++;
            }
            load_dgvHienThi();
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
