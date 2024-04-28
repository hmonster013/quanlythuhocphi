using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.CTChuyenNganh;
using api.Interface;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CTChuyenNganhRepository : ICTChuyenNganhRepository
    {
        private readonly ApplicationDBContext _context;

        public CTChuyenNganhRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CTCHUYENNGANH> CreateAsync(CTCHUYENNGANH ctchuyennganhModel)
        {
            await _context.CTCHUYENNGANH.AddAsync(ctchuyennganhModel);
            await _context.SaveChangesAsync();

            return ctchuyennganhModel;
        }

        public async Task<CTCHUYENNGANH> DeleteAsync(int maCTCN)
        {
            var ctchuyennganhModel = await _context.CTCHUYENNGANH.FirstOrDefaultAsync(x => x.MACTCN == maCTCN);

            if (ctchuyennganhModel == null)
            {
                return null;
            }

            _context.CTCHUYENNGANH.Remove(ctchuyennganhModel);
            await _context.SaveChangesAsync();

            return ctchuyennganhModel;
        }

        public async Task<CTCHUYENNGANH> DeleteByMaMHAsync(string maMonHoc)
        {
            var ctchuyennganhModel = await _context.CTCHUYENNGANH.FirstOrDefaultAsync(x => x.MAMH == maMonHoc);

            if (ctchuyennganhModel == null)
            {
                return null;
            }

            _context.CTCHUYENNGANH.Remove(ctchuyennganhModel);
            await _context.SaveChangesAsync();

            return ctchuyennganhModel;
        }

        public async Task<List<CTCHUYENNGANH>> GetAllAsync()
        {
            return await _context.CTCHUYENNGANH.ToListAsync();
        }

        public async Task<CTCHUYENNGANH?> GetByIdAsync(int maCTCN)
        {
            return await _context.CTCHUYENNGANH.FindAsync(maCTCN);
        }

        public async Task<CTCHUYENNGANH> UpdateAsync(int maCTCN, UpdateCTChuyenNganhRequestDto updateCTChuyenNganhRequestDto)
        {
            var ctchuyennganhModel = await _context.CTCHUYENNGANH.FirstOrDefaultAsync(x => x.MACTCN == maCTCN);

            if (ctchuyennganhModel == null)
            {
                return null;
            }

            ctchuyennganhModel.MACN = updateCTChuyenNganhRequestDto.MACN;
            ctchuyennganhModel.MAMH = updateCTChuyenNganhRequestDto.MAMH;
            
            await _context.SaveChangesAsync();

            return ctchuyennganhModel;
        }
    }
}