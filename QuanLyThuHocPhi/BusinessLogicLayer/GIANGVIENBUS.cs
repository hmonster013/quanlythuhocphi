using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.GiangVien;

namespace BusinessLogicLayer
{
    public class GIANGVIENBUS
    {
        GIANGVIENDAO dao = new GIANGVIENDAO();

        public async Task<List<GIANGVIEN>> GetData()
        {
            return await dao.GetData();
        }

        public async Task<GIANGVIEN> GetData(string maSV)
        {
            return await dao.GetDataByID(maSV);
        }

        public async Task<int> Insert(GIANGVIEN obj)
        {
            return await dao.Insert(obj.ToCreateDTOFromGiangVien());
        }

        public async Task<int> Update(GIANGVIEN obj)
        {
            return await dao.Update(obj.MAGV, obj.ToUpdateDTOFromGiangVien());
        }

        public async Task<int> Delete(string MACN)
        {
            return await dao.Delete(MACN);
        }
    }
}
