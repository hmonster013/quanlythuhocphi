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
    public class LOPDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_LOP_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MALOP", ID)
            };
            return _dbConnect.GetData("sp_LOP_select_malop", param);
        }

        public DataTable GetDataByMAKHOA(string MAKHOA)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAKHOA", MAKHOA)
            };
            return _dbConnect.GetData("sp_LOP_select_by_makhoa", param);
        }

        public DataTable GetDataByMACN(string MACN) 
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACN", MACN)
            };
            return _dbConnect.GetData("sp_LOP_select_by_macn", param);
        }

        public int Insert(LOP obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MALOP", obj.MALOP),
                new SqlParameter("MACN", obj.MACN)
            };
            return _dbConnect.ExecuteSQL("sp_LOP_insert", param);
        }

        public int Update(LOP obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MALOP", obj.MALOP),
                new SqlParameter("MACN", obj.MACN)
            };
            return _dbConnect.ExecuteSQL("sp_LOP_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MALOP", ID)
            };
            return _dbConnect.ExecuteSQL("sp_LOP_delete", param);
        }

    }
}
