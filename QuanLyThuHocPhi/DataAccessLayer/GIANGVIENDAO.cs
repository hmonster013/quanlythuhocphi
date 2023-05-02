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
    public class GIANGVIENDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_GIANGVIEN_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAGV", ID)
            };
            return _dbConnect.GetData("sp_GIANGVIEN_select_magv", param);
        }

        public int Insert(GIANGVIEN obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAGV", obj.MAGV),
                new SqlParameter("HO", obj.HO),
                new SqlParameter("TEN", obj.TEN),
                new SqlParameter("HOCHAM", obj.HOCHAM),
                new SqlParameter("MAKHOA", obj.MAKHOA)
            };
            return _dbConnect.ExecuteSQL("sp_GIANGVIEN_insert", param);
        }

        public int Update(GIANGVIEN obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAGV", obj.MAGV),
                new SqlParameter("HO", obj.HO),
                new SqlParameter("TEN", obj.TEN),
                new SqlParameter("HOCHAM", obj.HOCHAM),
                new SqlParameter("MAKHOA", obj.MAKHOA)
            };
            return _dbConnect.ExecuteSQL("sp_GIANGVIEN_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAGV", ID)
            };
            return _dbConnect.ExecuteSQL("sp_GIANGVIEN_delete", param);
        }

    }
}
