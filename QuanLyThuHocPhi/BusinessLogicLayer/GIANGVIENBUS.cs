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
    public class GIANGVIENBUS
    {
        GIANGVIENDAO dao = new GIANGVIENDAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetData(string ID)
        {
            return dao.GetDataByID(ID);
        }

        public DataTable GetDataByChuyenNganh(string MACN)
        {
            return dao.GetDataByChuyenNganh(MACN);
        }

        public int Insert(GIANGVIEN obj)
        {
            return dao.Insert(obj);
        }

        public int Update(GIANGVIEN obj)
        {
            return dao.Update(obj);
        }

        public int Delete(string ID)
        {
            return dao.Delete(ID);
        }
    }
}
