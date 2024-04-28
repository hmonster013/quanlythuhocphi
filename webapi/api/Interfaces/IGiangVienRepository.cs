using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.GiangVien;
using api.Models;

namespace api.Interfaces
{
    public interface IGiangVienRepository
    {
        Task<List<GIANGVIEN>> GetAllAsync();
        Task<GIANGVIEN?> GetByIdAsync(string maGV);
        Task<GIANGVIEN> CreateAsync(GIANGVIEN giangvienModel);
        Task<GIANGVIEN> UpdateAsync(string maGV, UpdateGiangVienRequestDto updateGiangVienRequestDto);
        Task<GIANGVIEN> DeleteAsync(string maGV);        
    }
}