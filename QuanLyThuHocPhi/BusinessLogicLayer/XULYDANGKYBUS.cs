using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace BusinessLogicLayer
{
    public class XULYDANGKYBUS
    {
        private XULYDANGKYDAO dao = new XULYDANGKYDAO();
        public DataTable GetData(DANGKY obj)
        {
            return dao.GetData(obj);
        }

        public DataTable GetData(DANGKY obj, string TENMH)
        {
            return dao.GetData(obj, TENMH);
        }

        public DataTable GetDataLHPChuaDK(DANGKY obj)
        {
            return dao.GetDataLHPChuaDK(obj);
        }
    }
}
