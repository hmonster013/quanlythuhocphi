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
    public class LOPBUS
    {
        LOPDAO dao = new LOPDAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetData(string ID)
        {
            return dao.GetDataByID(ID);
        }

        public DataTable GetDataByMAKHOA(string MAKHOA)
        {
            return dao.GetDataByMAKHOA(MAKHOA);
        }

        public DataTable GetdataByMACN(string MACN)
        {
            return dao.GetDataByMACN(MACN);
        }
        public int Insert(LOP obj)
        {
            return dao.Insert(obj);
        }

        public int Update(LOP obj)
        {
            return dao.Update(obj);
        }

        public int Delete(string ID)
        {
            return dao.Delete(ID);
        }
    }
}
