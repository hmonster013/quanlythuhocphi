using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Khoa;
using api.Models;

namespace api.Mappers
{
    public static class KhoaMappers
    {
        public static KhoaDto ToKhoaDTO(this KHOA khoaModel)
        {
            return new KhoaDto
            {
                MAKHOA = khoaModel.MAKHOA,
                TENKHOA = khoaModel.TENKHOA,
                DONGIA = khoaModel.DONGIA
            };
        }

        public static KHOA ToKhoaFromCreateDTO(this CreateKhoaRequestDto createKhoaRequestDto)
        {
            return new KHOA
            {
                MAKHOA = createKhoaRequestDto.MAKHOA,
                TENKHOA = createKhoaRequestDto.TENKHOA,
                DONGIA = createKhoaRequestDto.DONGIA
            };
        }
    }
}