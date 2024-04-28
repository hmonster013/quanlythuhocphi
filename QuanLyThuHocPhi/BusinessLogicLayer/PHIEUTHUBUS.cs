using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using ValueObject.PhieuThu;

namespace BusinessLogicLayer
{
    public class PHIEUTHUBUS
    {
        PHIEUTHUDAO dao = new PHIEUTHUDAO();

        public async Task<List<PHIEUTHU>> GetData()
        {
            return await dao.GetData();
        }

        public async Task<PHIEUTHU> GetData(int maPT)
        {
            return await dao.GetDataByID(maPT);
        }

        public async Task<List<PHIEUTHU>> GetDataByMASV(string MASV)
        {
            return await dao.GetDataByMASV(MASV);
        }

        public async Task<PHIEUTHU> GetDataByMaSVandHK(string MASV, int HOCKY)
        {
            return await dao.GetDataByMaSVandHK(MASV, HOCKY);
        }

        public async Task<int> Insert(PHIEUTHU obj)
        {
            return await dao.Insert(obj.ToCreateDTOFromPhieuThu());
        }

        public async Task<int> Update(PHIEUTHU obj)
        {
            return await dao.Update(obj.MAPT, obj.ToUpdateDTOFromPhieuThu());
        }

        public async Task<int> Delete(int maPT)
        {
            return await dao.Delete(maPT);
        }
    }
}
