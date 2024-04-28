using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DangKy;
using api.Models;

namespace api.Interfaces
{
    public interface IDangKyRepository
    {
        Task<List<DANGKY>> GetAllAsync();
        Task<DANGKY?> GetByIdAsync(int maDK);
        Task<List<DANGKY>> GetDataByMASV(string maSinhVien);
        Task<DANGKY?> GetDataByMASVandHOCKY(string maSinhVien, int hocKy);
        Task<DANGKY> CreateAsync(DANGKY dangkyModel);
        Task<DANGKY> UpdateAsync(int maDK, UpdateDangKyRequestDto updateDangKyRequestDto);
        Task<DANGKY> DeleteAsync(int maDK);        
    }
}