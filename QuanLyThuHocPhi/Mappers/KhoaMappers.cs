using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject.Khoa;
using ValueObject;

namespace Mappers
{
    public static class KhoaMappers
    {
        public static CreateKhoaRequestDto ToCreateDTOFromKhoa(this KHOA khoa)
        {
            return new CreateKhoaRequestDto
            {
                MAKHOA = khoa.MAKHOA,
                TENKHOA = khoa.TENKHOA,
                DONGIA = khoa.DONGIA
            };
        }

        public static UpdateKhoaRequestDto ToUpdateDTOFromKhoa(this KHOA khoa)
        {
            return new UpdateKhoaRequestDto
            {
                TENKHOA = khoa.TENKHOA,
                DONGIA = khoa.DONGIA
            };
        }
    }
}