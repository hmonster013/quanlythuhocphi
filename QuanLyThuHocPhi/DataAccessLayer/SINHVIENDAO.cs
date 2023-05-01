using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace DataAccessLayer
{
    public class SINHVIENDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_SINHVIEN_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", ID)
            };
            return _dbConnect.GetData("sp_SINHVIEN_select_masv", param);
        }

        public int Insert(SINHVIEN obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("HO", obj.HO),
                new SqlParameter("TEN", obj.TEN),
                new SqlParameter("MALOP", obj.MALOP),
                new SqlParameter("PHAI", obj.PHAI),
                new SqlParameter("NGAYSINH", obj.NGAYSINH),
                new SqlParameter("DIACHI", obj.DIACHI),
                new SqlParameter("DANGNGHIHOC", obj.DANGNGHIHOC),
                new SqlParameter("PASSWORD", obj.PASSWORD),
                new SqlParameter("MAKHOA", obj.MAKHOA)
            };
            return _dbConnect.ExecuteSQL("sp_SINHVIEN_insert", param);
        }

        public int Update(SINHVIEN obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("HO", obj.HO),
                new SqlParameter("TEN", obj.TEN),
                new SqlParameter("MALOP", obj.MALOP),
                new SqlParameter("PHAI", obj.PHAI),
                new SqlParameter("NGAYSINH", obj.NGAYSINH),
                new SqlParameter("DIACHI", obj.DIACHI),
                new SqlParameter("DANGNGHIHOC", obj.DANGNGHIHOC),
                new SqlParameter("PASSWORD", obj.PASSWORD),
                new SqlParameter("MAKHOA", obj.MAKHOA)
            };
            return _dbConnect.ExecuteSQL("sp_SINHVIEN_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", ID)
            };
            return _dbConnect.ExecuteSQL("sp_SINHVIEN_delete", param);
        }

    }
}
