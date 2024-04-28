using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ChuyenNganh;
using api.Models;

namespace api.Mappers
{
    public static class ChuyenNganhMappers
    {
        public static ChuyenNganhDto ToChuyenNganhDTO(this CHUYENNGANH chuyennganhModel)
        {
            return new ChuyenNganhDto
            {
                MACN = chuyennganhModel.MACN,
                TENCN = chuyennganhModel.TENCN,
                MAKHOA = chuyennganhModel.MAKHOA
            };
        }

        public static CHUYENNGANH ToChuyenNganhFromCreateDTO(this CreateChuyenNganhRequestDto createChuyenNganhRequestDto)
        {
            return new CHUYENNGANH
            {
                MACN = createChuyenNganhRequestDto.MACN,
                TENCN = createChuyenNganhRequestDto.TENCN,
                MAKHOA = createChuyenNganhRequestDto.MAKHOA
            };
        }
    }
}