using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.ChuyenNganh;
using api.Dtos.CTChuyenNganh;
using api.Models;

namespace api.Mappers
{
    public static class CTChuyenNganhMappers
    {
        public static CTChuyenNganhDto ToCTChuyenNganhDTO(this CTCHUYENNGANH ctchuyennganhModel)
        {
            return new CTChuyenNganhDto
            {
                MACTCN = ctchuyennganhModel.MACTCN,
                MACN = ctchuyennganhModel.MACN,
                MAMH = ctchuyennganhModel.MAMH
            };
        }

        public static CTCHUYENNGANH ToCTChuyenNganhFromCreateDTO(this CreateCTChuyenNganhRequestDto createCTChuyenNganhRequestDto)
        {
            return new CTCHUYENNGANH
            {
                MACN = createCTChuyenNganhRequestDto.MACN,
                MAMH = createCTChuyenNganhRequestDto.MAMH
            };
        }
    }
}