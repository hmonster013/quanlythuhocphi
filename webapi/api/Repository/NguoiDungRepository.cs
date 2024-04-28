using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.NguoiDung;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class NguoiDungRepository : INguoiDungRepository
    {
        private readonly ApplicationDBContext _context;
        public NguoiDungRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<NGUOIDUNG> CreateAsync(NGUOIDUNG nguoidungModel)
        {
            await _context.NGUOIDUNG.AddAsync(nguoidungModel);
            await _context.SaveChangesAsync();

            return nguoidungModel;
        }

        public async Task<NGUOIDUNG> DeleteAsync(string tentaikhoan)
        {
            var nguoidungModel = await _context.NGUOIDUNG.FirstOrDefaultAsync(x => x.TENTAIKHOAN == tentaikhoan);

            if (nguoidungModel == null)
            {
                return null;
            }

            _context.NGUOIDUNG.Remove(nguoidungModel);
            await _context.SaveChangesAsync();

            return nguoidungModel;
        }

        public async Task<List<NGUOIDUNG>> GetAllAsync()
        {
            return await _context.NGUOIDUNG.ToListAsync();
        }

        public async Task<NGUOIDUNG?> GetByIdAsync(string tentaikhoan)
        {
            return await _context.NGUOIDUNG.FindAsync(tentaikhoan);
        }

        public async Task<NGUOIDUNG> UpdateAsync(string tentaikhoan, UpdateNguoiDungRequestDto nguoiDungRequestDto)
        {
            var nguoidungModel = await _context.NGUOIDUNG.FirstOrDefaultAsync(x => x.TENTAIKHOAN == tentaikhoan);

            if (nguoidungModel == null)
            {
                return null;
            }

            nguoidungModel.MATKHAU = nguoiDungRequestDto.MATKHAU;
            nguoidungModel.QUYEN = nguoiDungRequestDto.QUYEN;

            await _context.SaveChangesAsync();

            return nguoidungModel;
        }
    }
}