using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.SinhVien;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class SinhVienRepository : ISinhVienRepository
    {
        private readonly ApplicationDBContext _context;

        public SinhVienRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<SINHVIEN> CreateAsync(SINHVIEN sinhvienModel)
        {
            await _context.SINHVIEN.AddAsync(sinhvienModel);
            await _context.SaveChangesAsync();

            return sinhvienModel;
        }

        public async Task<SINHVIEN> DeleteAsync(string maSV)
        {
            var sinhvienModel = await _context.SINHVIEN.FirstOrDefaultAsync(x => x.MASV == maSV);

            if (sinhvienModel == null)
            {
                return null;
            }

            _context.SINHVIEN.Remove(sinhvienModel);
            await _context.SaveChangesAsync();

            return sinhvienModel;
        }

        public async Task<List<SINHVIEN>> GetAllAsync()
        {
            return await _context.SINHVIEN.ToListAsync();
        }

        public async Task<SINHVIEN?> GetByIdAsync(string maSV)
        {
            return await _context.SINHVIEN.FindAsync(maSV);
        }

        public async Task<SINHVIEN> UpdateAsync(string maSV, UpdateSinhVienRequestDto updateSinhVienRequestDto)
        {
            var sinhvienModel = await _context.SINHVIEN.FirstOrDefaultAsync(x => x.MASV == maSV);

            if (sinhvienModel == null)
            {
                return null;
            }

            sinhvienModel.HO = updateSinhVienRequestDto.HO;
            sinhvienModel.TEN = updateSinhVienRequestDto.TEN;
            sinhvienModel.MALOP = updateSinhVienRequestDto.MALOP;
            sinhvienModel.PHAI = updateSinhVienRequestDto.PHAI;
            sinhvienModel.NGAYSINH = updateSinhVienRequestDto.NGAYSINH;
            sinhvienModel.DIACHI = updateSinhVienRequestDto.DIACHI;
            sinhvienModel.DANGNGHIHOC = updateSinhVienRequestDto.DANGNGHIHOC;
            sinhvienModel.TENTAIKHOAN = updateSinhVienRequestDto.TENTAIKHOAN;
            await _context.SaveChangesAsync();

            return sinhvienModel;
        }
    }
}