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
    public class MONHOCDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_MONHOC_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAMH", ID)
            };
            return _dbConnect.GetData("sp_MONHOC_select_mamh", param);
        }

        public int Insert(MONHOC obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAMH", obj.MAMH),
                new SqlParameter("TENMH", obj.TENMH),
                new SqlParameter("HOCKY", obj.HOCKY),
                new SqlParameter("SOTINCHI", obj.SOTINCHI)
            };
            return _dbConnect.ExecuteSQL("sp_MONHOC_insert", param);
        }

        public int Update(MONHOC obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAMH", obj.MAMH),
                new SqlParameter("TENMH", obj.TENMH),
                new SqlParameter("HOCKY", obj.HOCKY),
                new SqlParameter("SOTINCHI", obj.SOTINCHI)
            };
            return _dbConnect.ExecuteSQL("sp_MONHOC_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAMH", ID)
            };
            return _dbConnect.ExecuteSQL("sp_MONHOC_delete", param);
        }

    }
}
