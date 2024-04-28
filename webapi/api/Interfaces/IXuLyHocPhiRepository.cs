using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.XuLyHocPhi;

namespace api.Interfaces
{
    public interface IXuLyHocPhiRepository
    {
        Task<HocPhiDto> GetDataTongHocPhiOfSV(string maSinhVien);
        Task<HocPhiDto?> GetDataBySVandHK(string maSinhVien, int hocKy);
    }
}