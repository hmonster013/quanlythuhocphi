using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObject.SinhVien;

namespace BusinessLogicLayer
{
    public class SINHVIENBUS
    {
        private readonly SINHVIENDAO _dao = new SINHVIENDAO();

        public async Task<List<SINHVIEN>> GetData()
        {
            return await _dao.GetData();
        }

        public async Task<SINHVIEN> GetData(string maSV)
        {
            return await _dao.GetDataByID(maSV);
        }

        public async Task<int> Insert(SINHVIEN obj)
        {
            return await _dao.Insert(obj.ToCreateDtoFromSinhVien());
        }

        public async Task<int> Update(SINHVIEN obj)
        {
            return await _dao.Update(obj.MASV, obj.ToUpdateDtoFromSinhVien());
        }

        public async Task<int> Delete(string maSV)
        {
            return await _dao.Delete(maSV);
        }
    }
}
