using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.DangKy;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class DangKyRepository : IDangKyRepository
    {
        private readonly ApplicationDBContext _context;

        public DangKyRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<DANGKY> CreateAsync(DANGKY dangkyModel)
        {
            await _context.DANGKY.AddAsync(dangkyModel);
            await _context.SaveChangesAsync();

            return dangkyModel;
        }

        public async Task<DANGKY> DeleteAsync(int maDK)
        {
            var dangkyModel = await _context.DANGKY.FirstOrDefaultAsync(x => x.MADK == maDK);

            if (dangkyModel == null)
            {
                return null;
            }

            _context.DANGKY.Remove(dangkyModel);
            await _context.SaveChangesAsync();

            return dangkyModel;
        }

        public async Task<List<DANGKY>> GetAllAsync()
        {
            return await _context.DANGKY.ToListAsync();
        }

        public async Task<DANGKY?> GetByIdAsync(int maDK)
        {
            return await _context.DANGKY.FindAsync(maDK);
        }

        public async Task<List<DANGKY>> GetDataByMASV(string maSinhVien)
        {
            return await _context.DANGKY.Where(x => x.MASV == maSinhVien).ToListAsync();
        }

        public async Task<DANGKY?> GetDataByMASVandHOCKY(string maSinhVien, int hocKy)
        {
            var dangkyModel = await _context.DANGKY.FirstOrDefaultAsync(x => x.MASV == maSinhVien && x.HOCKY == hocKy);

            if (dangkyModel == null)
            {
                return null;
            }

            return dangkyModel;
        }

        public async Task<DANGKY> UpdateAsync(int maDK, UpdateDangKyRequestDto updateDangKyRequestDto)
        {
            var dangkyModel = await _context.DANGKY.FirstOrDefaultAsync(x => x.MADK == maDK);

            if (dangkyModel == null)
            {
                return null;
            }

            dangkyModel.HOCKY = updateDangKyRequestDto.HOCKY;
            dangkyModel.MASV = updateDangKyRequestDto.MASV;

            await _context.SaveChangesAsync();

            return dangkyModel;
        }
    }
}