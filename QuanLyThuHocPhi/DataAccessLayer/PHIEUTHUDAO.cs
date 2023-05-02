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
            return _dbConnect.GetData("sp_DONGHOCPHI_select_all", null);
        }

        public DataTable GetDataByID(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MADHP", ID)
            };
            return _dbConnect.GetData("sp_DONGHOCPHI_select_madhp", param);
        }

        public int Insert(PHIEUTHU obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MAPT", obj.MAPT),
                new SqlParameter("@MASV", obj.MASV),
                new SqlParameter("@NIENKHOA", obj.NIENKHOA),
                new SqlParameter("@HOCKY", obj.HOCKY),
                new SqlParameter("@NGAYDONG", obj.NGAYDONG),
                new SqlParameter("@SOTIENDONG", obj.SOTIENDONG)
            };
            return _dbConnect.ExecuteSQL("sp_DONGHOCPHI_insert", param);
        }

        public int Update(PHIEUTHU obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MAPT", obj.MAPT),
                new SqlParameter("@MASV", obj.MASV),
                new SqlParameter("@NIENKHOA", obj.NIENKHOA),
                new SqlParameter("@HOCKY", obj.HOCKY),
                new SqlParameter("@NGAYDONG", obj.NGAYDONG),
                new SqlParameter("@SOTIENDONG", obj.SOTIENDONG)
            };
            return _dbConnect.ExecuteSQL("sp_DONGHOCPHI_update", param);
        }

        public int Delete(int ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("@MADHP", ID)
            };
            return _dbConnect.ExecuteSQL("sp_DONGHOCPHI_delete", param);
        }
    }
}
