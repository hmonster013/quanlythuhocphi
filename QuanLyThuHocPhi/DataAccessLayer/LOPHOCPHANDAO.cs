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
    public class LOPHOCPHANDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_LOPHOCPHAN_select_all", null);
        }

        public DataTable GetDataByID(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MALHP", ID)
            };
            return _dbConnect.GetData("sp_LOPHOCPHAN_select_malhp", param);
        }

        public DataTable GetDataByChuyenNganh(string MACN)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACN", MACN)
            };
            return _dbConnect.GetData("sp_LOPHOCPHAN_select_by_chuyennganh", param);
        }

        public DataTable GetDataMaLHP()
        {
            return _dbConnect.GetData("SELECT IDENT_CURRENT('LOPHOCPHAN') + 1");
        }

        public int Insert(LOPHOCPHAN obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("NIENKHOA", obj.NIENKHOA),
                new SqlParameter("HOCKY", obj.HOCKY),
                new SqlParameter("MAMH", obj.MAMH),
                new SqlParameter("MAGV", obj.MAGV),
                new SqlParameter("MACN", obj.MACN),
                new SqlParameter("HUYLOP", obj.HUYLOP)
            };
            return _dbConnect.ExecuteSQL("sp_LOPHOCPHAN_insert", param);
        }

        public int Update(LOPHOCPHAN obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MALHP", obj.MALHP),
                new SqlParameter("NIENKHOA", obj.NIENKHOA),
                new SqlParameter("HOCKY", obj.HOCKY),
                new SqlParameter("MAMH", obj.MAMH),
                new SqlParameter("MAGV", obj.MAGV),
                new SqlParameter("MACN", obj.MACN),
                new SqlParameter("HUYLOP", obj.HUYLOP)
            };
            return _dbConnect.ExecuteSQL("sp_LOPHOCPHAN_update", param);
        }

        public int Delete(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MALHP", ID)
            };
            return _dbConnect.ExecuteSQL("sp_LOPHOCPHAN_delete", param);
        }

    }
}
