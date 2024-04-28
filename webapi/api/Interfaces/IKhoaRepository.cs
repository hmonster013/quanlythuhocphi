using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Khoa;
using api.Models;

namespace api.Interfaces
{
    public interface IKhoaRepository
    {
        Task<List<KHOA>> GetAllAsync();
        Task<KHOA?> GetByIdAsync(string maKhoa);
        Task<KHOA> CreateAsync(KHOA khoaModel);
        Task<KHOA> UpdateAsync(string maKhoa, UpdateKhoaRequestDto updateKhoaRequestDto);
        Task<KHOA> DeleteAsync(string maKhoa);        
    }
}