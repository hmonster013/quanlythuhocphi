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
    public class DONGHOCPHIDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_DONGHOCPHI_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MADHP", ID)
            };
            return _dbConnect.GetData("sp_DONGHOCPHI_select_madhp", param);
        }

        public int Insert(DONGHOCPHI obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MADHP", obj.MADHP),
                new SqlParameter("@MASV", obj.MASV),
                new SqlParameter("@NIENKHOA", obj.NIENKHOA),
                new SqlParameter("@HOCKY", obj.HOCKY),
                new SqlParameter("@NGAYDONG", obj.NGAYDONG),
                new SqlParameter("@SOTIENDONG", obj.SOTIENDONG)
            };
            return _dbConnect.ExecuteSQL("sp_DONGHOCPHI_insert", param);
        }

        public int Update(DONGHOCPHI obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MADHP", obj.MADHP),
                new SqlParameter("@MASV", obj.MASV),
                new SqlParameter("@NIENKHOA", obj.NIENKHOA),
                new SqlParameter("@HOCKY", obj.HOCKY),
                new SqlParameter("@NGAYDONG", obj.NGAYDONG),
                new SqlParameter("@SOTIENDONG", obj.SOTIENDONG)
            };
            return _dbConnect.ExecuteSQL("sp_DONGHOCPHI_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MADHP", ID)
            };
            return _dbConnect.ExecuteSQL("sp_DONGHOCPHI_delete", param);
        }
    }
}
