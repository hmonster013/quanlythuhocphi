using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace DataAccessLayer
{
    public class DANGKYDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_DANGKY_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MADK", ID)
            };
            return _dbConnect.GetData("sp_DANGKY_select_madk", param);
        }

        public int Insert(DANGKY obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MADK", obj.MADK),
                new SqlParameter("MALTC", obj.MALTC),
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("DIEM_CC", obj.DIEM_CC),
                new SqlParameter("DIEM_GK", obj.DIEM_GK),
                new SqlParameter("DIEM_CK", obj.DIEM_CK),
                new SqlParameter("HUYDANGKY", obj.HUYDANGKY)
            };
            return _dbConnect.ExecuteSQL("sp_DANGKY_insert", param);
        }

        public int Update(DANGKY obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MADK", obj.MADK),
                new SqlParameter("MALTC", obj.MALTC),
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("DIEM_CC", obj.DIEM_CC),
                new SqlParameter("DIEM_GK", obj.DIEM_GK),
                new SqlParameter("DIEM_CK", obj.DIEM_CK),
                new SqlParameter("HUYDANGKY", obj.HUYDANGKY)
            };
            return _dbConnect.ExecuteSQL("sp_DANGKY_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MADK", ID)
            };
            return _dbConnect.ExecuteSQL("sp_DANGKY_delete", param);
        }
    }
}
