using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.LopHocPhan;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class LopHocPhanRepository : ILopHocPhanRepository
    {
        private readonly ApplicationDBContext _context;

        public LopHocPhanRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<LOPHOCPHAN> CreateAsync(LOPHOCPHAN lophocphanModel)
        {
            await _context.LOPHOCPHAN.AddAsync(lophocphanModel);
            await _context.SaveChangesAsync();

            return lophocphanModel;
        }

        public async Task<LOPHOCPHAN> DeleteAsync(int maLHP)
        {
            var lophocphanModel = await _context.LOPHOCPHAN.FirstOrDefaultAsync(x => x.MALHP == maLHP);

            if (lophocphanModel == null)
            {
                return null;
            }

            _context.LOPHOCPHAN.Remove(lophocphanModel);
            await _context.SaveChangesAsync();

            return lophocphanModel;
        }

        public async Task<List<LOPHOCPHAN>> GetAllAsync()
        {
            return await _context.LOPHOCPHAN.ToListAsync();
        }

        public async Task<LOPHOCPHAN?> GetByIdAsync(int maLHP)
        {
            return await _context.LOPHOCPHAN.FindAsync(maLHP);
        }

        public async Task<List<LOPHOCPHAN>> GetDataByChuyenNganh(string maChuyenNganh)
        {
            var lophocphan = await _context.LOPHOCPHAN.Where(x => x.MACN == maChuyenNganh).ToListAsync();
            
            return lophocphan;
        }

        public async Task<LOPHOCPHAN> UpdateAsync(int maLHP, UpdateLopHocPhanRequestDto updateLopHocPhanRequestDto)
        {
            var lophocphanModel = await _context.LOPHOCPHAN.FirstOrDefaultAsync(x => x.MALHP == maLHP);

            if (lophocphanModel == null)
            {
                return null;
            }

            lophocphanModel.NIENKHOA = updateLopHocPhanRequestDto.NIENKHOA;
            lophocphanModel.HOCKY = updateLopHocPhanRequestDto.HOCKY;
            lophocphanModel.MAMH = updateLopHocPhanRequestDto.MAMH;
            lophocphanModel.MAGV = updateLopHocPhanRequestDto.MAGV;
            lophocphanModel.MACN = updateLopHocPhanRequestDto.MACN;
            lophocphanModel.HUYLOP = updateLopHocPhanRequestDto.HUYLOP;
            
            await _context.SaveChangesAsync();

            return lophocphanModel;            
        }
    }
}