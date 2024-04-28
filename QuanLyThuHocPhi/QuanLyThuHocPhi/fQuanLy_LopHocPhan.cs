using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObject.LopHocPhan;
using ValueObject.ChuyenNganh;
using ValueObject.GiangVien;
using BusinessLogicLayer;
using Excel = Microsoft.Office.Interop.Excel;
using ValueObject.MonHoc;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy_LopHocPhan : Form
    {
        private LOPHOCPHAN obj = new LOPHOCPHAN();
        private LOPHOCPHANBUS bus = new LOPHOCPHANBUS();
        public fQuanLy_LopHocPhan()
        {
            InitializeComponent();
        }

        public async void addDataComboBox(object sender, EventArgs e)
        {
            //ComboBox Hoc ky
            cbHocKy.Items.Add("1");
            cbHocKy.Items.Add("2");
            cbHocKy.Items.Add("3");
            cbHocKy.Items.Add("4");
            cbHocKy.Items.Add("5");
            cbHocKy.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbHocKy.AutoCompleteSource = AutoCompleteSource.ListItems;
            //ComboBox Ma mon hoc
            MONHOCBUS tempMonHoc = new MONHOCBUS();
            List<MONHOC> dsMonHoc = await tempMonHoc.GetData();
            foreach (MONHOC monhoc in dsMonHoc)
            {
                cbMaMH.Items.Add(monhoc.MAMH);
            }
            //Them tu dong hoan thanh va tim kiem gan dung cho combo box
            cbMaMH.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaMH.AutoCompleteSource = AutoCompleteSource.ListItems;
            //ComboBox Ma giao vien
            GIANGVIENBUS tempGiangVien = new GIANGVIENBUS();
            List<GIANGVIEN> dsGV = await tempGiangVien.GetData();
            foreach (GIANGVIEN giangvien in dsGV)
            {
                cbMaGV.Items.Add(giangvien.MAGV);
            }
            cbMaGV.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaGV.AutoCompleteSource = AutoCompleteSource.ListItems;
            //ComboBox Ma chuyen nganh
            CHUYENNGANHBUS temp = new CHUYENNGANHBUS();
            List<CHUYENNGANH> dsChuyenNganh = null;
            dsChuyenNganh = await temp.GetData();

            foreach (CHUYENNGANH obj in dsChuyenNganh)
            {
                cbMaCN.Items.Add(obj.MACN);
            }
            cbMaCN.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaCN.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public async void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = await bus.GetData();
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã lớp học phần";
            dgvHienThi.Columns[1].HeaderText = "Niên khóa";
            dgvHienThi.Columns[2].HeaderText = "Học kỳ";
            dgvHienThi.Columns[3].HeaderText = "Mã môn học";
            dgvHienThi.Columns[4].HeaderText = "Mã giáo viên";
            dgvHienThi.Columns[5].HeaderText = "Mã chuyên ngành";
            dgvHienThi.Columns[6].HeaderText = "Hủy lớp";
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaLHP.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbNienKhoa.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            cbHocKy.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
            cbMaMH.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
            cbMaGV.Text = dgvHienThi.SelectedRows[0].Cells[4].Value.ToString();
            cbMaCN.Text = dgvHienThi.SelectedRows[0].Cells[5].Value.ToString();
            if (bool.Parse(dgvHienThi.SelectedRows[0].Cells[6].Value.ToString()))
            {
                rdbTrue.Checked = true;
            }
            else
            {
                rdbFalse.Checked = true;
            }
        }

        private void fAdmin_LopHocPhan_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
        }

        private async void btThem_Click(object sender, EventArgs e)
        {
            obj.NIENKHOA = txbNienKhoa.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            obj.MAMH = cbMaMH.Text;
            obj.MAGV = cbMaGV.Text;
            obj.MACN = cbMaCN.Text;
            if (rdbTrue.Checked == true)
            {
                obj.HUYLOP = true;
            }else
            {
                obj.HUYLOP = false;
            }
            if (await bus.GetData(int.Parse(txbMaLHP.Text)) == null)
            {
                await bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã lớp học phần đã tồn tại, vui lòng nhập mã khoa khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMaLHP.Focus();
            }
        }

        private async void btSua_Click(object sender, EventArgs e)
        {
            obj.MALHP = int.Parse(txbMaLHP.Text);
            obj.NIENKHOA = txbNienKhoa.Text;
            obj.HOCKY = int.Parse(cbHocKy.Text);
            obj.MAMH = cbMaMH.Text;
            obj.MAGV = cbMaGV.Text;
            obj.MACN = cbMaCN.Text;
            if (rdbTrue.Checked == true)
            {
                obj.HUYLOP = true;
            }
            else
            {
                obj.HUYLOP = false;
            }
            if (await bus.GetData(int.Parse(txbMaLHP.Text)) != null)
            {
                await bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã lớp học phần không tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMaLHP.Focus();
            }
        }

        private async void btXoa_Click(object sender, EventArgs e)
        {
            if (await bus.GetData(int.Parse(txbMaLHP.Text)) != null)
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa lớp học phần này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    await bus.Delete(int.Parse(txbMaLHP.Text));
                    MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã khoa không tồn tại, vui lòng nhập mã lớp học phần khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txbMaLHP.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            txbNienKhoa.Text = "";
            cbHocKy.Text = "";
            cbMaMH.Text = "";
            cbMaGV.Text = "";
            cbMaCN.Text = "";
            rdbTrue.Checked = false;
            rdbFalse.Checked = false;
        }

        private async void cbMaCN_SelectedValueChanged(object sender, EventArgs e)
        {
            CHUONGTRINHHOCBUS bus_CTH = new CHUONGTRINHHOCBUS();
            //Thêm lại môn học thuộc về chuyên ngành X
            cbMaMH.Items.Clear();
            DataTable dt = new DataTable();
            List<MONHOC> dsMonHoc = await bus_CTH.GetDataByChuyenNganh(cbMaCN.Text);

            foreach (MONHOC monhoc in dsMonHoc)
            {
                cbMaMH.Items.Add(monhoc.MAMH);
            }

            dgvHienThi.DataSource = await bus.GetDataByChuyenNganh(cbMaCN.Text);
        }

        private void btXuatExcel_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];

            //Tạo tiêu đề
            Excel.Range header = worksheet.Range["A1", "G1"];
            header.MergeCells = true;
            header.Value = "DANH SÁCH LỚP HỌC PHẦN";
            header.Font.Size = 25;
            header.Font.Bold = true;
            header.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            //Tạo các cột cho bảng
            Excel.Range columnHeader = worksheet.Range["A2", "G2"];
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
            Excel.Range dataRange = worksheet.Range["A2", $"G{dgvHienThi.Rows.Count + 1}"];
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

                    obj.MALHP = int.Parse(worksheet.Cells[row, 1].Value.ToString());
                    obj.NIENKHOA = worksheet.Cells[row, 2].Value.ToString();
                    obj.HOCKY = int.Parse(worksheet.Cells[row, 3].Value.ToString());
                    obj.MAMH = worksheet.Cells[row, 4].Value.ToString();
                    obj.MAGV = worksheet.Cells[row, 5].Value.ToString();
                    obj.MACN = worksheet.Cells[row, 6].Value.ToString();
                    obj.HUYLOP = bool.Parse(worksheet.Cells[row, 7].Value.ToString());
                    if (await bus.GetData(obj.MALHP) == null)
                    {
                        await bus.Insert(obj);
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
