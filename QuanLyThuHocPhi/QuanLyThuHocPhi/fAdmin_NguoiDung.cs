using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObject.NguoiDung;
using BusinessLogicLayer;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyThuHocPhi
{
    public partial class fAdmin_NguoiDung : Form
    {
        private NGUOIDUNG obj;
        private NGUOIDUNGBUS bus_ND;
        private SINHVIENBUS bus_SV;
        public fAdmin_NguoiDung()
        {
            obj = new NGUOIDUNG();
            bus_ND = new NGUOIDUNGBUS();
            bus_SV = new SINHVIENBUS();
            InitializeComponent();
        }

        private async void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = await bus_ND.GetData();
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.Columns[0].HeaderText = "Tên tài khoản";
            dgvHienThi.Columns[1].HeaderText = "Mật khẩu";
            dgvHienThi.Columns[2].HeaderText = "Quyền";
        }

        private void addDataComboBox(object sender, EventArgs e)
        {
            cbQuyen.Items.Add("Admin");
            cbQuyen.Items.Add("QuanLy");
            cbQuyen.Items.Add("User");
        }
        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbTenTK.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbMatKhau.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            cbQuyen.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void fAdmin_NguoiDung_Load(object sender, EventArgs e)
        {
            load_dgvHienThi(sender, e);
            addDataComboBox(sender, e);
        }

        private async void btThem_Click(object sender, EventArgs e)
        {
            if (txbTenTK.Text == "" || txbMatKhau.Text == "" || cbQuyen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else
            {
                obj.TENTAIKHOAN = txbTenTK.Text;
                obj.MATKHAU = txbMatKhau.Text;
                obj.QUYEN = cbQuyen.Text;
                if (await bus_ND.GetDataByID(txbTenTK.Text) == null)
                {
                    await bus_ND.Insert(obj);
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    load_dgvHienThi(sender, e);
                }
                else
                {
                    MessageBox.Show("Tài khoản đã tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbTenTK.Focus();
                }
            }
        }

        private async void btSua_Click(object sender, EventArgs e)
        {
            if (txbTenTK.Text == "" || txbMatKhau.Text == "" || cbQuyen.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
            else
            {
                obj.TENTAIKHOAN = txbTenTK.Text;
                obj.MATKHAU = txbMatKhau.Text;
                obj.QUYEN = cbQuyen.Text;
                if (bus_ND.GetDataByID(txbTenTK.Text) != null)
                {
                    await bus_ND.Update(obj);
                    MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    load_dgvHienThi(sender, e);
                }
                else
                {
                    MessageBox.Show("Tên tài khoản không tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbTenTK.Focus();
                }
            }
        }

        private async void btXoa_Click(object sender, EventArgs e)
        {
            if (txbTenTK.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (await bus_ND.GetDataByID(txbTenTK.Text) != null)
                {
                    DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa tài khoản này không?", "Thống báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        if (await bus_SV.GetData(txbTenTK.Text) != null)
                        {
                            await bus_SV.Delete(txbTenTK.Text);
                        }
                        await bus_ND.Delete(txbTenTK.Text);
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btReset_Click(sender, e);
                        load_dgvHienThi(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Tài khoản không tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbTenTK.Focus();
                }
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbTenTK.Text = "";
            txbMatKhau.Text = "";
            cbQuyen.Text = "";
        }

        private void btXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];

            //Tạo tiêu đề
            Excel.Range header = worksheet.Range["A1", "C1"];
            header.MergeCells = true;
            header.Value = "DANH SÁCH TÀI KHOẢN";
            header.Font.Size = 25;
            header.Font.Bold = true;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Tạo các cột cho bảng
            Excel.Range columnHeader = worksheet.Range["A2", "C2"];
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

        private async void btNhapExcel_Click(object sender, EventArgs e)
        {
            // Tạo một OpenFileDialog để chọn file Excel
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            string filePath = null;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn của file Excel đã chọn
                filePath = openFileDialog.FileName;

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

                    obj.TENTAIKHOAN = worksheet.Cells[row, 1].Value.ToString();
                    obj.MATKHAU = worksheet.Cells[row, 2].Value.ToString();
                    obj.QUYEN = worksheet.Cells[row, 3].Value.ToString();
                    if (await bus_ND.GetDataByID(obj.TENTAIKHOAN) != null)
                    {
                        await bus_ND.Insert(obj);
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
}
