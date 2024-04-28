using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.Khoa;

namespace BusinessLogicLayer
{
    public class KHOABUS
    {
        private readonly KHOADAO _dao = new KHOADAO();

        public async Task<List<KHOA>> GetData()
        {
            return await _dao.GetData();
        }

        public async Task<KHOA> GetData(string maKhoa)
        {
            return await _dao.GetDataByID(maKhoa);
        }

        public async Task<int> Insert(KHOA obj)
        {
            return await _dao.Insert(obj.ToCreateDTOFromKhoa());
        }

        public async Task<int> Update(KHOA obj)
        {
            return await _dao.Update(obj.MAKHOA, obj.ToUpdateDTOFromKhoa());
        }

        public async Task<int> Delete(string maKhoa)
        {
            return await _dao.Delete(maKhoa);
        }
    }
}
