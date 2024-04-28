using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject.DangKy;
using ValueObject;

namespace Mappers
{
    public static class DangKyMappers
    {
        public static CreateDangKyRequestDto ToCreateDTOFromDangKy(this DANGKY dangKy)
        {
            return new CreateDangKyRequestDto
            {
                HOCKY = dangKy.HOCKY,
                MASV = dangKy.MASV
            };
        }

        public static UpdateDangKyRequestDto ToUpdateDTOFromDangKy(this DANGKY dangKy)
        {
            return new UpdateDangKyRequestDto
            {
                HOCKY = dangKy.HOCKY,
                MASV = dangKy.MASV
            };
        }
    }
}