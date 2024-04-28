using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject;
using ValueObject.CTDangKy;

namespace Mappers
{
    public static class CTDangKyMappers
    {
        public static CreateCTDangKyRequestDto ToCreateDTOFromCTDangKy(this CTDANGKY ctdangky)
        {
            return new CreateCTDangKyRequestDto
            {
                MALHP = ctdangky.MALHP,
                MADK = ctdangky.MADK
            };
        }

        public static UpdateCTDangKyRequestDto ToUpdateDTOFromCTDangKy(this CTDANGKY ctdangky)
        {
            return new UpdateCTDangKyRequestDto
            {
                MALHP = ctdangky.MALHP,
                MADK = ctdangky.MADK
            };
        }
    }
}