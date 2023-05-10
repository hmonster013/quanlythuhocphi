using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using ValueObject;

namespace BusinessLogicLayer
{
    public class DANGKYBUS
    {
        DANGKYDAO dao  = new DANGKYDAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetData(int ID)
        {
            return dao.GetDataByID(ID);
        }

        public DataTable GetDataByMASV(string MASV)
        {
            return dao.GetDataByMASV(MASV);
        }

        public DataTable GetDataByMASVandHOCKY(DANGKY obj)
        {
            return dao.GetDataByMASVandHOCKY(obj);
        }

        public DataTable GetDataSTTMaDK()
        {
            return dao.GetDataSTTMaDK();
        }

        public int Insert(DANGKY obj)
        {
            return dao.Insert(obj);
        }

        public int Update(DANGKY obj)
        {
            return dao.Update(obj);
        }

        public int Delete(int ID)
        {
            return dao.Delete(ID);
        }
    }
}
