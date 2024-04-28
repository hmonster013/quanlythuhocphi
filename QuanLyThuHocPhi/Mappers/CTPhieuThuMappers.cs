using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ValueObject.CTPhieuThu;
using ValueObject;

namespace Mappers
{
    public static class CTPhieuThuMappers
    {
        public static CreateCTPhieuThuRequestDto ToCreateDTOFromCTPhieuThu(this CTPHIEUTHU ctPhieuThu)
        {
            return new CreateCTPhieuThuRequestDto
            {
                MAPT = ctPhieuThu.MAPT,
                NGAYDONG = ctPhieuThu.NGAYDONG,
                SOTIENDONG = ctPhieuThu.SOTIENDONG
            };
        }

        public static UpdateCTPhieuThuRequestDto ToUpdateDTOFromCTPhieuThu(this CTPHIEUTHU ctPhieuThu)
        {
            return new UpdateCTPhieuThuRequestDto
            {
                MAPT = ctPhieuThu.MAPT,
                NGAYDONG = ctPhieuThu.NGAYDONG,
                SOTIENDONG = ctPhieuThu.SOTIENDONG
            };
        }
    }
}