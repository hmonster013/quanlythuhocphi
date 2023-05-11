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
    public class PHIEUTHUDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_PHIEUTHU_select_all", null);
        }

        public DataTable GetDataByID(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MAPT", ID)
            };
            return _dbConnect.GetData("sp_PHIEUTHU_select_mapt", param);
        }

        public DataTable GetDataByMaSVandHK(string MASV, int HOCKY) 
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", MASV),
                new SqlParameter("HOCKY", HOCKY)
            };
            return _dbConnect.GetData("sp_PHIEUTHU_select_masv_hocky", param);
        }

        public DataTable GetDataSTTPT() 
        {
            return _dbConnect.GetData("SELECT IDENT_CURRENT('PHIEUTHU') + 1");
        }

        public int Insert(PHIEUTHU obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MASV", obj.MASV),
                new SqlParameter("@NIENKHOA", obj.NIENKHOA),
                new SqlParameter("@HOCKY", obj.HOCKY)
            };
            return _dbConnect.ExecuteSQL("sp_PHIEUTHU_insert", param);
        }

        public int Update(PHIEUTHU obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MAPT", obj.MAPT),
                new SqlParameter("@MASV", obj.MASV),
                new SqlParameter("@NIENKHOA", obj.NIENKHOA),
                new SqlParameter("@HOCKY", obj.HOCKY)
            };
            return _dbConnect.ExecuteSQL("sp_PHIEUTHU_update", param);
        }

        public int Delete(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MAPT", ID)
            };
            return _dbConnect.ExecuteSQL("sp_PHIEUTHU_delete", param);
        }
    }
}
