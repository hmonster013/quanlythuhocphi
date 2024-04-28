using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject;
using ValueObject.MonHoc;

namespace BusinessLogicLayer
{
    public class MONHOCBUS
    {
        private MONHOCDAO dao = new MONHOCDAO();

        public async Task<List<MONHOC>> GetData()
        {
            return await dao.GetData();
        }

        public async Task<MONHOC> GetData(string maMH)
        {
            return await dao.GetDataByID(maMH);
        }

        public async Task<int> Insert(MONHOC obj)
        {
            return await dao.Insert(obj.ToCreateDTOFromMonHoc());
        }

        public async Task<int> Update(MONHOC obj)
        {
            return await dao.Update(obj.MAMH, obj.ToUpdateDTOFromMonHoc());
        }

        public async Task<int> Delete(string maMH)
        {
            return await dao.Delete(maMH);
        }
    }
}
