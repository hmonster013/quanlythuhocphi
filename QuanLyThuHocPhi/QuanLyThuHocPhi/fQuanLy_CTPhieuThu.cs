using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValueObject.CTPhieuThu;
using ValueObject.PhieuThu;
using BusinessLogicLayer;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;
using ValueObject.SinhVien;
using ValueObject.XuLyHocPhi;

namespace QuanLyThuHocPhi
{
    public partial class fQuanLy_CTPhieuThu : Form
    {
        private PHIEUTHU obj_PT = new PHIEUTHU();
        private CTPHIEUTHU obj_CTPT = new CTPHIEUTHU();
        private CTPHIEUTHUBUS bus_CTPT = new CTPHIEUTHUBUS();
        private XULYHOCPHIBUS bus_XLHP = new XULYHOCPHIBUS();
        private SINHVIENBUS bus_SV = new SINHVIENBUS();

        public fQuanLy_CTPhieuThu()
        {
            InitializeComponent();
        }

        public fQuanLy_CTPhieuThu(PHIEUTHU obj_PT)
        {
            this.obj_PT = obj_PT;
            InitializeComponent();
        }
        
        public async void load_dgvHienThi()
        {
            dgvHienThi.DataSource = await bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
            dgvHienThi.ReadOnly = true;
            dgvHienThi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHienThi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHienThi.Columns[0].HeaderText = "Mã chi tiết phiếu thu";
            dgvHienThi.Columns[1].HeaderText = "Mã phiếu thu";
            dgvHienThi.Columns[2].HeaderText = "Ngày đóng";
            dgvHienThi.Columns[3].HeaderText = "Số tiền đóng";
        }

        public void settingTextBox() 
        {
            txbMaPT.Text = obj_PT.MAPT.ToString();
            txbMaPT.ReadOnly = true;
            txbSTDaDong.ReadOnly = true;
            txbSTChuaDong.ReadOnly = true;
            txbSTPhaiDong.ReadOnly = true;
        }

        public void settingLabel()
        {
            lbHienThi.Text += obj_PT.HOCKY.ToString();
        }

        private void fQuanLy_CTPhieuThu_Load(object sender, EventArgs e)
        {
            settingTextBox();
            settingLabel();
            load_dgvHienThi();
        }
        
