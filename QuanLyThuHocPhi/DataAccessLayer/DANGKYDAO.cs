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

        public DataTable GetDataByID(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MADK", ID)
            };
            return _dbConnect.GetData("sp_DANGKY_select_madk", param);
        }

        public DataTable GetDataByMASV(string MASV)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", MASV)
            };
            return _dbConnect.GetData("sp_DANGKY_select_masv", param);
        }

        public DataTable GetDataByMASVandHOCKY(DANGKY obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("HOCKY", obj.HOCKY)
            };
            return _dbConnect.GetData("sp_DANGKY_select_masv_hocky", param);
        }

        public DataTable GetDataSTTMaDK()
        {
            return _dbConnect.GetData("SELECT IDENT_CURRENT('DANGKY') + 1");
        }

        public int Insert(DANGKY obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("HOCKY", obj.HOCKY)
            };
            return _dbConnect.ExecuteSQL("sp_DANGKY_insert", param);
        }

        public int Update(DANGKY obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MADK", obj.MADK),
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("HOCKY", obj.HOCKY)
            };
            return _dbConnect.ExecuteSQL("sp_DANGKY_update", param);
        }

        public int Delete(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MADK", ID)
            };
            return _dbConnect.ExecuteSQL("sp_DANGKY_delete", param);
        }
    }
}

