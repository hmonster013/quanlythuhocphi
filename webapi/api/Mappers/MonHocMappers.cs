using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.MonHoc;
using api.Models;

namespace api.Mappers
{
    public static class MonHocMappers
    {
        public static MonHocDto ToMonHocDTO(this MONHOC monhocModel)
        {
            return new MonHocDto
            {
                MAMH = monhocModel.MAMH,
                TENMH = monhocModel.TENMH,
                HOCKY = monhocModel.HOCKY,
                SOTINCHI = monhocModel.SOTINCHI
            };
        }

        public static MONHOC ToMonHocFromCreateDTO(this CreateMonHocRequestDto createMonHocRequestDto)
        {
            return new MONHOC
            {
                MAMH = createMonHocRequestDto.MAMH,
                TENMH = createMonHocRequestDto.TENMH,
                HOCKY = createMonHocRequestDto.HOCKY,
                SOTINCHI = createMonHocRequestDto.SOTINCHI
            };
        }
    }
}