using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject;
using ValueObject.CTChuyenNganh;

namespace Mappers
{
    public static class CTChuyenNganhMappers
    {
        public static CreateCTChuyenNganhRequestDto ToCreateDTOFromCTChuyenNganh(this CTCHUYENNGANH ctChuyenNganh)
        {
            return new CreateCTChuyenNganhRequestDto
            {
                MACN = ctChuyenNganh.MACN,
                MAMH = ctChuyenNganh.MAMH
            };
        }

        public static UpdateCTChuyenNganhRequestDto ToUpdateDTOFromCTChuyenNganh(this CTCHUYENNGANH ctChuyenNganh)
        {
            return new UpdateCTChuyenNganhRequestDto
            {
                MACN = ctChuyenNganh.MACN,
                MAMH = ctChuyenNganh.MAMH
            };
        }
    }
}