using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.LopHocPhan;
using api.Models;

namespace api.Interfaces
{
    public interface ILopHocPhanRepository
    {
        Task<List<LOPHOCPHAN>> GetAllAsync();
        Task<LOPHOCPHAN?> GetByIdAsync(int maLHP);
        Task<List<LOPHOCPHAN>> GetDataByChuyenNganh(string maChuyenNganh);
        Task<LOPHOCPHAN> CreateAsync(LOPHOCPHAN lophocphanModel);
        Task<LOPHOCPHAN> UpdateAsync(int maLHP, UpdateLopHocPhanRequestDto updateLopHocPhanRequestDto);
        Task<LOPHOCPHAN> DeleteAsync(int maLHP);        
    }
}