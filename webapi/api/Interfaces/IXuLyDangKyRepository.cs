using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.XuLyDangKy;

namespace api.Interfaces
{
    public interface IXuLyDangKyRepository
    {
        Task<List<LopHocPhanQueryDto>> GetDataLHPDaDK(int maDangKy, string maSinhVien, int hocKy);
        Task<List<LopHocPhanQueryDto>> GetDataLHPChuaDK(int maDangKy, string maSinhVien, int hocKy);
    }
}