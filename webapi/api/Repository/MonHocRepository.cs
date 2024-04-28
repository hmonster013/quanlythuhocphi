using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.MonHoc;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MonHocRepository : IMonHocRepository
    {
        private readonly ApplicationDBContext _context;

        public MonHocRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<MONHOC> CreateAsync(MONHOC monhocModel)
        {
            await _context.MONHOC.AddAsync(monhocModel);
            await _context.SaveChangesAsync();

            return monhocModel;
        }

        public async Task<MONHOC> DeleteAsync(string maMH)
        {
            var monhocModel = await _context.MONHOC.FirstOrDefaultAsync(x => x.MAMH == maMH);

            if (monhocModel == null)
            {
                return null;
            }

            _context.MONHOC.Remove(monhocModel);
            await _context.SaveChangesAsync();

            return monhocModel;
        }

        public async Task<List<MONHOC>> GetAllAsync()
        {
            return await _context.MONHOC.ToListAsync();
        }

        public async Task<MONHOC?> GetByIdAsync(string maMH)
        {
            return await _context.MONHOC.FindAsync(maMH);
        }

        public async Task<MONHOC> UpdateAsync(string maMH, UpdateMonHocRequestDto updateMonHocRequestDto)
        {
            var monhocModel = await _context.MONHOC.FirstOrDefaultAsync(x => x.MAMH == maMH);

            if (monhocModel == null)
            {
                return null;
            }

            monhocModel.TENMH = updateMonHocRequestDto.TENMH;
            monhocModel.HOCKY = updateMonHocRequestDto.HOCKY;
            monhocModel.SOTINCHI = updateMonHocRequestDto.SOTINCHI;
            
            await _context.SaveChangesAsync();

            return monhocModel;
        }
    }
}