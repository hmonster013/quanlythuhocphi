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
    public partial class fQuanLy_SinhVien : Form
    {
        private SINHVIEN obj_SV = new SINHVIEN();
        private NGUOIDUNG obj_ND = new NGUOIDUNG();
        private SINHVIENBUS bus_SV = new SINHVIENBUS();
        private NGUOIDUNGBUS bus_ND = new NGUOIDUNGBUS();
        public fQuanLy_SinhVien()
        {
            InitializeComponent();
        }

        public void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus_SV.GetData();
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã sinh viên";
            dgvHienThi.Columns[1].HeaderText = "Họ sinh viên";
            dgvHienThi.Columns[2].HeaderText = "Tên sinh viên";
            dgvHienThi.Columns[3].HeaderText = "Mã lớp";
            dgvHienThi.Columns[4].HeaderText = "Giới tính";
            dgvHienThi.Columns[5].HeaderText = "Ngày sinh";
            dgvHienThi.Columns[6].HeaderText = "Địa chỉ";
            dgvHienThi.Columns[7].HeaderText = "Đang nghỉ học";
            dgvHienThi.Columns[8].HeaderText = "Tên tài khoản";
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaSV.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbHoSV.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            txbTenSV.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
            txbDiaChi.Text = dgvHienThi.SelectedRows[0].Cells[6].Value.ToString();
            txbMaSV.Text = dgvHienThi.SelectedRows[0].Cells[8].Value.ToString();
            if (bool.Parse(dgvHienThi.SelectedRows[0].Cells[4].Value.ToString()) == true)
            {
                rdbNu.Checked = true;
            }
            else
            {
                rdbNam.Checked = true;
            }
            if (bool.Parse(dgvHienThi.SelectedRows[0].Cells[7].Value.ToString()) == true)
            {
                rdbTrue.Checked = true;
            }
            else
            {
                rdbFalse.Checked = true;
            }
            dtpNgaySinh.Value = DateTime.Parse(dgvHienThi.SelectedRows[0].Cells[5].Value.ToString());
            cbMaLop.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void addDataComboBox(object sender, EventArgs e)
        {
            LOPBUS tempLop = new LOPBUS();
            KHOABUS tempKhoa = new KHOABUS();
            DataTable dtLop = tempLop.GetData();
            DataTable dtKhoa = tempKhoa.GetData();
            //ComboBox Ma Lop
            foreach (DataRow row in dtLop.Rows)
            {
                cbMaLop.Items.Add(row[0].ToString());
            }
            cbMaLop.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaLop.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void fAdmin_SinhVien_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            //Gán dữ liệu cho obj_SV
            obj_SV.MASV = txbMaSV.Text;
            obj_SV.HO = txbHoSV.Text;
            obj_SV.TEN = txbTenSV.Text;
            obj_SV.DIACHI = txbDiaChi.Text;
            obj_SV.TENTAIKHOAN = txbMaSV.Text;
            if (rdbNam.Checked == true)
            {
                obj_SV.PHAI = false;
            }
            if (rdbNu.Checked == true)
            {
                obj_SV.PHAI = true;
            }
            if (rdbTrue.Checked == true)
            {
                obj_SV.DANGNGHIHOC = true;
            }
            if (rdbFalse.Checked == true)
            {
                obj_SV.DANGNGHIHOC = false;
            }
            obj_SV.NGAYSINH = dtpNgaySinh.Value;
            obj_SV.MALOP = cbMaLop.Text;
            //Gán dữ liệu cho obj người dùng
            obj_ND.TENTAIKHOAN = txbMaSV.Text.ToString();
            obj_ND.MATKHAU = "1";
            obj_ND.QUYEN = "User";
            if (bus_SV.GetData(txbMaSV.Text).Rows.Count == 0)
            {
                bus_ND.Insert(obj_ND);
                bus_SV.Insert(obj_SV);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã sinh viên đã tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaSV.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            obj_SV.MASV = txbMaSV.Text;
            obj_SV.HO = txbHoSV.Text; ;
            obj_SV.TEN = txbTenSV.Text;
            obj_SV.DIACHI = txbDiaChi.Text;
            obj_SV.TENTAIKHOAN = txbMaSV.Text;
            if (rdbNam.Checked == true)
            {
                obj_SV.PHAI = false;
            }
            if (rdbNu.Checked == true)
            {
                obj_SV.PHAI = true;
            }
            if (rdbTrue.Checked == true)
            {
                obj_SV.DANGNGHIHOC = true;
            }
            if (rdbFalse.Checked == true)
            {
                obj_SV.DANGNGHIHOC = false;
            }
            obj_SV.NGAYSINH = dtpNgaySinh.Value;
            obj_SV.MALOP = cbMaLop.Text;
            if (bus_SV.GetData(txbMaSV.Text).Rows.Count != 0)
            {
                bus_SV.Update(obj_SV);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã sinh viên không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaSV.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus_SV.GetData(txbMaSV.Text).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa sinh viên này không?", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus_SV.Delete(txbMaSV.Text);
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã sinh viên không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaSV.Focus();
            }
        }

        private void btNhapExcel_Click(object sender, EventArgs e)
        {

        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbMaSV.Text = "";
            txbHoSV.Text = "";
            txbTenSV.Text = "";
            txbDiaChi.Text = "";
            txbMaSV.Text = "";
            rdbNam.Checked = false;
            rdbNu.Checked = false;
            rdbTrue.Checked = false;
            rdbFalse.Checked = false;
            dtpNgaySinh.Value = DateTime.Now;
            cbMaLop.Text = "";
        }

        private void btXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];

            //Tạo tiêu đề
            Excel.Range header = worksheet.Range["A1", "I1"];
            header.MergeCells = true;
            header.Value = "DANH SÁCH SINH VIÊN";
            header.Font.Size = 25;
            header.Font.Bold = true;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Tạo các cột cho bảng
            Excel.Range columnHeader = worksheet.Range["A2", "I2"];
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
            Excel.Range dataRange = worksheet.Range["A2", $"I{dgvHienThi.Rows.Count + 1}"];
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

        private void btNhapExcel_Click_1(object sender, EventArgs e)
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

                obj_SV.MASV = worksheet.Cells[row, 1].Value.ToString();
                obj_SV.HO = worksheet.Cells[row, 2].Value.ToString();
                obj_SV.TEN = worksheet.Cells[row, 3].Value.ToString();
                obj_SV.MALOP = worksheet.Cells[row, 4].Value.ToString();
                obj_SV.PHAI = bool.Parse(worksheet.Cells[row, 5].Value.ToString());
                obj_SV.NGAYSINH = DateTime.Parse(worksheet.Cells[row, 6].Value.ToString());
                obj_SV.DIACHI = worksheet.Cells[row, 7].Value.ToString();
                obj_SV.DANGNGHIHOC = bool.Parse(worksheet.Cells[row, 8].Value.ToString());
                obj_SV.TENTAIKHOAN = worksheet.Cells[row, 9].Value.ToString();

                obj_ND.TENTAIKHOAN = obj_SV.TENTAIKHOAN;
                obj_ND.MATKHAU = "1";
                obj_ND.QUYEN = "User";
                if (bus_SV.GetData(obj_SV.MASV).Rows.Count == 0)
                {
                    bus_ND.Insert(obj_ND);
                    bus_SV.Insert(obj_SV);
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
