using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class CHUYENNGANHBUS
    {
        CHUYENNGANHDAO dao = new CHUYENNGANHDAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetData(string ID)
        {
            return dao.GetDataByID(ID);
        }

        public int Insert(CHUYENNGANH obj)
        {
            return dao.Insert(obj);
        }

        public int Update(CHUYENNGANH obj)
        {
            return dao.Update(obj);
        }

        public int Delete(string ID)
        {
            return dao.Delete(ID);
        }
    }
}
