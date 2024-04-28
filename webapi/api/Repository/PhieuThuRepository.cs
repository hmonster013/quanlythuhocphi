using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.PhieuThu;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;

namespace api.Repository
{
    public class PhieuThuRepository : IPhieuThuRepository
    {
        private readonly ApplicationDBContext _context;

        public PhieuThuRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<PHIEUTHU> CreateAsync(PHIEUTHU phieuthuModel)
        {
            await _context.PHIEUTHU.AddAsync(phieuthuModel);
            await _context.SaveChangesAsync();

            return phieuthuModel;
        }

        public async Task<PHIEUTHU> DeleteAsync(int maPT)
        {
            var phieuthuModel = await _context.PHIEUTHU.FirstOrDefaultAsync(x => x.MAPT == maPT);

            if (phieuthuModel == null)
            {
                return null;
            }

            _context.PHIEUTHU.Remove(phieuthuModel);
            await _context.SaveChangesAsync();

            return phieuthuModel;
        }

        public async Task<List<PHIEUTHU>> GetAllAsync()
        {
            return await _context.PHIEUTHU.ToListAsync();
        }

        public async Task<PHIEUTHU?> GetByIdAsync(int maPT)
        {
            return await _context.PHIEUTHU.FindAsync(maPT);
        }

        public async Task<List<PHIEUTHU>> GetDataByMASV(string maSinhVien)
        {
            var phieuthuModels = await _context.PHIEUTHU.Where(x => x.MASV == maSinhVien).ToListAsync();

            return phieuthuModels;
        }

        public async Task<PHIEUTHU?> GetDataByMaSVandHK(string maSinhVien, int hocKy)
        {
            var phieuthuModel = await _context.PHIEUTHU.FirstOrDefaultAsync(x => x.MASV == maSinhVien && x.HOCKY == hocKy);

            if (phieuthuModel == null)
            {
                return null;
            }

            return phieuthuModel;
        }

        public async Task<PHIEUTHU> UpdateAsync(int maPT, UpdatePhieuThuRequestDto updatePhieuThuRequestDto)
        {
            var phieuthuModel = await _context.PHIEUTHU.FirstOrDefaultAsync(x => x.MAPT == maPT);

            if (phieuthuModel == null)
            {
                return null;
            }

            phieuthuModel.MASV = updatePhieuThuRequestDto.MASV;
            phieuthuModel.NIENKHOA = updatePhieuThuRequestDto.NIENKHOA;
            phieuthuModel.HOCKY = updatePhieuThuRequestDto.HOCKY;
            
            await _context.SaveChangesAsync();

            return phieuthuModel;
        }
    }
}