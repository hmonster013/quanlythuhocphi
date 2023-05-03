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
    public class PHIEUTHUBUS
    {
        PHIEUTHUDAO dao = new PHIEUTHUDAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetData(int ID)
        {
            return dao.GetDataByID(ID);
        }

        public int Insert(ValueObject.PHIEUTHU obj)
        {
            return dao.Insert(obj);
        }

        public int Update(ValueObject.PHIEUTHU obj)
        {
            return dao.Update(obj);
        }

        public int Delete(int ID)
        {
            return dao.Delete(ID);
        }
    }
}
