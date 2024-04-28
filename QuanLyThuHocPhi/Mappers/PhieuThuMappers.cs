using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject.PhieuThu;
using ValueObject;

namespace Mappers
{
    public static class PhieuThuMappers
    {
        public static CreatePhieuThuRequestDto ToCreateDTOFromPhieuThu(this PHIEUTHU phieuThu)
        {
            return new CreatePhieuThuRequestDto
            {
                MASV = phieuThu.MASV,
                NIENKHOA = phieuThu.NIENKHOA,
                HOCKY = phieuThu.HOCKY
            };
        }

        public static UpdatePhieuThuRequestDto ToUpdateDTOFromPhieuThu(this PHIEUTHU phieuThu)
        {
            return new UpdatePhieuThuRequestDto
            {
                MASV = phieuThu.MASV,
                NIENKHOA = phieuThu.NIENKHOA,
                HOCKY = phieuThu.HOCKY
            };
        }
    }
}