        private async void btKiemTra_Click(object sender, EventArgs e)
        {
            if (await bus_XLHP.GetDataBySVandHK(obj_PT.MASV, obj_PT.HOCKY) != null)
            {
                HocPhiDto temp = await bus_XLHP.GetDataBySVandHK(obj_PT.MASV, obj_PT.HOCKY);
                txbSTPhaiDong.Text = temp.TONGHOCPHI.ToString();
                txbSTDaDong.Text = temp.TONGDADONG.ToString();
                txbSTChuaDong.Text = temp.TONGCHUADONG.ToString();
                dgvHienThi.DataSource = await bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu về học phí trong học kỳ này", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public async void xuatHoaDon()
        {
            Excel.Application application = new Excel.Application();
            Excel.Workbook wb = application.Workbooks.Add();
            Excel.Worksheet ws = wb.Worksheets[1];

            ws.Columns["A"].ColumnWidth = 12.14;
            ws.Columns["B"].ColumnWidth = 18;
            ws.Columns["C"].ColumnWidth = 14.57;
            ws.Columns["D"].ColumnWidth = 17.14;
            ws.Columns["F"].ColumnWidth = 14;
            ws.Columns["G"].ColumnWidth = 17;

            Excel.Range header1 = ws.Range["A1", "D2"];
            header1.MergeCells = true;
            header1.Value = "TRƯỜNG ĐẠI HỌC CÔNG NGHỆ GIAO THÔNG VẬN TẢI";
            header1.Font.Size = 14;
            header1.Font.Bold = true;
            header1.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range header2 = ws.Range["A3", "D3"];
            header2.MergeCells = true;
            header2.Value = "(54 P. Triều Khúc, Thanh Xuân Nam, Thanh Xuân, Hà Nội, Vietnam)";
            header2.Font.Size = 11;
            header2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range header3 = ws.Range["F2"];
            header3.Value = "Mã phiếu thu:";
            header3.Font.Size = 11;

            header3.Cells[2, 1].Value = "Thời gian:";
            ws.Range["F14", "F15"].HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            header3.Cells[13, 1].Value = "Người thu tiền";
            header3.Cells[14, 1].Value = "(Ký, họ tên)";

            Excel.Range tt2 = ws.Range["G2"];
            tt2.Cells[1, 1].Value = obj_CTPT.MACTPT;
            tt2.Cells[2, 1].Value = obj_CTPT.NGAYDONG.Date;

            Excel.Range header5 = ws.Range["C5", "E5"];
            header5.MergeCells = true;
            header5.Value = "PHIẾU THU HỌC PHÍ";
            header5.Font.Size = 16;
            header5.Font.Bold = true;
            header5.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            Excel.Range header6 = ws.Range["B6"];
            header6.Font.Size = 11;

            header6.Cells[2, 1].Value = "Mã sinh viên:";
            header6.Cells[3, 1].Value = "Tên sinh viên:";
            header6.Cells[4, 1].Value = "Lớp:";
            header6.Cells[5, 1].Value = "Niên khóa:";
            header6.Cells[6, 1].Value = "Học kỳ:";
            header6.Cells[7, 1].Value = "Số tiền đóng: ";

            Excel.Range tt1 = ws.Range["C6"];
            tt1.Font.Size = 11;

            SINHVIEN temp = await bus_SV.GetData(obj_PT.MASV);
            tt1.Cells[2, 1].Value = obj_PT.MASV;
            tt1.Cells[3, 1].Value = temp.HO + " " + temp.TEN;
            tt1.Cells[4, 1].Value = temp.MALOP;
            tt1.Cells[5, 1].Value = obj_PT.NIENKHOA;
            tt1.Cells[6, 1].Value = "'" + obj_PT.HOCKY.ToString();
            tt1.Cells[7, 1].Value = obj_CTPT.SOTIENDONG.ToString() + " VND";

            Excel.Range header7 = ws.Range["B13", "B16"];
            header7.Font.Size = 11;
            header7.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            header7.Cells[2, 1].Value = "Người đóng";
            header7.Cells[3, 1].Value = "(Ký, họ tên)";

            Excel.Range body = ws.Range["A1", "G17"];
            body.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx";
            sfd.Title = "Save Excel File";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string filePath = sfd.FileName;
                wb.SaveAs(filePath);
            }
            
            wb.Close();
            application.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(ws);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(wb);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
        }

        private async void btThem_Click(object sender, EventArgs e)
        {
            if (txbSoTienDong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                obj_CTPT.MACTPT = int.Parse(txbMaCTPT.Text);
                obj_CTPT.MAPT = int.Parse(txbMaPT.Text);
                obj_CTPT.NGAYDONG = dtpNgayDong.Value;
                obj_CTPT.SOTIENDONG = float.Parse(txbSoTienDong.Text);
                if (float.Parse(txbSoTienDong.Text) < 0 || float.Parse(txbSoTienDong.Text) > float.Parse(txbSTChuaDong.Text))
                {
                    txbSoTienDong.Text = "";
                    txbSoTienDong.Focus();
                    MessageBox.Show("Số tiền đóng không hợp lệ, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (await bus_CTPT.GetData(int.Parse(txbMaCTPT.Text)) == null)
                    {
                        await bus_CTPT.Insert(obj_CTPT);
                        MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvHienThi.DataSource = await bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
                        btKiemTra_Click(sender, e);
                        DialogResult result = MessageBox.Show("Bạn có muốn xuất hóa đơn không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            xuatHoaDon();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thông tin không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private async void btSửa_Click(object sender, EventArgs e)
        {
            if (txbMaCTPT.Text == "" || txbSoTienDong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                obj_CTPT.MACTPT = int.Parse(txbMaCTPT.Text);
                obj_CTPT.MAPT = int.Parse(txbMaPT.Text);
                obj_CTPT.NGAYDONG = dtpNgayDong.Value;
                obj_CTPT.SOTIENDONG = float.Parse(txbSoTienDong.Text);
                if (float.Parse(txbSoTienDong.Text) < 0 || float.Parse(txbSoTienDong.Text) > float.Parse(txbSTChuaDong.Text))
                {
                    txbSoTienDong.Text = "";
                    txbSoTienDong.Focus();
                    MessageBox.Show("Số tiền đóng không hợp lệ, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (await bus_CTPT.GetData(int.Parse(txbMaCTPT.Text)) != null)
                    {
                        await bus_CTPT.Update(obj_CTPT);
                        MessageBox.Show("Sửa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        dgvHienThi.DataSource = await bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
                        btKiemTra_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Mã phiếu thu không tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txbMaPT.Focus();
                    }
                }
            }
        }

        private async void btXóa_Click(object sender, EventArgs e)
        {
            if (txbMaCTPT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập dữ liệu hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (await bus_CTPT.GetData(int.Parse(txbMaCTPT.Text)) != null)
                {
                    DialogResult rs = MessageBox.Show("Bạn chắc chắn muốn xóa phiếu thu này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (rs == DialogResult.Yes)
                    {
                        await bus_CTPT.Delete(int.Parse(txbMaCTPT.Text));
                        MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btReset_Click(sender, e);
                        dgvHienThi.DataSource = await bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
                        btKiemTra_Click(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Mã phiếu thu không tồn tại, vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txbMaPT.Focus();
                }
            }
        }

        private async void btReset_Click(object sender, EventArgs e)
        {
            txbMaCTPT.Text = "";
            txbMaPT.Text = "";
            dtpNgayDong.Value = DateTime.Now;
            txbSoTienDong.Text = "";
            txbSTPhaiDong.Text = "";
            txbSTDaDong.Text = "";
            txbSTChuaDong.Text = "";
            settingTextBox();
            dgvHienThi.DataSource = await bus_CTPT.GetDataByMaPT(obj_PT.MAPT);
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaCTPT.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbMaPT.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            dtpNgayDong.Value = DateTime.Parse(dgvHienThi.SelectedRows[0].Cells[2].Value.ToString());
            txbSoTienDong.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
