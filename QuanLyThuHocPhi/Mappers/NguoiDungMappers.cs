using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject.NguoiDung;

namespace Mappers
{
    public static class NguoiDungMappers
    {
        public static CreateNguoiDungRequestDto ToCreateDTOFromNguoiDung(this NGUOIDUNG nguoiDung)
        {
            return new CreateNguoiDungRequestDto
            {
                TENTAIKHOAN = nguoiDung.TENTAIKHOAN,
                MATKHAU = nguoiDung.MATKHAU,
                QUYEN = nguoiDung.QUYEN
            };
        }

        public static UpdateNguoiDungRequestDto ToUpdateDTOFromNguoiDung(this NGUOIDUNG nguoiDung)
        {
            return new UpdateNguoiDungRequestDto
            {
                MATKHAU = nguoiDung.MATKHAU,
                QUYEN = nguoiDung.QUYEN
            };
        }
    }
}