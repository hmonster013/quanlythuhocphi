using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.PhieuThu;
using api.Models;

namespace api.Mappers
{
    public static class PhieuThuMappers
    {
        public static PhieuThuDto ToPhieuThuDTO(this PHIEUTHU phieuthuModel)
        {
            return new PhieuThuDto
            {
                MAPT = phieuthuModel.MAPT,
                MASV = phieuthuModel.MASV,
                NIENKHOA = phieuthuModel.NIENKHOA,
                HOCKY = phieuthuModel.HOCKY
            };
        }

        public static PHIEUTHU ToPhieuThuFromCreateDTO(this CreatePhieuThuRequestDto createPhieuThuRequestDto)
        {
            return new PHIEUTHU
            {
                MASV = createPhieuThuRequestDto.MASV,
                NIENKHOA = createPhieuThuRequestDto.NIENKHOA,
                HOCKY = createPhieuThuRequestDto.HOCKY
            };
        }
    }
}