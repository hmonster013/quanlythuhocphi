using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IChuongTrinhHocRepository
    {
        Task<List<MONHOC>> GetDataNotInChuyenNganh(string maChuyenNganh);
        Task<List<MONHOC>> GetDataByChuyenNganh(string maChuyenNganh);
        Task<List<MONHOC>> GetDataBySinhVien(string maSinhVien);
        Task<List<MONHOC>> GetDataBySVHocKy(string maSinhVien, int hocKy);
    }
}