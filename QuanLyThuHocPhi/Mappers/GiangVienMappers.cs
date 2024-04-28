using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject.GiangVien;
using ValueObject;

namespace Mappers
{
    public static class GiangVienMappers
    {
        public static CreateGiangVienRequestDto ToCreateDTOFromGiangVien(this GIANGVIEN giangVien)
        {
            return new CreateGiangVienRequestDto
            {
                MAGV = giangVien.MAGV,
                MAKHOA = giangVien.MAKHOA,
                HO = giangVien.HO,
                TEN = giangVien.TEN,
                HOCHAM = giangVien.HOCHAM
            };
        }

        public static UpdateGiangVienRequestDto ToUpdateDTOFromGiangVien(this GIANGVIEN giangVien)
        {
            return new UpdateGiangVienRequestDto
            {
                MAKHOA = giangVien.MAKHOA,
                HO = giangVien.HO,
                TEN = giangVien.TEN,
                HOCHAM = giangVien.HOCHAM
            };
        }
    }
}