using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PhieuThu;
using api.Models;

namespace api.Interfaces
{
    public interface IPhieuThuRepository
    {
        Task<List<PHIEUTHU>> GetAllAsync();
        Task<PHIEUTHU?> GetByIdAsync(int maPT);
        Task<List<PHIEUTHU>> GetDataByMASV(string maSinhVien);
        Task<PHIEUTHU?> GetDataByMaSVandHK(string maSinhVien, int hocKy);
        Task<PHIEUTHU> CreateAsync(PHIEUTHU phieuthuModel);
        Task<PHIEUTHU> UpdateAsync(int maPT, UpdatePhieuThuRequestDto updatePhieuThuRequestDto);
        Task<PHIEUTHU> DeleteAsync(int maPT);        
    }
}