using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CHUONGTRINHHOCDAO
    {
        private dbConnect _dbConnect = new dbConnect();
        public DataTable GetData(string MASV)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", MASV)
            };
            return _dbConnect.GetData("sp_CHUONGTRINHHOC_select_all", param);
        }

        public DataTable GetData(string MASV, int HOCKY) 
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", MASV),
                new SqlParameter("HOCKY", HOCKY)
            };
            return _dbConnect.GetData("sp_CHUONGTRINHHOC_find_hocky", param);
        }

        public DataTable GetDataByTenMH(string MASV, string TENMH)
        {
            SqlParameter[] param =
{
                new SqlParameter("MASV", MASV),
                new SqlParameter("TENMH", TENMH)
            };
            return _dbConnect.GetData("sp_CHUONGTRINHHOC_find_tenmh", param);
        }

        public DataTable GetDataByTenMH(string MASV, string TENMH, int HOCKY)
        {
            SqlParameter[] param =
{
                new SqlParameter("MASV", MASV),
                new SqlParameter("TENMH", TENMH),
                new SqlParameter("HOCKY", HOCKY)
            };
            return _dbConnect.GetData("sp_CHUONGTRINHHOC_find_tenmh_by_hocky", param);
        }
    }
}
