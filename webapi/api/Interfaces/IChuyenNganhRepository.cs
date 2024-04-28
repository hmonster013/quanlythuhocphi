using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ChuyenNganh;
using api.Models;

namespace api.Interfaces
{
    public interface IChuyenNganhRepository
    {
        Task<List<CHUYENNGANH>> GetAllAsync();
        Task<CHUYENNGANH?> GetByIdAsync(string maCN);
        Task<List<CHUYENNGANH>> GetDataByMaKhoa(string maKhoa);
        Task<CHUYENNGANH> CreateAsync(CHUYENNGANH chuyennganhModel);
        Task<CHUYENNGANH> UpdateAsync(string maCN, UpdateChuyenNganhRequestDto updateChuyenNganhRequestDto);
        Task<CHUYENNGANH> DeleteAsync(string maCN);
        
    }
}