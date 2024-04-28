using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.ChuyenNganh;
using DataAccessLayer;
using Mappers;

namespace BusinessLogicLayer
{
    public class CHUYENNGANHBUS
    {
        private readonly CHUYENNGANHDAO _dao;

        public CHUYENNGANHBUS()
        {
            _dao = new CHUYENNGANHDAO();
        }

        public async Task<List<CHUYENNGANH>> GetData()
        {
            return await _dao.GetData();
        }

        public async Task<CHUYENNGANH> GetData(string maCN)
        {
            return await _dao.GetDataByID(maCN);
        }

        public async Task<List<CHUYENNGANH>> GetDataByMAKHOA(string MAKHOA)
        {
            return await _dao.GetDataByMAKHOA(MAKHOA);
        }

        public async Task<int> Insert(CHUYENNGANH obj)
        {
            return await _dao.Insert(obj.ToCreateDTOFromChuyenNganh());
        }

        public async Task<int> Update(CHUYENNGANH obj)
        {
            return await _dao.Update(obj.MACN, obj.ToUpdateDTOFromChuyenNganh());
        }

        public async Task<int> Delete(string maCN)
        {
            return await _dao.Delete(maCN);
        }
    }
}
