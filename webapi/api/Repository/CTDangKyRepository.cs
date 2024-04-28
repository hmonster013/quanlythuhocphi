using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.CTDangKy;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CTDangKyRepository : ICTDangKyRepository
    {
        private readonly ApplicationDBContext _context;

        public CTDangKyRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<CTDANGKY> CreateAsync(CTDANGKY ctdangkyModel)
        {
            await _context.CTDANGKY.AddAsync(ctdangkyModel);
            await _context.SaveChangesAsync();

            return ctdangkyModel;
        }

        public async Task<CTDANGKY> DeleteAsync(int maCTDK)
        {
            var ctdangkyModel = await _context.CTDANGKY.FirstOrDefaultAsync(x => x.MACTDK == maCTDK);

            if (ctdangkyModel == null)
            {
                return null;
            }

            _context.CTDANGKY.Remove(ctdangkyModel);
            await _context.SaveChangesAsync();

            return ctdangkyModel;
        }

        public async Task<CTDANGKY?> DeleteByCondition(int maDangKy, int maLopHocPhan)
        {
            var ctdangky = await _context.CTDANGKY.FirstOrDefaultAsync(x => x.MADK == maDangKy && x.MALHP == maLopHocPhan);

            if (ctdangky == null)
            {
                return null;
            }

            _context.Remove(ctdangky);
            await _context.SaveChangesAsync();

            return ctdangky;
        }

        public async Task<List<CTDANGKY>> GetAllAsync()
        {
            return await _context.CTDANGKY.ToListAsync();
        }

        public async Task<CTDANGKY?> GetByIdAsync(int maCTDK)
        {
            return await _context.CTDANGKY.FindAsync(maCTDK);
        }

        public async Task<CTDANGKY> UpdateAsync(int maCTDK, UpdateCTDangKyRequestDto updateCTDangKyRequestDto)
        {
            var ctdangkyModel = await _context.CTDANGKY.FirstOrDefaultAsync(x => x.MACTDK == maCTDK);

            if (ctdangkyModel == null)
            {
                return null;
            }

            ctdangkyModel.MALHP = updateCTDangKyRequestDto.MALHP;
            ctdangkyModel.MADK = updateCTDangKyRequestDto.MADK;

            await _context.SaveChangesAsync();

            return ctdangkyModel;
        }
    }
}