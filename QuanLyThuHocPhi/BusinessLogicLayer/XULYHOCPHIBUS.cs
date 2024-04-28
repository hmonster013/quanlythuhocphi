using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using ValueObject.XuLyHocPhi;

namespace BusinessLogicLayer
{
    public class XULYHOCPHIBUS
    {
        private XULYHOCPHIDAO dao = new XULYHOCPHIDAO();

        public DataTable GetDataHocPhi(string MASV)
        {
            return dao.GetDataHocPhi(MASV);
        }

        public async Task<HocPhiDto> GetDataTongHocPhiOfSV(string MASV)
        {
            return await dao.GetDataTongHocPhiOfSV(MASV);
        }

        public async Task<HocPhiDto> GetDataBySVandHK(string MASV, int HOCKY)
        {
            return await dao.GetDataBySVandHK(MASV, HOCKY);
        }
        
        public DataTable GetAllDataHocPhi(string MAKHOA, string MACN, string MALOP)
        {
            return dao.GetAllDataHocPhi(MAKHOA, MACN, MALOP);
        }

        public DataTable GetAllDataTongHocPhi(string MAKHOA, string MACN, string MALOP)
        {
            return dao.GetAllDataTongHocPhi(MAKHOA, MACN, MALOP);
        }

        public DataTable GetAllDataNoHocPhi(string MAKHOA, string MACN, string MALOP)
        {
            return dao.GetAllDataNoHocPhi(MAKHOA , MACN, MALOP);
        }
    }
}
