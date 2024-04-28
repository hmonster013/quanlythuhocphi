using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ChuyenNganh;
using api.Dtos.CTChuyenNganh;
using api.Models;

namespace api.Interface
{
    public interface ICTChuyenNganhRepository
    {
        Task<List<CTCHUYENNGANH>> GetAllAsync();
        Task<CTCHUYENNGANH?> GetByIdAsync(int maCTCN);
        Task<CTCHUYENNGANH> CreateAsync(CTCHUYENNGANH ctchuyennganhModel);
        Task<CTCHUYENNGANH> UpdateAsync(int maCTCN, UpdateCTChuyenNganhRequestDto updateCTChuyenNganhRequestDto);
        Task<CTCHUYENNGANH> DeleteAsync(int maCTCN);
        Task<CTCHUYENNGANH> DeleteByMaMHAsync(string maMonHoc);        
    }
}