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
            //ComboBox Ma khoa
            KHOABUS tempKhoa = new KHOABUS();
            dt = tempKhoa.GetData();
            foreach (DataRow row in dt.Rows)
            {
                cbMaK.Items.Add(row[0].ToString());
            }
            cbMaK.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbMaK.AutoCompleteSource = AutoCompleteSource.ListItems;
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
            dgvHienThi.Columns[5].HeaderText = "Mã khoa";
            dgvHienThi.Columns[6].HeaderText = "Hủy lớp";
        }

        private void dgvHienThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbMaLHP.Text = dgvHienThi.SelectedRows[0].Cells[0].Value.ToString();
            txbNienKhoa.Text = dgvHienThi.SelectedRows[0].Cells[1].Value.ToString();
            cbHocKy.Text = dgvHienThi.SelectedRows[0].Cells[2].Value.ToString();
            cbMaMH.Text = dgvHienThi.SelectedRows[0].Cells[3].Value.ToString();
            cbMaGV.Text = dgvHienThi.SelectedRows[0].Cells[4].Value.ToString();
            cbMaK.Text = dgvHienThi.SelectedRows[0].Cells[5].Value.ToString();
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
            obj.MAKHOA = cbMaK.Text;
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
            obj.MAKHOA = cbMaK.Text;
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
            cbMaK.Text = "";
            rdbTrue.Checked = false;
            rdbFalse.Checked = false;
        }
    }
}
