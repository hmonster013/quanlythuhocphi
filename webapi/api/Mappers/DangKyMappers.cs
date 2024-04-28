using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.DangKy;
using api.Models;

namespace api.Mappers
{
    public static class DangKyMappers
    {
        public static DangKyDto ToDangKyDTO(this DANGKY dangkyModel)
        {
            return new DangKyDto
            {
                MADK = dangkyModel.MADK,
                HOCKY = dangkyModel.HOCKY,
                MASV = dangkyModel.MASV
            };
        }

        public static DANGKY ToDangKyFromCreateDTO(this CreateDangKyRequestDto createDangKyRequestDto)
        {
            return new DANGKY
            {
                HOCKY = createDangKyRequestDto.HOCKY,
                MASV = createDangKyRequestDto.MASV
            };
        }
    }
}