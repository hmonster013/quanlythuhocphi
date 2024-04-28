using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Lop;
using api.Dtos.LopHocPhan;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class LopRepository : ILopRepository
    {
        private readonly ApplicationDBContext _context;

        public LopRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<LOP> CreateAsync(LOP lopModel)
        {
            await _context.LOP.AddAsync(lopModel);
            await _context.SaveChangesAsync();

            return lopModel;
        }

        public async Task<LOP> DeleteAsync(string maLop)
        {
            var lopModel = await _context.LOP.FirstOrDefaultAsync(x => x.MALOP == maLop);

            if (lopModel == null)
            {
                return null;
            }

            _context.LOP.Remove(lopModel);
            await _context.SaveChangesAsync();

            return lopModel;
        }

        public async Task<List<LOP>> GetAllAsync()
        {
            return await _context.LOP.ToListAsync();
        }

        public async Task<LOP?> GetByIdAsync(string maLop)
        {
            return await _context.LOP.FindAsync(maLop);
        }

        public async Task<List<LOP>> GetDataByMaCN(string maChuyenNganh)
        {
            var lopModels = await _context.LOP
                                    .Where(x => x.MACN == maChuyenNganh)
                                    .ToListAsync();

            return lopModels;
        }

        public async Task<List<LOP>> GetDataByMaKhoa(string maKhoa)
        {
            var lopModels = await _context.LOP
                                    .Join(_context.CHUYENNGANH, lop => lop.MACN, chuyennganh => chuyennganh.MACN, (lop, chuyennganh) => new { Lop = lop, ChuyenNganh = chuyennganh})
                                    .Join(_context.KHOA, joinedData => joinedData.ChuyenNganh.MAKHOA, khoa => khoa.MAKHOA, (joinedData, khoa) => new { Lop = joinedData.Lop, ChuyenNganh = joinedData.ChuyenNganh, Khoa = khoa})
                                    .Where(joinedData => joinedData.Khoa.MAKHOA == maKhoa)
                                    .Select(joinedData => joinedData.Lop)
                                    .ToListAsync();

            return lopModels;
        }

        public async Task<LOP> UpdateAsync(string maLop, UpdateLopRequestDto updateLopRequestDto)
        {
            var lopModel = await _context.LOP.FirstOrDefaultAsync(x => x.MALOP == maLop);

            if (lopModel == null)
            {
                return null;
            }
            
            lopModel.MACN = updateLopRequestDto.MACN;

            await _context.SaveChangesAsync();

            return lopModel; 
        }
    }
}