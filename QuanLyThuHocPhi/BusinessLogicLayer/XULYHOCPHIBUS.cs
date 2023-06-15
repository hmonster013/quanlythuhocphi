using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class XULYHOCPHIBUS
    {
        private XULYHOCPHIDAO dao = new XULYHOCPHIDAO();

        public DataTable GetDataHocPhi(string MASV)
        {
            return dao.GetDataHocPhi(MASV);
        }

        public DataTable GetDataTongHocPHi(string MASV)
        {
            return dao.GetDataTongHocPhi(MASV);
        }

        public DataTable GetDataByHOCKY(string MASV, int HOCKY)
        {
            return dao.GetDataByHOCKY(MASV, HOCKY);
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
