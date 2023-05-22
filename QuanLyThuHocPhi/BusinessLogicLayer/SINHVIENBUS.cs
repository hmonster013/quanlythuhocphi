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
    public class SINHVIENBUS
    {
        SINHVIENDAO dao = new SINHVIENDAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetData(string ID)
        {
            return dao.GetDataByID(ID);
        }

        public DataTable GetDataByCondition(string MAKHOA, string MACN, string MALOP)
        {
            return dao.GetDataByCondition(MAKHOA, MACN, MALOP);
        }

        public int Insert(SINHVIEN obj)
        {
            return dao.Insert(obj);
        }

        public int Update(SINHVIEN obj)
        {
            return dao.Update(obj);
        }

        public int Delete(string ID)
        {
            return dao.Delete(ID);
        }
    }
}
