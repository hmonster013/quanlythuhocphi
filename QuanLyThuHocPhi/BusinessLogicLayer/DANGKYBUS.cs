using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayer;
using Mappers;
using ValueObject.DangKy;

namespace BusinessLogicLayer
{
    public class DANGKYBUS
    {
        private readonly DANGKYDAO dao = new DANGKYDAO();

        public async Task<List<DANGKY>> GetData()
        {
            return await dao.GetData();
        }

        public async Task<DANGKY> GetData(int maDK)
        {
            return await dao.GetDataByID(maDK);
        }

        public async Task<List<DANGKY>> GetDataByMASV(string MASV)
        {
            return await dao.GetDataByMASV(MASV);
        }

        public async Task<DANGKY> GetDataByMASVandHOCKY(string MASV, int HOCKY)
        {
            return await dao.GetDataByMASVandHOCKY(MASV, HOCKY);
        }

        public async Task<int> Insert(DANGKY obj)
        {
            return await dao.Insert(obj.ToCreateDTOFromDangKy());
        }

        public async Task<int> Update(DANGKY obj)
        {
            return await dao.Update(obj.MADK, obj.ToUpdateDTOFromDangKy());
        }

        public async Task<int> Delete(int maDK)
        {
            return await dao.Delete(maDK);
        }
    }
}
