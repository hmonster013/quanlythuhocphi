using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Lop;
using api.Dtos.LopHocPhan;
using api.Models;

namespace api.Interfaces
{
    public interface ILopRepository
    {
        Task<List<LOP>> GetAllAsync();
        Task<LOP?> GetByIdAsync(string maLop);
        Task<List<LOP>> GetDataByMaKhoa(string maKhoa);
        Task<List<LOP>> GetDataByMaCN(string maChuyenNganh);
        Task<LOP> CreateAsync(LOP lopModel);
        Task<LOP> UpdateAsync(string maLop, UpdateLopRequestDto updateLopRequestDto);
        Task<LOP> DeleteAsync(string maLop);        
    }
}