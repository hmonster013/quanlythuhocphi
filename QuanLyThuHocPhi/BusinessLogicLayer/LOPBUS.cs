using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using ValueObject.Lop;

namespace BusinessLogicLayer
{
    public class LOPBUS
    {
        private readonly LOPDAO _dao;

        public LOPBUS()
        {
            _dao = new LOPDAO();
        }

        public async Task<List<LOP>> GetData()
        {
            return await _dao.GetData();
        }

        public async Task<LOP> GetData(string maLop)
        {
            return await _dao.GetDataByID(maLop);
        }

        public async Task<List<LOP>> GetDataByMAKHOA(string MAKHOA)
        {
            return await _dao.GetDataByMAKHOA(MAKHOA);
        }

        public async Task<List<LOP>> GetdataByMACN(string MACN)
        {
            return await _dao.GetDataByMACN(MACN);
        }

        public async Task<int> Insert(LOP obj)
        {
            return await _dao.Insert(obj.ToCreateDTOFromLop());
        }

        public async Task<int> Update(LOP obj)
        {
            return await _dao.Update(obj.MALOP, obj.ToUpdateDTOFromLop());
        }

        public async Task<int> Delete(string maLop)
        {
            return await _dao.Delete(maLop);
        }
    }
}
