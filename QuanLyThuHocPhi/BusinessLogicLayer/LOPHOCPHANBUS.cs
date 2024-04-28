using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.LopHocPhan;

namespace BusinessLogicLayer
{
    public class LOPHOCPHANBUS
    {
        private readonly LOPHOCPHANDAO _dao = new LOPHOCPHANDAO();

        public async Task<List<LOPHOCPHAN>> GetData()
        {
            return await _dao.GetData();
        }

        public async Task<LOPHOCPHAN> GetData(int maLHP)
        {
            return await _dao.GetDataByID(maLHP);
        }

        public async Task<List<LOPHOCPHAN>> GetDataByChuyenNganh(string MACN)
        {
            return await _dao.GetDataByChuyenNganh(MACN);
        }

        public async Task<int> Insert(LOPHOCPHAN obj)
        {
            return await _dao.Insert(obj.ToCreateDTOFromLopHocPhan());
        }

        public async Task<int> Update(LOPHOCPHAN obj)
        {
            return await _dao.Update(obj.MALHP, obj.ToUpdateDTOFromLopHocPhan());
        }

        public async Task<int> Delete(int maLHP)
        {
            return await _dao.Delete(maLHP);
        }
    }
}
