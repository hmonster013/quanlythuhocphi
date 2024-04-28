using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject.MonHoc;
using ValueObject;

namespace Mappers
{
    public static class MonHocMappers
    {
        public static CreateMonHocRequestDto ToCreateDTOFromMonHoc(this MONHOC monhoc)
        {
            return new CreateMonHocRequestDto
            {
                MAMH = monhoc.MAMH,
                TENMH = monhoc.TENMH,
                HOCKY = monhoc.HOCKY,
                SOTINCHI = monhoc.SOTINCHI
            };
        }

        public static UpdateMonHocRequestDto ToUpdateDTOFromMonHoc(this MONHOC monhoc)
        {
            return new UpdateMonHocRequestDto
            {
                TENMH = monhoc.TENMH,
                HOCKY = monhoc.HOCKY,
                SOTINCHI = monhoc.SOTINCHI
            };
        }
    }
}