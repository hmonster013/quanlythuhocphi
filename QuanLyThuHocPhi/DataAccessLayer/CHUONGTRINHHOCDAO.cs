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
        public DataTable getData(string MASV)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MASV", MASV)
            };
            return _dbConnect.GetData("sp_CHUONGTRINHHOC_select_all", param);
        }
    }
}
