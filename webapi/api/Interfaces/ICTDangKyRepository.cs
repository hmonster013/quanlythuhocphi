using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.CTDangKy;
using api.Models;

namespace api.Interfaces
{
    public interface ICTDangKyRepository
    {
        Task<List<CTDANGKY>> GetAllAsync();
        Task<CTDANGKY?> GetByIdAsync(int maCTDK);
        Task<CTDANGKY> CreateAsync(CTDANGKY ctdangkyModel);
        Task<CTDANGKY> UpdateAsync(int maCTDK, UpdateCTDangKyRequestDto updateCTDangKyRequestDto);
        Task<CTDANGKY> DeleteAsync(int maCTDK);
        Task<CTDANGKY?> DeleteByCondition(int maDangKy, int maLopHocPhan);
    }
}