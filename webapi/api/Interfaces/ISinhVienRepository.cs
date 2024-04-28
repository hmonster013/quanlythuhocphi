using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.SinhVien;
using api.Models;

namespace api.Interfaces
{
    public interface ISinhVienRepository
    {
        Task<List<SINHVIEN>> GetAllAsync();
        Task<SINHVIEN?> GetByIdAsync(string maSV);
        Task<SINHVIEN> CreateAsync(SINHVIEN sinhvienModel);
        Task<SINHVIEN> UpdateAsync(string maSV, UpdateSinhVienRequestDto updateSinhVienRequestDto);
        Task<SINHVIEN> DeleteAsync(string maSV);        
    }
}