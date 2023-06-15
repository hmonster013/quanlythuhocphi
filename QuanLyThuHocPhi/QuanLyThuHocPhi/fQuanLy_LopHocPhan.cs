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
    public partial class fQuanLy_LopHocPhan : Form
    {
        private LOPHOCPHAN obj = new LOPHOCPHAN();
        private LOPHOCPHANBUS bus = new LOPHOCPHANBUS();
        public fQuanLy_LopHocPhan()
        {
            InitializeComponent();
        }

        public void addDataComboBox(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
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
            dt = tempMonHoc.GetData();
            foreach (DataRow row in dt.Rows)
            {
                cbMaMH.Items.Add(row[0].ToString());
            }
            //Them tu dong hoan thanh va tim kiem gan dung cho combo box
            cbMaMH.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaMH.AutoCompleteSource = AutoCompleteSource.ListItems;
            //ComboBox Ma giao vien
            GIANGVIENBUS tempGiangVien = new GIANGVIENBUS();
            dt = tempGiangVien.GetData();
            foreach (DataRow row in dt.Rows)
            {
                cbMaGV.Items.Add(row[0].ToString());
            }
            cbMaGV.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaGV.AutoCompleteSource = AutoCompleteSource.ListItems;
            //ComboBox Ma chuyen nganh
            CHUYENNGANHBUS temp = new CHUYENNGANHBUS();
            dt = new DataTable();
            dt = temp.GetData();

            foreach (DataRow row in dt.Rows)
            {
                cbMaCN.Items.Add(row[0].ToString());
            }
            cbMaCN.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaCN.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public void load_dgvHienThi(object sender, EventArgs e)
        {
            dgvHienThi.DataSource = bus.GetData();
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

        public void SettingTxbMaLHP(object sender, EventArgs e)
        {
            txbMaLHP.ReadOnly = true;
            txbMaLHP.Text = bus.GetDataMaLHP().Rows[0].ItemArray[0].ToString(); 
        }

        private void fAdmin_LopHocPhan_Load(object sender, EventArgs e)
        {
            addDataComboBox(sender, e);
            load_dgvHienThi(sender, e);
            SettingTxbMaLHP(sender, e);
        }

        private void btThem_Click(object sender, EventArgs e)
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
            if (bus.GetData(int.Parse(txbMaLHP.Text)).Rows.Count == 0)
            {
                bus.Insert(obj);
                MessageBox.Show("Thêm thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã lớp học phần đã tồn tại, vui lòng nhập mã khoa khác", "Thông báo");
                txbMaLHP.Focus();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
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
            if (bus.GetData(int.Parse(txbMaLHP.Text)).Rows.Count != 0)
            {
                bus.Update(obj);
                MessageBox.Show("Sửa thành công", "Thông báo");
                load_dgvHienThi(sender, e);
            }
            else
            {
                MessageBox.Show("Mã lớp học phần không tồn tại, vui lòng nhập lại", "Thông báo");
                txbMaLHP.Focus();
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (bus.GetData(int.Parse(txbMaLHP.Text)).Rows.Count != 0)
            {
                DialogResult rs = MessageBox.Show("Bạn có chắc chắn xóa lớp học phần này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rs == DialogResult.Yes)
                {
                    bus.Delete(int.Parse(txbMaLHP.Text));
                    MessageBox.Show("Xóa thành công", "Thông báo");
                    btReset_Click(sender, e);
                    load_dgvHienThi(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Mã khoa không tồn tại, vui lòng nhập mã lớp học phần khác", "Thông báo");
                txbMaLHP.Focus();
            }
        }

        private void btReset_Click(object sender, EventArgs e)
        {
            SettingTxbMaLHP(sender, e);
            txbNienKhoa.Text = "";
            cbHocKy.Text = "";
            cbMaMH.Text = "";
            cbMaGV.Text = "";
            cbMaCN.Text = "";
            rdbTrue.Checked = false;
            rdbFalse.Checked = false;
        }

        private void cbMaCN_SelectedValueChanged(object sender, EventArgs e)
        {
            CHUONGTRINHHOCBUS bus_CTH = new CHUONGTRINHHOCBUS();
            //Thêm lại môn học thuộc về chuyên ngành X
            cbMaMH.Items.Clear();
            DataTable dt = new DataTable();
            dt = bus_CTH.GetDataByChuyenNganh(cbMaCN.Text);

            foreach (DataRow dr in dt.Rows)
            {
                cbMaMH.Items.Add(dr["MAMH"].ToString());
            }
            GIANGVIENBUS bus_GV = new GIANGVIENBUS();
            //Thêm lại các giảng viên thuộc về chuyên ngành X
            cbMaGV.Items.Clear();
            dt.Clear();
            dt = bus_GV.GetDataByChuyenNganh(cbMaCN.Text);
            foreach (DataRow dr in dt.Rows)
            {
                cbMaGV.Items.Add(dr["MAGV"].ToString());
            }

            dgvHienThi.DataSource = bus.GetDataByChuyenNganh(cbMaCN.Text);
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

                obj.MALHP = int.Parse(worksheet.Cells[row, 1].Value.ToString());
                obj.NIENKHOA = worksheet.Cells[row, 2].Value.ToString();
                obj.HOCKY = int.Parse(worksheet.Cells[row, 3].Value.ToString());
                obj.MAMH = worksheet.Cells[row, 4].Value.ToString();
                obj.MAGV = worksheet.Cells[row, 5].Value.ToString();
                obj.MACN = worksheet.Cells[row, 6].Value.ToString();
                obj.HUYLOP = bool.Parse(worksheet.Cells[row, 7].Value.ToString());
                if (bus.GetData(obj.MALHP).Rows.Count == 0)
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
