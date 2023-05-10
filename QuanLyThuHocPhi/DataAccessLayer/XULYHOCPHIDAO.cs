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
        public DataTable GetDataHocPhi(string MASV, int HOCKY)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", MASV),
                new SqlParameter("HOCKY", HOCKY)
            };
            return _dbConnect.GetData("sp_XULYHOCPHI_byhocky", param);
        }
    }
}
