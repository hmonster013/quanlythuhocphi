using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.SinhVien;
using api.Models;

namespace api.Mappers
{
    public static class SinhVienMappers
    {
        public static SinhVienDto ToSinhVienDTO(this SINHVIEN sinhvienModel)
        {
            return new SinhVienDto
            {
                MASV = sinhvienModel.MASV,
                HO = sinhvienModel.HO,
                TEN = sinhvienModel.TEN,
                MALOP = sinhvienModel.MALOP,
                PHAI = sinhvienModel.PHAI,
                NGAYSINH = sinhvienModel.NGAYSINH,
                DIACHI = sinhvienModel.DIACHI,
                DANGNGHIHOC = sinhvienModel.DANGNGHIHOC,
                TENTAIKHOAN = sinhvienModel.TENTAIKHOAN
            };
        }

        public static SINHVIEN ToSinhVienFromCreateDTO(this CreateSinhVienRequestDto createSinhVienRequestDto)
        {
            return new SINHVIEN
            {
                MASV = createSinhVienRequestDto.MASV,
                HO = createSinhVienRequestDto.HO,
                TEN = createSinhVienRequestDto.TEN,
                MALOP = createSinhVienRequestDto.MALOP,
                PHAI = createSinhVienRequestDto.PHAI,
                NGAYSINH = createSinhVienRequestDto.NGAYSINH,
                DIACHI = createSinhVienRequestDto.DIACHI,
                DANGNGHIHOC = createSinhVienRequestDto.DANGNGHIHOC,
                TENTAIKHOAN = createSinhVienRequestDto.TENTAIKHOAN
            };
        }
    }
}