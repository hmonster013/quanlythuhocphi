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
    public class CTCHUYENNGANHDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_CTCHUYENNGANH_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACN", ID)
            };
            return _dbConnect.GetData("sp_CTCHUYENNGANH_select_mactcn", param);
        }

        public int Insert(CTCHUYENNGANH obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACN", obj.MACN),
                new SqlParameter("MAMH", obj.MAMH)
            };
            return _dbConnect.ExecuteSQL("sp_CTCHUYENNGANH_insert", param);
        }

        public int Update(CTCHUYENNGANH obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACN", obj.MACN),
                new SqlParameter("MAMH", obj.MAMH),
                new SqlParameter("MACTCN", obj.MACTCN)
            };
            return _dbConnect.ExecuteSQL("sp_CTCHUYENNGANH_update", param);
        }

        public int Delete(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACN", ID)
            };
            return _dbConnect.ExecuteSQL("sp_CTCHUYENNGANH_delete", param);
        }

        public int DeleteByMaMH(string MAMH)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAMH", MAMH)
            };
            return _dbConnect.ExecuteSQL("sp_CTCHUYENNGANH_delete_by_mamh", param);
        }
    }
}
