using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using ValueObject.CTPhieuThu;

namespace BusinessLogicLayer
{
    public class CTPHIEUTHUBUS
    {
        private readonly CTPHIEUTHUDAO dao = new CTPHIEUTHUDAO();

        public async Task<List<CTPHIEUTHU>> GetData()
        {
            return await dao.GetData();
        }

        public async Task<CTPHIEUTHU> GetData(int maCTPT)
        {
            return await dao.GetDataByMaCTPT(maCTPT);
        }

        public async Task<List<CTPHIEUTHU>> GetDataByMaPT(int MAPT)
        {
            return await dao.GetDataByMaPT(MAPT);
        }

        public async Task<int> Insert(CTPHIEUTHU obj)
        {
            return await dao.Insert(obj.ToCreateDTOFromCTPhieuThu());
        }

        public async Task<int> Update(CTPHIEUTHU obj)
        {
            return await dao.Update(obj.MACTPT, obj.ToUpdateDTOFromCTPhieuThu());
        }

        public async Task<int> Delete(int maCTPT)
        {
            return await dao.Delete(maCTPT);
        }
    }
}
