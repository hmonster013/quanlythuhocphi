using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject.Lop;
using ValueObject;

namespace Mappers
{
    public static class LopMappers
    {
        public static CreateLopRequestDto ToCreateDTOFromLop(this LOP lop)
        {
            return new CreateLopRequestDto
            {
                MALOP = lop.MALOP,
                MACN = lop.MACN
            };
        }

        public static UpdateLopRequestDto ToUpdateDTOFromLop(this LOP lop)
        {
            return new UpdateLopRequestDto
            {
                MACN = lop.MACN
            };
        }
    }
}