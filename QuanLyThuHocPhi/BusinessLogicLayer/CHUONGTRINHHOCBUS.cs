using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ValueObject.MonHoc;

namespace BusinessLogicLayer
{
    public class CHUONGTRINHHOCBUS
    {
        private CHUONGTRINHHOCDAO dao = new CHUONGTRINHHOCDAO();

        public async Task<List<MONHOC>> GetDataBySinhVien(string MASV)
        {
            return await dao.GetDataBySinhVien(MASV);
        }

        public async Task<List<MONHOC>> GetDataBySVHocKy(string MASV, int HOCKY)
        {
            return await dao.GetDataBySVHocKy(MASV, HOCKY);
        }

        public async Task<List<MONHOC>> GetDataByChuyenNganh(string MACN)
        {
            return await dao.GetDataByChuyenNganh(MACN);
        }

        public async Task<List<MONHOC>> GetDataNotInChuyenNganh(string MACN)
        {
            return await dao.GetDataNotInChuyenNganh(MACN);
        }
    }
}
