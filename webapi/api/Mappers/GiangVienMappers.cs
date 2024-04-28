using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.GiangVien;
using api.Models;

namespace api.Mappers
{
    public static class GiangVienMappers
    {
        public static GiangVienDto ToGiangVienDTO(this GIANGVIEN giangvienModel)
        {
            return new GiangVienDto
            {
                MAGV = giangvienModel.MAGV,
                MAKHOA = giangvienModel.MAKHOA,
                HO = giangvienModel.HO,
                TEN = giangvienModel.TEN,
                HOCHAM = giangvienModel.HOCHAM
            };
        }

        public static GIANGVIEN ToGiangVienFromCreateDTO(this CreateGiangVienRequestDto createGiangVienRequestDto)
        {
            return new GIANGVIEN
            {
                MAGV = createGiangVienRequestDto.MAGV,
                MAKHOA = createGiangVienRequestDto.MAKHOA,
                HO = createGiangVienRequestDto.HO,
                TEN = createGiangVienRequestDto.TEN,
                HOCHAM = createGiangVienRequestDto.HOCHAM
            };
        }
    }
}