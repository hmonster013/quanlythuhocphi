using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject;
using ValueObject.SinhVien;

namespace Mappers
{
    public static class SinhVienMappers
    {
        public static CreateSinhVienRequestDto ToCreateDtoFromSinhVien(this SINHVIEN sinhVien)
        {
            return new CreateSinhVienRequestDto
            {
                MASV = sinhVien.MASV,
                HO = sinhVien.HO,
                TEN = sinhVien.TEN,
                MALOP = sinhVien.MALOP,
                PHAI = sinhVien.PHAI,
                NGAYSINH = sinhVien.NGAYSINH,
                DIACHI = sinhVien.DIACHI,
                DANGNGHIHOC = sinhVien.DANGNGHIHOC,
                TENTAIKHOAN = sinhVien.TENTAIKHOAN
            };
        }

        public static UpdateSinhVienRequestDto ToUpdateDtoFromSinhVien(this SINHVIEN sinhVien)
        {
            return new UpdateSinhVienRequestDto
            {
                HO = sinhVien.HO,
                TEN = sinhVien.TEN,
                MALOP = sinhVien.MALOP,
                PHAI = sinhVien.PHAI,
                NGAYSINH = sinhVien.NGAYSINH,
                DIACHI = sinhVien.DIACHI,
                DANGNGHIHOC = sinhVien.DANGNGHIHOC,
                TENTAIKHOAN = sinhVien.TENTAIKHOAN
            };
        }
    }
}