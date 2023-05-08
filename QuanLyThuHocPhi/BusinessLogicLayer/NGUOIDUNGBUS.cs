﻿using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;

namespace BusinessLogicLayer
{
    public class NGUOIDUNGBUS
    {
        NGUOIDUNGDAO dao = new NGUOIDUNGDAO();

        public DataTable GetData()
        {
            return dao.GetData();
        }

        public DataTable GetData(string ID)
        {
            return dao.GetDataByID(ID);
        }

        public int Insert(NGUOIDUNG obj)
        {
            return dao.Insert(obj);
        }

        public int Update(NGUOIDUNG obj)
        {
            return dao.Update(obj);
        }

        public int Delete(string ID)
        {
            return dao.Delete(ID);
        }
    }
}