using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ChuongTrinhHocRepository : IChuongTrinhHocRepository
    {
        private readonly ApplicationDBContext _context;

        public ChuongTrinhHocRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<MONHOC>> GetDataBySinhVien(string maSinhVien)
        {
            var monhocModel = await _context.MONHOC
                                .Join(_context.CTCHUYENNGANH, monhoc => monhoc.MAMH, ctchuyennganh => ctchuyennganh.MAMH, (monhoc, ctchuyennganh) => new { MonHoc = monhoc, CTChuyenNganh = ctchuyennganh })
                                .Join(_context.CHUYENNGANH, joinedData => joinedData.CTChuyenNganh.MACN, chuyennganh => chuyennganh.MACN, (joinedData, chuyennganh) => new { MonHoc = joinedData.MonHoc, CTChuyenNganh= joinedData.CTChuyenNganh, ChuyenNganh = chuyennganh })
                                .Join(_context.LOP, joinedData => joinedData.ChuyenNganh.MACN, lop => lop.MACN, (joinedData, lop) => new { MonHoc = joinedData.MonHoc, CTChuyenNganh = joinedData.CTChuyenNganh, ChuyenNganh = joinedData.ChuyenNganh, Lop = lop})
                                .Join(_context.SINHVIEN, joinedData => joinedData.Lop.MALOP, sinhvien => sinhvien.MALOP, (joinedData, sinhvien) => new { MonHoc = joinedData.MonHoc, CTChuyenNganh = joinedData.CTChuyenNganh, ChuyenNganh = joinedData.ChuyenNganh, Lop = joinedData.Lop, SinhVien = sinhvien})
                                .Where(joinedData => joinedData.SinhVien.MASV == maSinhVien)
                                .Select(joinedData => joinedData.MonHoc)
                                .ToListAsync();

            return monhocModel;
        }

        public async Task<List<MONHOC>> GetDataBySVHocKy(string maSinhVien, int hocKy)
        {
            var monhocModel = await _context.MONHOC
                                .Join(_context.CTCHUYENNGANH, monhoc => monhoc.MAMH, ctchuyennganh => ctchuyennganh.MAMH, (monhoc, ctchuyennganh) => new { MonHoc = monhoc, CTChuyenNganh = ctchuyennganh })
                                .Join(_context.CHUYENNGANH, joinedData => joinedData.CTChuyenNganh.MACN, chuyennganh => chuyennganh.MACN, (joinedData, chuyennganh) => new { MonHoc = joinedData.MonHoc, CTChuyenNganh= joinedData.CTChuyenNganh, ChuyenNganh = chuyennganh })
                                .Join(_context.LOP, joinedData => joinedData.ChuyenNganh.MACN, lop => lop.MACN, (joinedData, lop) => new { MonHoc = joinedData.MonHoc, CTChuyenNganh = joinedData.CTChuyenNganh, ChuyenNganh = joinedData.ChuyenNganh, Lop = lop})
                                .Join(_context.SINHVIEN, joinedData => joinedData.Lop.MALOP, sinhvien => sinhvien.MALOP, (joinedData, sinhvien) => new { MonHoc = joinedData.MonHoc, CTChuyenNganh = joinedData.CTChuyenNganh, ChuyenNganh = joinedData.ChuyenNganh, Lop = joinedData.Lop, SinhVien = sinhvien})
                                .Where(joinedData => joinedData.SinhVien.MASV == maSinhVien && joinedData.MonHoc.HOCKY == hocKy)
                                .Select(joinedData => joinedData.MonHoc)
                                .ToListAsync();

            return monhocModel;
        }

        public async Task<List<MONHOC>> GetDataByChuyenNganh(string maChuyenNganh)
        {
            var monhoc = await _context.MONHOC
                                .Join(_context.CTCHUYENNGANH, monhoc => monhoc.MAMH, ctchuyennganh => ctchuyennganh.MAMH, (monhoc, ctchuyennganh) => new { MonHoc = monhoc, CTChuyenNganh = ctchuyennganh })
                                .Join(_context.CHUYENNGANH, joinedData => joinedData.CTChuyenNganh.MACN, chuyennganh => chuyennganh.MACN, (joinedData, chuyennganh) => new { MonHoc = joinedData.MonHoc, CTChuyenNganh = joinedData.CTChuyenNganh, ChuyenNganh = chuyennganh })
                                .Where(joinedData => joinedData.ChuyenNganh.MACN == maChuyenNganh)
                                .Select(joinedData => joinedData.MonHoc)
                                .ToListAsync();

            return monhoc;
        }

        public async Task<List<MONHOC>> GetDataNotInChuyenNganh(string maChuyenNganh)
        {
            var monhoc = await _context.MONHOC
                        .Where(monhoc => !_context.CHUYENNGANH
                            .Where(chuyennganh => chuyennganh.MACN == maChuyenNganh)
                            .Join(_context.CTCHUYENNGANH, chuyennganh => chuyennganh.MACN, ctchuyennganh => ctchuyennganh.MACN, (chuyennganh, ctchuyennganh) => ctchuyennganh.MAMH)
                            .Contains(monhoc.MAMH)).ToListAsync();

            return monhoc;
        }
    }
}