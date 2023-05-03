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
    public class KHOABUS
    {
        KHOADAO dao = new KHOADAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetData(string ID)
        {
            return dao.GetDataByID(ID);
        }

        public int Insert(KHOA obj)
        {
            return dao.Insert(obj);
        }

        public int Update(KHOA obj)
        {
            return dao.Update(obj);
        }

        public int Delete(string ID)
        {
            return dao.Delete(ID);
        }
    }
}
