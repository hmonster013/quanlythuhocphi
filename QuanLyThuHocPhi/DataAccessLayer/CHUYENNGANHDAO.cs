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
    public class CHUYENNGANHDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_CHUYENNGANH_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACN", ID)
            };
            return _dbConnect.GetData("sp_CHUYENNGANH_select_macn", param);
        }

        public DataTable GetDataByMAKHOA(string MAKHOA)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAKHOA", MAKHOA)
            };
            return _dbConnect.GetData("sp_CHUYENNGANH_select_by_makhoa", param);
        }

        public int Insert(CHUYENNGANH obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACN", obj.MACN),
                new SqlParameter("TENCN", obj.TENCN),
                new SqlParameter("MAKHOA", obj.MAKHOA)
            };
            return _dbConnect.ExecuteSQL("sp_CHUYENNGANH_insert", param);
        }

        public int Update(CHUYENNGANH obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACN", obj.MACN),
                new SqlParameter("TENCN", obj.TENCN),
                new SqlParameter("MAKHOA", obj.MAKHOA)
            };
            return _dbConnect.ExecuteSQL("sp_CHUYENNGANH_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACN", ID)
            };
            return _dbConnect.ExecuteSQL("sp_CHUYENNGANH_delete", param);
        }
    }
}
