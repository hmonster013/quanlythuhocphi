using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.NguoiDung;
using api.Models;

namespace api.Interfaces
{
    public interface INguoiDungRepository
    {
        Task<List<NGUOIDUNG>> GetAllAsync();
        Task<NGUOIDUNG?> GetByIdAsync(string tentaikhoan);
        Task<NGUOIDUNG> CreateAsync(NGUOIDUNG nguoidungModel);
        Task<NGUOIDUNG> UpdateAsync(string tentaikhoan, UpdateNguoiDungRequestDto nguoiDungRequestDto);
        Task<NGUOIDUNG> DeleteAsync(string tentaikhoan);
    }
}