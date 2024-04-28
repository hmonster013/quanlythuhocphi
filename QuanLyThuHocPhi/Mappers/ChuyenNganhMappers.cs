using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject;
using ValueObject.ChuyenNganh;

namespace Mappers
{
    public static class ChuyenNganhMappers
    {
        public static CreateChuyenNganhRequestDto ToCreateDTOFromChuyenNganh(this CHUYENNGANH chuyennganh)
        {
            return new CreateChuyenNganhRequestDto
            {
                MACN = chuyennganh.MACN,
                TENCN = chuyennganh.TENCN,
                MAKHOA = chuyennganh.MAKHOA
            };
        }

        public static UpdateChuyenNganhRequestDto ToUpdateDTOFromChuyenNganh(this CHUYENNGANH chuyennganh)
        {
            return new UpdateChuyenNganhRequestDto
            {
                TENCN = chuyennganh.TENCN,
                MAKHOA = chuyennganh.MAKHOA
            };
        }
    }
}