using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.ChuyenNganh;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ChuyenNganhRepository : IChuyenNganhRepository
    {
        private readonly ApplicationDBContext _context;
        public ChuyenNganhRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CHUYENNGANH> CreateAsync(CHUYENNGANH chuyennganhModel)
        {
            await _context.CHUYENNGANH.AddAsync(chuyennganhModel);
            await _context.SaveChangesAsync();

            return chuyennganhModel;
        }

        public async Task<CHUYENNGANH> DeleteAsync(string maCN)
        {
            var chuyennganhModel = await _context.CHUYENNGANH.FirstOrDefaultAsync(x => x.MACN == maCN);

            if (chuyennganhModel == null)
            {
                return null;
            }

            _context.CHUYENNGANH.Remove(chuyennganhModel);
            await _context.SaveChangesAsync();

            return chuyennganhModel;
        }

        public async Task<List<CHUYENNGANH>> GetAllAsync()
        {
            return await _context.CHUYENNGANH.ToListAsync();
        }

        public async Task<CHUYENNGANH?> GetByIdAsync(string maCN)
        {
            return await _context.CHUYENNGANH.FindAsync(maCN);
        }

        public async Task<List<CHUYENNGANH>> GetDataByMaKhoa(string maKhoa)
        {
            return await _context.CHUYENNGANH.Where(x => x.MAKHOA == maKhoa).ToListAsync();
        }

        public async Task<CHUYENNGANH> UpdateAsync(string maCN, UpdateChuyenNganhRequestDto updateChuyenNganhRequestDto)
        {
            var chuyennganhModel = await _context.CHUYENNGANH.FirstOrDefaultAsync(x => x.MACN == maCN);

            if (chuyennganhModel == null)
            {
                return null;
            }

            chuyennganhModel.TENCN = updateChuyenNganhRequestDto.TENCN;
            chuyennganhModel.MAKHOA = updateChuyenNganhRequestDto.MAKHOA;

            await _context.SaveChangesAsync();

            return chuyennganhModel;
        }
    }
}