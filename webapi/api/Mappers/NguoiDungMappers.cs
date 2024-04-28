using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.NguoiDung;
using api.Models;

namespace api.Mappers
{
    public static class NguoiDungMappers
    {
        public static NguoiDungDto ToNguoiDungDTO(this NGUOIDUNG nguoidungModel)
        {
            return new NguoiDungDto
            {
                TENTAIKHOAN = nguoidungModel.TENTAIKHOAN,
                MATKHAU = nguoidungModel.MATKHAU,
                QUYEN = nguoidungModel.QUYEN
            };
        }

        public static NGUOIDUNG ToNguoiDungFromCreateDTO(this CreateNguoiDungRequestDto nguoiDungRequestDto)
        {
            return new NGUOIDUNG
            {
                TENTAIKHOAN = nguoiDungRequestDto.TENTAIKHOAN,
                MATKHAU = nguoiDungRequestDto.MATKHAU,
                QUYEN = nguoiDungRequestDto.QUYEN
            };
        }
    }
}