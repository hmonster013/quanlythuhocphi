using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.CTChuyenNganh;

namespace BusinessLogicLayer
{
    public class CTCHUYENNGANHBUS
    {
        CTCHUYENNGANHDAO dao = new CTCHUYENNGANHDAO();

        public Task<List<CTCHUYENNGANH>> GetData()
        {
            return dao.GetData();
        }

        public async Task<CTCHUYENNGANH> GetData(int maCTCN)
        {
            return await dao.GetDataByID(maCTCN);
        }

        public async Task<int> Insert(CTCHUYENNGANH obj)
        {
            return await dao.Insert(obj.ToCreateDTOFromCTChuyenNganh());
        }

        public async Task<int> Update(CTCHUYENNGANH obj)
        {
            return await dao.Update(obj.MACTCN, obj.ToUpdateDTOFromCTChuyenNganh());
        }

        public async Task<int> Delete(int maCTCN)
        {
            return await dao.Delete(maCTCN);
        }

        public async Task<int> DeleteByMaMH(string MAMH)
        {
            return await dao.DeleteByMaMH(MAMH);
        }
    }
}
