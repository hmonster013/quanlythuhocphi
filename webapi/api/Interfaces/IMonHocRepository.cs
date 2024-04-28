using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.MonHoc;
using api.Models;

namespace api.Interfaces
{
    public interface IMonHocRepository
    {
        Task<List<MONHOC>> GetAllAsync();
        Task<MONHOC?> GetByIdAsync(string maMH);
        Task<MONHOC> CreateAsync(MONHOC monhocModel);
        Task<MONHOC> UpdateAsync(string maMH, UpdateMonHocRequestDto updateMonHocRequestDto);
        Task<MONHOC> DeleteAsync(string maMH);        
    }
}