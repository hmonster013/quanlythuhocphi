using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using api.Dtos.CTDangKy;
using api.Models;

namespace api.Mappers
{
    public static class CTDangKyMappers
    {
        public static CTDangKyDto ToCTDangKyDTO(this CTDANGKY ctdangkyModel) 
        {
            return new CTDangKyDto
            {
                MACTDK = ctdangkyModel.MACTDK,
                MALHP = ctdangkyModel.MALHP,
                MADK = ctdangkyModel.MADK
            };
        }

        public static CTDANGKY ToCTDangKyFromCreateDTO(this CreateCTDangKyRequestDto createCTDangKyRequestDto)
        {
            return new CTDANGKY
            {
                MALHP = createCTDangKyRequestDto.MALHP,
                MADK = createCTDangKyRequestDto.MADK
            };
        }
    }
}