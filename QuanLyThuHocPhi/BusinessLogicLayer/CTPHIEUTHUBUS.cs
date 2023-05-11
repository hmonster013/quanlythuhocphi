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
    public class CTPHIEUTHUBUS
    {
        private CTPHIEUTHUDAO dao = new CTPHIEUTHUDAO();
        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetData(int MACTPT)
        {
            return dao.GetDataByMACTPT(MACTPT);
        }

        public DataTable GetDataByMaPT(int MAPT)
        {
            return dao.GetDataByMaPT(MAPT);
        }

        public DataTable GetDataSTTCTPT()
        {
            return dao.GetDataSTTCTPT();
        }

        public int Insert(CTPHIEUTHU obj)
        {
            return dao.Insert(obj);
        }

        public int Update(CTPHIEUTHU obj)
        {
            return dao.Update(obj);
        }
        public int Delete(int MACTPT)
        {
            return dao.Delete(MACTPT);
        }
    }
}
