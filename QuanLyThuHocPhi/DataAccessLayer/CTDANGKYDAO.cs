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
    public class CTDANGKYDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_CTDANGKY_select_all", null);
        }

        public DataTable GetDataByID(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACTDK", ID)
            };
            return _dbConnect.GetData("sp_CTDANGKY_select_mactdk", param);
        }

        public int Insert(CTDANGKY obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MALHP", obj.MALHP),
                new SqlParameter("MADK", obj.MADK)
            };
            return _dbConnect.ExecuteSQL("sp_CTDANGKY_insert", param);
        }

        public int Update(CTDANGKY obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACTDK", obj.MACTDK),
                new SqlParameter("MALHP", obj.MALHP),
                new SqlParameter("MADK", obj.MADK)
            };
            return _dbConnect.ExecuteSQL("sp_CTDANGKY_update", param);
        }

        public int Delete(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACTDK", ID)
            };
            return _dbConnect.ExecuteSQL("sp_CTDANGKY_delete", param);
        }
    }
}
