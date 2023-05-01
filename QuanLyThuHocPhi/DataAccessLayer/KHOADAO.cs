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
    public class KHOADAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_KHOA_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAKHOA", ID)
            };
            return _dbConnect.GetData("sp_KHOA_select_makhoa", param);
        }

        public int Insert(KHOA obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAKHOA", obj.MAKHOA),
                new SqlParameter("TENKHOA", obj.TENKHOA)
            };
            return _dbConnect.ExecuteSQL("sp_KHOA_insert", param);
        }

        public int Update(KHOA obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAKHOA", obj.MAKHOA),
                new SqlParameter("TENKHOA", obj.TENKHOA)
            };
            return _dbConnect.ExecuteSQL("sp_KHOA_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAKHOA", ID)
            };
            return _dbConnect.ExecuteSQL("sp_KHOA_delete", param);
        }

    }
}
