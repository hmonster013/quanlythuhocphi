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
            return dao.getData(MASV);
        }
    }
}
