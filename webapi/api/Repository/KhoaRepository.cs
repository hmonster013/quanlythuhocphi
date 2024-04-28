using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Khoa;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class KhoaRepository : IKhoaRepository
    {
        private readonly ApplicationDBContext _context;

        public KhoaRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<KHOA> CreateAsync(KHOA khoaModel)
        {
            await _context.KHOA.AddAsync(khoaModel);
            await _context.SaveChangesAsync();

            return khoaModel;
        }

        public async Task<KHOA> DeleteAsync(string maKhoa)
        {
            var khoaModel = await _context.KHOA.FirstOrDefaultAsync(x => x.MAKHOA == maKhoa);

            if (khoaModel == null)
            {
                return null;
            }

            _context.KHOA.Remove(khoaModel);
            await _context.SaveChangesAsync();

            return khoaModel;
        }

        public async Task<List<KHOA>> GetAllAsync()
        {
            return await _context.KHOA.ToListAsync();
        }

        public async Task<KHOA?> GetByIdAsync(string maKhoa)
        {
            return await _context.KHOA.FindAsync(maKhoa);
        }

        public async Task<KHOA> UpdateAsync(string maKhoa, UpdateKhoaRequestDto updateKhoaRequestDto)
        {
            var khoaModel = await _context.KHOA.FirstOrDefaultAsync(x => x.MAKHOA == maKhoa);

            if (khoaModel == null)
            {
                return null;
            }

            khoaModel.TENKHOA = updateKhoaRequestDto.TENKHOA;
            khoaModel.DONGIA = updateKhoaRequestDto.DONGIA;

            await _context.SaveChangesAsync();

            return khoaModel;
        }
    }
}