using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using ValueObject.CTDangKy;

namespace BusinessLogicLayer
{
    public class CTDANGKYBUS
    {
        CTDANGKYDAO dao = new CTDANGKYDAO();

        public async Task<List<CTDANGKY>> GetData()
        {
            return await dao.GetData();
        }

        public async Task<CTDANGKY> GetData(int maCTDK)
        {
            return await dao.GetDataByID(maCTDK);
        }

        public async Task<int> Insert(CTDANGKY obj)
        {
            return await dao.Insert(obj.ToCreateDTOFromCTDangKy());
        }

        public async Task<int> Update(CTDANGKY obj)
        {
            return await dao.Update(obj.MACTDK, obj.ToUpdateDTOFromCTDangKy());
        }

        public async Task<int> Delete(int maCTDK)
        {
            return await dao.Delete(maCTDK);
        }   

        public async Task<int> DeleteByCondition(int maDangKy, int maLopHocPhan)
        {
            return await dao.DeleteByCondition(maDangKy, maLopHocPhan);
        }
    }
}
