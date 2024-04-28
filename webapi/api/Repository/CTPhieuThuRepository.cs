using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.CTPhieuThu;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CTPhieuThuRepository : ICTPhieuThuRepository
    {
        private readonly ApplicationDBContext _context;

        public CTPhieuThuRepository(ApplicationDBContext context)
        {   
            _context = context;
        }

        public async Task<CTPHIEUTHU> CreateAsync(CTPHIEUTHU ctphieuthuModel)
        {
            await _context.CTPHIEUTHU.AddAsync(ctphieuthuModel);
            await _context.SaveChangesAsync();

            return ctphieuthuModel;
        }

        public async Task<CTPHIEUTHU> DeleteAsync(int maCTPT)
        {
            var ctphieuthuModel = await _context.CTPHIEUTHU.FirstOrDefaultAsync(x => x.MACTPT == maCTPT);

            if (ctphieuthuModel == null)
            {
                return null;
            }

            _context.CTPHIEUTHU.Remove(ctphieuthuModel);
            await _context.SaveChangesAsync();

            return ctphieuthuModel;
        }

        public async Task<List<CTPHIEUTHU>> GetAllAsync()
        {
            return await _context.CTPHIEUTHU.ToListAsync();
        }

        public async Task<CTPHIEUTHU?> GetByIdAsync(int maCTPT)
        {
            return await _context.CTPHIEUTHU.FindAsync(maCTPT);
        }

        public async Task<List<CTPHIEUTHU>> GetDataByMaPT(int maPT)
        {
            return await _context.CTPHIEUTHU.Where(x => x.MAPT == maPT).ToListAsync();
        }

        public async Task<CTPHIEUTHU> UpdateAsync(int maCTPT, UpdateCTPhieuThuRequestDto updateCTPhieuThuRequestDto)
        {
            var ctphieuthuModel = await _context.CTPHIEUTHU.FirstOrDefaultAsync(x => x.MACTPT == maCTPT);

            if (ctphieuthuModel == null)
            {
                return null;
            }

            ctphieuthuModel.MAPT = updateCTPhieuThuRequestDto.MAPT;
            ctphieuthuModel.NGAYDONG = updateCTPhieuThuRequestDto.NGAYDONG;
            ctphieuthuModel.SOTIENDONG = updateCTPhieuThuRequestDto.SOTIENDONG;

            await _context.SaveChangesAsync();

            return ctphieuthuModel;
        }
    }
}