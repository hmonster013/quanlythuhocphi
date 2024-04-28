using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.CTPhieuThu;
using api.Models;

namespace api.Interfaces
{
    public interface ICTPhieuThuRepository
    {
        Task<List<CTPHIEUTHU>> GetAllAsync();
        Task<CTPHIEUTHU?> GetByIdAsync(int maCTPT);
        Task<List<CTPHIEUTHU>> GetDataByMaPT(int maPT);
        Task<CTPHIEUTHU> CreateAsync(CTPHIEUTHU ctphieuthuModel);
        Task<CTPHIEUTHU> UpdateAsync(int maCTPT, UpdateCTPhieuThuRequestDto updateCTPhieuThuRequestDto);
        Task<CTPHIEUTHU> DeleteAsync(int maCTPT);        
    }
}