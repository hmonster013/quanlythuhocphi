using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class XULYHOCPHIDAO
    {
        private dbConnect _dbConnect = new dbConnect();
        public DataTable GetDataHocPhi(string MASV)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", MASV)
            };
            return _dbConnect.GetData("sp_XULYHOCPHI_all", param);
        }

        public DataTable GetDataTongHocPhi(string MASV)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", MASV)
            };
            return _dbConnect.GetData("sp_XULYHOCPHI_sum_all", param);
        }

        public DataTable GetDataByHOCKY(string MASV, int HOCKY)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", MASV),
                new SqlParameter("HOCKY", HOCKY)
            };
            return _dbConnect.GetData("sp_XULYHOCPHI_select_byhocky", param);
        }
    }
}
