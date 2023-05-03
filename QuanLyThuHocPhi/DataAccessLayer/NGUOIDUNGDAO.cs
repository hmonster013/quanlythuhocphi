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
    public class NGUOIDUNGDAO
    {
        dbConnect _dbConnect = new dbConnect();

        public DataTable GetData()
        {
            return _dbConnect.GetData("sp_NGUOIDUNG_select_all", null);
        }

        public DataTable GetDataByID(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("TENTAIKHOAN", ID)
            };
            return _dbConnect.GetData("sp_NGUOIDUNG_select_tentaikhoan", param);
        }

        public int Insert(NGUOIDUNG obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("TENTAIKHOAN", obj.TENTAIKHOAN),
                new SqlParameter("MATKHAU", obj.MATKHAU),
                new SqlParameter("QUYEN", obj.QUYEN)
            };
            return _dbConnect.ExecuteSQL("sp_NGUOIDUNG_insert", param);
        }

        public int Update(NGUOIDUNG obj)
        {
            SqlParameter[] param =
            {
                new SqlParameter("TENTAIKHOAN", obj.TENTAIKHOAN),
                new SqlParameter("MATKHAU", obj.MATKHAU),
                new SqlParameter("QUYEN", obj.QUYEN)
            };
            return _dbConnect.ExecuteSQL("sp_NGUOIDUNG_update", param);
        }

        public int Delete(string ID)
        {
            SqlParameter[] param =
            {
                new SqlParameter("TENTAIKHOAN", ID)
            };
            return _dbConnect.ExecuteSQL("sp_NGUOIDUNG_delete", param);
        }
    }
}

