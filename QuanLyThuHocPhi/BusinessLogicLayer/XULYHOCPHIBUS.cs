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

        public DataTable GetDataHocPhi(string MASV, int HOCKY)
        {
            return dao.GetDataHocPhi(MASV, HOCKY);
        }
    }
}
