using DataAccessLayer;
using Mappers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using ValueObject.NguoiDung;

namespace BusinessLogicLayer
{
    public class NGUOIDUNGBUS
    {
        private readonly NGUOIDUNGDAO _dao;

        public NGUOIDUNGBUS()
        {
            _dao = new NGUOIDUNGDAO();
        }

        public async Task<List<NGUOIDUNG>> GetData()
        {
            return await _dao.GetData();
        }

        public async Task<NGUOIDUNG> GetDataByID(string ID)
        {
            return await _dao.GetDataByID(ID);
        }

        public async Task<int> Insert(NGUOIDUNG obj)
        {
            return await _dao.Insert(obj.ToCreateDTOFromNguoiDung());
        }

        public async Task<int> Update(NGUOIDUNG obj)
        {
            return await _dao.Update(obj.TENTAIKHOAN, obj.ToUpdateDTOFromNguoiDung());
        }

        public async Task<int> Delete(string ID)
        {
            return await _dao.Delete(ID);
        }
    }
}
