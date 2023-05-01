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

        public int Insert(LOP obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MALOP", obj.MALOP),
                new SqlParameter("CHUYENNGANH", obj.CHUYENNGANH),
                new SqlParameter("MAKHOA", obj.MAKHOA)
            };
            return _dbConnect.ExecuteSQL("sp_LOP_insert", param);
        }

        public int Update(LOP obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MALOP", obj.MALOP),
                new SqlParameter("CHUYENNGANH", obj.CHUYENNGANH),
                new SqlParameter("MAKHOA", obj.MAKHOA)
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
