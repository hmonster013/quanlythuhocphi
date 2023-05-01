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
    public class HOCPHIDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_HOCPHI_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAHP", ID)
            };
            return _dbConnect.GetData("sp_HOCPHI_select_mahp", param);
        }

        public int Insert(HOCPHI_cls obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAHP", obj.MAHP),
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("NIENKHOA", obj.NIENKHOA),
                new SqlParameter("HOCKY", obj.HOCKY),
                new SqlParameter("HOCPHI", obj.HOCPHI)
            };
            return _dbConnect.ExecuteSQL("sp_HOCPHI_insert", param);
        }

        public int Update(HOCPHI_cls obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAHP", obj.MAHP),
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("NIENKHOA", obj.NIENKHOA),
                new SqlParameter("HOCKY", obj.HOCKY),
                new SqlParameter("HOCPHI", obj.HOCPHI)
            };
            return _dbConnect.ExecuteSQL("sp_HOCPHI_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAHP", ID)
            };
            return _dbConnect.ExecuteSQL("sp_HOCPHI_delete", param);
        }

    }
}
