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
    public class XULYDANGKYDAO
    {
        private dbConnect _dbConnect = new dbConnect();
        public DataTable GetData(DANGKY obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MADK", obj.MADK),
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("HOCKY", obj.HOCKY)
            };
            return _dbConnect.GetData("sp_XULYDANGKY_select_masv", param);
        }

        public DataTable GetData(DANGKY obj, string TENMH)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MADK", obj.MADK),
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("HOCKY", obj.HOCKY),
                new SqlParameter("TENMH", TENMH)
            };
            return _dbConnect.GetData("sp_XULYDANGKY_select_tenmh", param);
        }

        public DataTable GetDataLHPChuaDK(DANGKY obj)
        {
            SqlParameter[] param =
{
                new SqlParameter("MADK", obj.MADK),
                new SqlParameter("MASV", obj.MASV),
                new SqlParameter("HOCKY", obj.HOCKY)
            };
            return _dbConnect.GetData("sp_XULYDANGKY_select_chuadk", param);
        }
    }
}
