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
    public class CTPHIEUTHUDAO
    {
        private dbConnect _dbConnect = new dbConnect();
        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_CTPHIEUTHU_select_all");
        }

        public DataTable GetDataByMACTPT(int MACTPT)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACTPT", MACTPT)
            };
            return _dbConnect.GetData("sp_CTPHIEUTHU_select_mactpt", param);
        }

        public DataTable GetDataByMaPT(int MAPT)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAPT", MAPT)
            };
            return _dbConnect.GetData("sp_CTPHIEUTHU_select_mapt", param);
        }

        public DataTable GetDataSTTCTPT()
        {
            return _dbConnect.GetData("SELECT IDENT_CURRENT('CTPHIEUTHU') + 1");
        }

        public int Insert(CTPHIEUTHU obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MAPT", obj.MAPT),
                new SqlParameter("NGAYDONG", obj.NGAYDONG),
                new SqlParameter("SOTIENDONG", obj.SOTIENDONG)
            };
            return _dbConnect.ExecuteSQL("sp_CTPHIEUTHU_insert", param);
        }

        public int Update(CTPHIEUTHU obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACTPT", obj.MACTPT),
                new SqlParameter("MAPT", obj.MAPT),
                new SqlParameter("NGAYDONG", obj.NGAYDONG),
                new SqlParameter("SOTIENDONG", obj.SOTIENDONG)
            };
            return _dbConnect.ExecuteSQL("sp_CTPHIEUTHU_update", param);
        }

        public int Delete(int MACTPT)
        {
            SqlParameter[] param =
            {
                new SqlParameter("MACTPT", MACTPT)
            };
            return _dbConnect.ExecuteSQL("sp_CTPHIEUTHU_delete", param);
        }
    }
}
