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
    public class TINCHIDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_TINCHI_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MATC", ID)
            };
            return _dbConnect.GetData("sp_TINCHI_select_matc", param);
        }

        public int Insert(TINCHI obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MATC", obj.MATC),
                new SqlParameter("MAKHOA", obj.MAKHOA),
                new SqlParameter("DONGIA", obj.DONGIA)
            };
            return _dbConnect.ExecuteSQL("sp_TINCHI_insert", param);
        }

        public int Update(TINCHI obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MATC", obj.MATC),
                new SqlParameter("MAKHOA", obj.MAKHOA),
                new SqlParameter("DONGIA", obj.DONGIA)
            };
            return _dbConnect.ExecuteSQL("sp_TINCHI_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MATC", ID)
            };
            return _dbConnect.ExecuteSQL("sp_TINCHI_delete", param);
        }

    }
}
