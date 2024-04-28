using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.CTPhieuThu;
using api.Models;

namespace api.Mappers
{
    public static class CTPhieuThuMappers
    {
        public static CTPhieuThuDto ToCTPhieuThuDTO(this CTPHIEUTHU ctphieuthuModel)
        {
            return new CTPhieuThuDto
            {
                MACTPT = ctphieuthuModel.MACTPT,
                MAPT = ctphieuthuModel.MAPT,
                NGAYDONG = ctphieuthuModel.NGAYDONG,
                SOTIENDONG = ctphieuthuModel.SOTIENDONG
            };
        }

        public static CTPHIEUTHU ToCTPhieuThuFromCreateDTO(this CreateCTPhieuThuRequestDto createCTPhieuThuRequestDto)
        {
            return new CTPHIEUTHU
            {
                MAPT = createCTPhieuThuRequestDto.MAPT,
                NGAYDONG = createCTPhieuThuRequestDto.NGAYDONG,
                SOTIENDONG = createCTPhieuThuRequestDto.SOTIENDONG
            };
        }
    }
}