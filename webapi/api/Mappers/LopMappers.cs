using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Lop;
using api.Models;

namespace api.Mappers
{
    public static class LopMappers
    {
        public static LopDto ToLopDTO(this LOP lopModel)
        {
            return new LopDto
            {
                MALOP = lopModel.MALOP,
                MACN = lopModel.MACN
            };
        }

        public static LOP ToLopFromCreateDTO(this CreateLopRequestDto createLopRequestDto)
        {
            return new LOP
            {
                MALOP = createLopRequestDto.MALOP,
                MACN = createLopRequestDto.MACN
            };
        }
    }
}