using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.GiangVien;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class GiangVienRepository : IGiangVienRepository
    {
        private readonly ApplicationDBContext _context;

        public GiangVienRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<GIANGVIEN> CreateAsync(GIANGVIEN giangvienModel)
        {
            await _context.GIANGVIEN.AddAsync(giangvienModel);
            await _context.SaveChangesAsync();

            return giangvienModel;
        }

        public async Task<GIANGVIEN> DeleteAsync(string maGV)
        {
            var giangvienModel = await _context.GIANGVIEN.FirstOrDefaultAsync(x => x.MAGV == maGV);

            if (giangvienModel == null)
            {
                return null;
            }

            _context.GIANGVIEN.Remove(giangvienModel);
            await _context.SaveChangesAsync();

            return giangvienModel;
        }

        public async Task<List<GIANGVIEN>> GetAllAsync()
        {
            return await _context.GIANGVIEN.ToListAsync();
        }

        public async Task<GIANGVIEN?> GetByIdAsync(string maGV)
        {
            return await _context.GIANGVIEN.FindAsync(maGV);
        }

        public async Task<GIANGVIEN> UpdateAsync(string maGV, UpdateGiangVienRequestDto updateGiangVienRequestDto)
        {
            var giangvienModel = await _context.GIANGVIEN.FirstOrDefaultAsync(x => x.MAGV == maGV);

            if (giangvienModel == null)
            {
                return null;
            }

            giangvienModel.MAKHOA = updateGiangVienRequestDto.MAKHOA;
            giangvienModel.HO = updateGiangVienRequestDto.HO;
            giangvienModel.TEN = updateGiangVienRequestDto.TEN;
            giangvienModel.HOCHAM = updateGiangVienRequestDto.HOCHAM;

            await _context.SaveChangesAsync();

            return giangvienModel;
        }
    }
}