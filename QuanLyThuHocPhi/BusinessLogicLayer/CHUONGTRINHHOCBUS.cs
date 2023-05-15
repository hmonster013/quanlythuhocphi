using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CHUONGTRINHHOCBUS
    {
        private CHUONGTRINHHOCDAO dao = new CHUONGTRINHHOCDAO();
        public DataTable GetData(string MASV)
        {
            return dao.GetData(MASV);
        }

        public DataTable GetData(string MASV, int HOCKY)
        {
            return dao.GetData(MASV, HOCKY);
        }

        public DataTable GetDataByTenMH(string  MASV, string TENMH)
        {
            return dao.GetDataByTenMH(MASV, TENMH);
        }

        public DataTable GetDataByTenMH(string MASV, string TENMH, int HOCKY)
        {
            return dao.GetDataByTenMH(MASV, TENMH, HOCKY);
        }

        public DataTable GetDataByChuyenNganh(string MACN)
        {
            return dao.GetDataByChuyenNganh(MACN);
        }

        public DataTable FindByTenMHandChuyenNganh(string MACN, string TENM)
        {
            return dao.FindByTenMHandChuyenNganh(MACN, TENM);
        }

        public DataTable GetDataNotInChuyenNganh(string MACN)
        {
            return dao.GetDataNotInChuyenNganh(MACN);
        }

        public DataTable FindByTenMHNotInChuyenNganh(string MASV, string TENMH)
        {
            return dao.FindByTenMHNotInChuyenNganh(MASV, TENMH);
        }
    }
}
