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
    public class CTCHUYENNGANHBUS
    {
        CTCHUYENNGANHDAO dao = new CTCHUYENNGANHDAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetData(string ID)
        {
            return dao.GetDataByID(ID);
        }

        public int Insert(CTCHUYENNGANH obj)
        {
            return dao.Insert(obj);
        }

        public int Update(CTCHUYENNGANH obj)
        {
            return dao.Update(obj);
        }

        public int Delete(int ID)
        {
            return dao.Delete(ID);
        }

        public int DeleteByMaMH(string MAMH)
        {
            return dao.DeleteByMaMH(MAMH);
        }
    }
}
